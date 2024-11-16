using BAL.Services;
using DAL.Entities;
using DAL.Repo;
using Microsoft.Identity.Client.NativeInterop;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace CRUDApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlayerService _service = new();
        private PlayerRepo _playerRepo = new PlayerRepo();

        public DAL.Entities.User AuthenticateUser { get; set; }

        private ObservableCollection<Player> _originalPlayers = new();
        private ObservableCollection<Player> _filteredPlayers = new();



        public MainWindow()
        {
            InitializeComponent();
            PlayersDataGrid.ItemsSource = _filteredPlayers;
        }

     

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        private void ButtonTactic_Click(object sender, RoutedEventArgs e)
        {
            Tactic tactic = new Tactic(_service, AuthenticateUser);

            tactic.Show();
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Player? selected = PlayersDataGrid.SelectedItem as Player;

            if (selected == null)
            {
                MessageBox.Show("Please select a player before editing", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            // Mở cửa sổ chi tiết để chỉnh sửa
            DetailWindow detail = new();
            detail.EditedOne = selected;
            bool? result = detail.ShowDialog(); // Kết quả từ cửa sổ chi tiết

            if (result == true)
            {
                // Gọi repository để cập nhật thông tin
                _playerRepo.Update(detail.EditedOne);

                // Lấy lại danh sách mới từ DB
                var updatedPlayers = _playerRepo.GetAll(AuthenticateUser.UserId);

                // Làm mới ObservableCollection và cập nhật DataGrid
                _filteredPlayers.Clear();
                foreach (var player in updatedPlayers)
                {
                    _filteredPlayers.Add(player);
                }

                PlayersDataGrid.ItemsSource = _filteredPlayers; // Cập nhật lại DataGrid
            }
            }



        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            int userId = AuthenticateUser.UserId;

            // Mở cửa sổ thêm mới cầu thủ
            DetailWindow detail = new();
            detail.ShowDialog();

            // Cập nhật lại dữ liệu sau khi cửa sổ thêm mới đóng
            FillDataGrid(_service.GetAllPlayers(userId));
        }


        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();

            // Hiển thị cửa sổ Login
            loginWindow.Show();

            // Đóng cửa sổ hiện tại
            this.Close();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string teamName = _service.GetTeamNameByUserId(AuthenticateUser.UserId);
            int userId = AuthenticateUser.UserId; // Giả sử `AuthenticateUser` chứa thông tin người dùng đăng nhập.
            FillDataGrid(_service.GetAllPlayers(userId));

            if (AuthenticateUser.Role == 2) // Kiểm tra quyền của người dùng
            {
                ButtonAdd.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
                ButtonUpdate.IsEnabled = false;
            }

            HelloMsgClub.Content = teamName;
            HelloMsgLabel.Content = AuthenticateUser.FullName;

        }

        public void FillDataGrid(List<Player> arr)
        {

            PlayersDataGrid.ItemsSource = arr;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int userId = AuthenticateUser.UserId;
            Player? selected = PlayersDataGrid.SelectedItem as Player;

            if (selected == null)
            {
                MessageBox.Show("Please select before deleting", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            MessageBoxResult answer = MessageBox.Show("Do you really want to delete ?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;


            _service.DeletePlayer(selected);
            FillDataGrid(_service.GetAllPlayers(userId));
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search here...")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Search here...";
                SearchBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            int userId = AuthenticateUser.UserId;
            var players = _service.GetAllPlayers(userId);
            string searchText = SearchBox.Text;
            if (string.IsNullOrWhiteSpace(searchText) || searchText == "Search here...")
            {
                PlayersDataGrid.ItemsSource = players;
            }

            if (searchText != "Search here..." && !string.IsNullOrWhiteSpace(searchText))
            {

                // Filter the list by FullName or Position
                var filteredPlayers = players.Where(p =>
                    p.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    (p.Position != null && p.Position.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                ).ToList();

                PlayersDataGrid.ItemsSource = filteredPlayers;
            }
        }
    }
}

