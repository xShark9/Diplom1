using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuthAPP.Views.Pages.Auth;
using AuthAPP.Controller;
using System.Data.SqlClient;
using System.Net;
using AuthAPP.Views.Windows;


namespace AuthAPP.Views.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для SignlnPage.xaml
    /// </summary>
    public partial class SignlnPage : Page
    {
        UserController userController = new UserController();
        public SignlnPage()
        {
            InitializeComponent();
        }


        private void HLinkRegistrationClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage());
        }

        private void BtnEntryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TBoxUsername.Text) && !String.IsNullOrEmpty(PBoxPassword.Password))
                {
                    var user = userController.SignIn(TBoxUsername.Text.Trim().ToLower(), PBoxPassword.Password.Trim().ToLower());
                    App.currentUser = user;
                    if (App.currentUser.RoleId == 1)
                    {
                        var newForm = new MainWindow2();
                        newForm.Show();
                        Application.Current.Windows[0].Close();
                    } 
                   else if (App.currentUser.RoleId == 2)
                    {
                        this.NavigationService.Navigate(new TeachPage());
                    }
                }
                else
                {
                    MessageBox.Show("Заполнены не все поля!", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Пользователь не найден", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void btnMinClick(object sender, RoutedEventArgs e)
        {
            
        }




        // static string GetRole(string login, string password)
        //{
        //   string role = null;
        //   if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
        //   {
        //      using (SqlConnection connection = new SqlConnection()
        //  }
        // }
    }
}
