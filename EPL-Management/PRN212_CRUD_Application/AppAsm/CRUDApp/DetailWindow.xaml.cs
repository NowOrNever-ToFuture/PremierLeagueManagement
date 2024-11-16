using BAL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {

        public Player EditedOne { get; set; }
        private PlayerService _service = new();
        private TeamService _sup = new();
        public User Authenticate = new();


        public DetailWindow()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (EditedOne == null)
            {
                DetailWindowModeLabel.Content = "Create Player";
                PlayerIdTextBox.IsEnabled = false;

                int userId = GetLoggedInUserId(); // Assuming you have a method to get the current user's ID
                TeamNameTextBox.Text = _service.GetTeamNameByUserId(userId);

                return;
            }

            DetailWindowModeLabel.Content = "Update";
            PlayerIdTextBox.IsEnabled = false;
            PlayerNameTextBox.Text = EditedOne.PlayerId.ToString();
            PlayerNameTextBox.Text = EditedOne.FullName;
            PositonComboBox.SelectedItem = EditedOne.Position;
            NumberTextBox.Text = EditedOne.JerseyNumber.ToString();
            DateOfBirthDatePicker.SelectedDate = EditedOne.DateOfBirth;
            NationalityTextBox.Text = EditedOne.Nationality;


            TeamNameTextBox.IsEnabled = false;
            TeamNameTextBox.Text = _service.GetTeamNameByUserId(UserService.LoggedInUserId);
        }

        private int GetLoggedInUserId()
        {
            return UserService.LoggedInUserId;
        }

        public delegate void DataUpdatedHandler();  // Định nghĩa sự kiện

        public event DataUpdatedHandler? DataUpdated;  // Sự kiện khi dữ liệu được cập nhật


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int JerseyNumber;
            if (!int.TryParse(NumberTextBox.Text, out JerseyNumber))
            {
                MessageBox.Show("Jersey Number must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra số áo nằm trong phạm vi hợp lệ
            if (JerseyNumber < 0 || JerseyNumber > 99)
            {
                MessageBox.Show("Invalid JerseyNumber. Please enter a number between 0 and 99.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra số áo đã được sử dụng trong đội hay chưa
            if (_service.IsJerseyNumberDuplicate(JerseyNumber,  Authenticate.UserId,EditedOne?.PlayerId))
            {
                MessageBox.Show("Jersey Number already exists in the team. Please choose a different number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(DateOfBirthDatePicker.Text))
            {
                MessageBox.Show("Date of Birth is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Player obj = new Player(); 
            if (EditedOne == null)
            {
                // Create operation
                obj.FullName = PlayerNameTextBox.Text;
                obj.Position = (PositonComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                obj.JerseyNumber = JerseyNumber;
                obj.DateOfBirth = DateOfBirthDatePicker.DisplayDate;
                obj.Nationality = NationalityTextBox.Text;
                obj.FootballTeamId = _service.GetFootballTeamIdByUserId(UserService.LoggedInUserId);
                _service.CreatePlayer(obj);
            }
            else
            {
                // Update operation
                obj = _service.GetPlayerById(EditedOne.PlayerId); // Lấy thực thể từ DbContext
                if (obj == null)
                {
                    MessageBox.Show("Player not found in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                EditedOne.FullName = PlayerNameTextBox.Text;
                EditedOne.Position = (PositonComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                EditedOne.JerseyNumber = JerseyNumber;
                EditedOne.DateOfBirth = DateOfBirthDatePicker.DisplayDate;
                EditedOne.Nationality = NationalityTextBox.Text;
                EditedOne.FootballTeamId = _service.GetFootballTeamIdByUserId(UserService.LoggedInUserId);
                _service.UpdatePlayer(obj); // Update thực thể
            }

            // Gán giá trị
           

          
            
               
        
            
            DialogResult = true; // Trả về kết quả OK
            this.Close();
        }






        private void CloseButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}




