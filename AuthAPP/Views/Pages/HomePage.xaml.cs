using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using AuthAPP.Views.Pages.Class;

namespace AuthAPP.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
             TBlockWelcom.Text = $"Добро пожаловать, {App.currentUser.FirstName} {App.currentUser.Patronymic} из {App.currentUser.Class} класса!";
            using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
            {
                SqlCommand w2 = new SqlCommand("SELECT * FROM Tests WHERE IdUser = @user", connection);
                w2.Parameters.AddWithValue("@user", App.currentUser.IdUser);
                SqlDataAdapter adapter = new SqlDataAdapter(w2);
                DataTable ds = new DataTable("Users");
                adapter.Fill(ds);
                DtOp.ItemsSource = ds.DefaultView;
                w2.Connection.Open();
                w2.ExecuteNonQuery();
                w2.Connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.currentUser.Class == "4a")
            {
                this.NavigationService.Navigate(new Classfour());                
            }
            else if (App.currentUser.Class == "3b")
            {
                this.NavigationService.Navigate(new Classtwo());
            }
        }
    }
}
