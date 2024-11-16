using BAL.Services;
using DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUDApp
{
    public class TacticData
    {
        public Dictionary<string, int?> SelectedPlayerIds { get; set; } = new Dictionary<string, int?>();
    }
    /// <summary>
    /// Interaction logic for Tactic.xaml
    /// </summary>
    public partial class Tactic : Window
    {
        private const string SaveFilePath = "tacticData.json";
        private List<ComboBox> _comboBoxes;
        private List<Player> _players;
        private readonly PlayerService _service;
        private User AuthenticateUser { get; set; }

        public Tactic(PlayerService service, User authenticateUser)
        {
            InitializeComponent();
            _service = service;
            AuthenticateUser = authenticateUser;
            InitializeComboBoxes();
            Loaded += Window_Loaded;
        }

        private void InitializeComboBoxes()
        {
            _comboBoxes = new List<ComboBox>
        {
            comboBox1, comboBox2, comboBox3, comboBox4, comboBox5,
            comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11
        };

            foreach (var comboBox in _comboBoxes)
            {
                comboBox.SelectionChanged += ComboBox_SelectionChanged;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
            BindDataToComboBoxes();
            LoadTacticData(); // Load trạng thái đội hình từ file
        }

        private void LoadPlayers()
        {
            if (AuthenticateUser != null)
            {
                int userId = AuthenticateUser.UserId;
                _players = _service.GetAllPlayers(userId);
            }
            else
            {
                MessageBox.Show("Lỗi xác thực người dùng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void BindDataToComboBoxes()
        {
            foreach (var comboBox in _comboBoxes)
            {
                comboBox.ItemsSource = _players;
                comboBox.DisplayMemberPath = "FullName";
                comboBox.SelectedValuePath = "PlayerId";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentComboBox = sender as ComboBox;
            var selectedPlayer = currentComboBox?.SelectedItem as Player;

            // Cập nhật ItemsSource của các ComboBox khác để tránh trùng lặp cầu thủ
            foreach (var comboBox in _comboBoxes)
            {
                if (comboBox != currentComboBox)
                {
                    // Lấy danh sách cầu thủ chưa được chọn trong các ComboBox khác
                    var selectedPlayers = _comboBoxes
                        .Where(cb => cb != comboBox)
                        .Select(cb => cb.SelectedItem as Player)
                        .Where(p => p != null)
                        .Select(p => p.PlayerId)
                        .ToHashSet();

                    var availablePlayers = _players
                        .Where(p => !selectedPlayers.Contains(p.PlayerId))
                        .ToList();

                    comboBox.ItemsSource = availablePlayers;
                }
            }
        }

        private void SaveTacticData()
        {
            var tacticData = new TacticData();

            foreach (var comboBox in _comboBoxes)
            {
                var selectedPlayer = comboBox.SelectedItem as Player;
                tacticData.SelectedPlayerIds[comboBox.Name] = selectedPlayer?.PlayerId;
            }

            File.WriteAllText(SaveFilePath, JsonConvert.SerializeObject(tacticData));
        }

        private void LoadTacticData()
        {
            if (File.Exists(SaveFilePath))
            {
                var tacticData = JsonConvert.DeserializeObject<TacticData>(File.ReadAllText(SaveFilePath));

                foreach (var comboBox in _comboBoxes)
                {
                    if (tacticData.SelectedPlayerIds.TryGetValue(comboBox.Name, out int? playerId) && playerId.HasValue)
                    {
                        comboBox.SelectedItem = _players.FirstOrDefault(p => p.PlayerId == playerId.Value);
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTacticData();
            MessageBox.Show("Đội hình đã được lưu.", "Lưu thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow
            {
                AuthenticateUser = this.AuthenticateUser // Truyền lại AuthenticateUser
            };
            mainWindow.Show();
            this.Close();
        }
    }
}
