using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using AuthAPP.Controller;
using AuthAPP.Models;
using System.Linq;
using System;
using System.Windows.Data;

namespace AuthAPP.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeachPage.xaml
    /// </summary>
    public partial class TeachPage : Page
    {
        UserController userController = new UserController();

        public TeachPage()
        {
            InitializeComponent();
        }

       void Create()
        {
            using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
            {
                SqlCommand w2 = new SqlCommand("SELECT * FROM Users WHERE Class = @class AND RoleId = 1", connection);
                w2.Parameters.AddWithValue("@class", App.currentUser.Class);
                SqlDataAdapter adapter = new SqlDataAdapter(w2);
                DataTable ds = new DataTable("Users");
                adapter.Fill(ds);
                Dtgrid.ItemsSource = ds.DefaultView;
                w2.Connection.Open();
                w2.ExecuteNonQuery();
                w2.Connection.Close();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            
            TBlockWelcom.Text = $"Добро пожаловать, {App.currentUser.FirstName} {App.currentUser.Patronymic}";
            // Create();
            Dtgrid.ItemsSource = AppData.auth.Users.Where(p => p.IdClass == 7).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Editor());
        }

        private void btndel_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Controlwork());
             


        }

        private void dlt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = Dtgrid.SelectedItem;
                Users user = selectedRow as Users;
                long id = user.IdUser;
                using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
                {
                    SqlCommand w2 = new SqlCommand("Delete from Users where IdUser ='" + id + "'", connection);
                    w2.Connection.Open();
                    w2.ExecuteNonQuery();
                    w2.Connection.Close();
                    Dtgrid.ItemsSource = AppData.auth.Users.Where(p => p.IdClass == 7).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
