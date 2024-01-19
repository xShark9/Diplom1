using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AuthAPP.Controller;
using AuthAPP.Models;

namespace AuthAPP.Views.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        GenderController genderController = new GenderController();
        ClassController classController = new ClassController();
        UserController userController = new UserController();
        private int _gender = 0;
        private int _classes = 0;
        public SignUpPage()
        {
            InitializeComponent();
        }

        private bool IsUserRegistered(string username)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
                {
                    connection.Open();
                    username = TBoxUserName.myTextBox.textBox.Text;
                    SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Users Where username=@Username", connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0) { MessageBox.Show("Такой логин уже существует, попробуйте выбрать другой."); }
                    else
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка " + ": " + ex.Message);
            }
            return result;
        }

        private void BtnRegisterClick(object sender, RoutedEventArgs e)
        { 
            if (IsUserRegistered(TBoxUserName.myTextBox.textBox.Text) == false)
            {   
            } else
            {
                try
                {
                    if (!String.IsNullOrEmpty(TBoxFirstName.myTextBox.textBox.Text) && !String.IsNullOrEmpty(TBoxLastName.myTextBox.textBox.Text) && !String.IsNullOrEmpty(TBoxPatronymic.myTextBox.textBox.Text) && !String.IsNullOrEmpty(DPickerDateBirth.Text) && !String.IsNullOrEmpty(TBoxUserName.myTextBox.textBox.Text) && _gender > 0)
                    {
                        var user = userController.CreateNewUser(TBoxFirstName.myTextBox.textBox.Text.Trim(), TBoxLastName.myTextBox.textBox.Text.Trim(), TBoxPatronymic.myTextBox.textBox.Text.Trim(), DPickerDateBirth.SelectedDate.Value, TBoxUserName.myTextBox.textBox.Text.Trim(), PBoxPassword.Password.Trim() ,_gender, _classes);
                        App.currentUser = user;
                        MessageBox.Show("Вы успешно зарегистрировались!");
                        this.NavigationService.Navigate(new SignlnPage());
                    }
                    else
                    {
                        MessageBox.Show("Заполнены не все поля!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }    
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            var allGender = genderController.GetGenders();
            CBoxGender.SelectedIndex = 0;
            CBoxGender.DisplayMemberPath = "GenderName";
            CBoxGender.SelectedValue = "IdGender";
            CBoxGender.ItemsSource = allGender;
            DPickerDateBirth.DisplayDateEnd = DateTime.Now.AddYears(1-24);
            var allClasses = classController.GetClasses();
            CBoxClass.SelectedIndex = 0;
            CBoxClass.DisplayMemberPath = "Class";
            CBoxClass.SelectedValue = "IdClass";
            CBoxClass.ItemsSource = allClasses;
        }

        private void CBoxGenderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Genders gender = CBoxGender.SelectedItem as Genders;
            _gender = gender.IdGender;
        }

        private void Male_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {     
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void CBoxClassSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes classes = CBoxClass.SelectedItem as Classes;
            _classes = classes.IdClass;
        }
    }
}
