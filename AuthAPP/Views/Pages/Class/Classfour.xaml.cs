using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using AuthAPP.Views.Pages.Video;
using AuthAPP.Views.Pages.Class.Test.ClassFour;

namespace AuthAPP.Views.Pages.Class
{
    /// <summary>
    /// Логика взаимодействия для Classfour.xaml
    /// </summary>
    public partial class Classfour : Page
    {
        public Classfour()
        {
            InitializeComponent();
        }
        
        private bool IsTestCompleted( string name)
        {
            bool result = false;
                using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
                {
                    connection.Open();
                    // string name = "Тема: Решение неравенств";
                    SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Tests Where TestName=@TestName AND IdUser = @user", connection);
                    cmd.Parameters.AddWithValue("@TestName", name);
                    cmd.Parameters.AddWithValue("@user", App.currentUser.IdUser);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0) {   }
                    else
                    {
                        result = true;
                    }
                    connection.Close();
                }
            
            return result;
        }

        private void bnt1_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void bnt2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VideoTwo());
        }

        private void bnt3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VideoOne());
          //  var newForm = new myWindow();
          //  newForm.Show();  
        }

        private void bnt4_Click(object sender, RoutedEventArgs e)
        {
            if (IsTestCompleted("Тема: Решение неравенств") == false)
            {
                MessageBox.Show("Такой Тест вы уже решали"); bnt4.IsEnabled = false;
                
            }
            else
            {
                var newForm = new TestOne();
                Application.Current.Windows[0].Visibility = Visibility.Collapsed;
                newForm.ShowDialog();
                Application.Current.Windows[0].Visibility = Visibility.Visible;
            }
            
        }

        private void bnt5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bnt6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            




        }

        private void bntvideo3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bntvideo4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
