using AuthAPP.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AuthAPP.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Controlwork.xaml
    /// </summary>
    public partial class Controlwork : Page
    {
        


        public Controlwork()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Conrlwrk.ItemsSource = AppData.auth.Tests.Where(q => q.Users.IdClass == 7).Where(p => p.Users.RoleId == 1).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = Conrlwrk.SelectedItem;
                Tests test = selectedRow as Tests;
                long id = test.IdTest;
                using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
                {
                    SqlCommand w2 = new SqlCommand("Delete from Tests where IdTest ='" + id + "'", connection);
                    w2.Connection.Open();
                    w2.ExecuteNonQuery();
                    w2.Connection.Close();
                    Conrlwrk.ItemsSource = AppData.auth.Tests.Where(q => q.Users.IdClass == 7).Where(p => p.Users.RoleId == 1).ToList();
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
