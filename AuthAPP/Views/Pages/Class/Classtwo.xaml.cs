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
using System.Data.SqlClient;
using AuthAPP.Views.Pages.Class.Numbers_and_figures;
using System.Runtime.InteropServices;

namespace AuthAPP.Views.Pages.Class
{
    /// <summary>
    /// Логика взаимодействия для Classtwo.xaml
    /// </summary>
    public partial class Classtwo : Page
    {
        public Classtwo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (Convert.ToInt32(tbx15.Text) != 15)
            //{
            //    a = 0;
            //} else
            //{
            //    a = 1;
            //}
            //if (Convert.ToInt32(tbx24.Text) != 24)
            //{
            //    a = 1;
            //}
            //else
            //{
            //    a = 2;
            //}
            //if (a == 2)
            //{
            //    b = 5;
            //}
            //else if( a == 1)
            //{
            //    b = 3;
            //} else
            //{
            //    b = 2;
            //}

            //MessageBox.Show("Ваша оценка за тест: " + b+ "  Количество правильных ответов: " +a);

            //using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
            //{
            //    SqlCommand w2 = new SqlCommand("SELECT IdTest FROM Test WHERE IdTest=(Select max(IdTest) FROM Test)",connection);
            //    w2.Connection.Open();
            //    c =int.Parse( w2.ExecuteScalar().ToString()) +1;
            //    w2.ExecuteNonQuery();
            //    w2.Connection.Close();

            //   SqlCommand w1 = new SqlCommand("Insert into Test Values (@IdTest,@TestName,@TestOne,@TestTwo,@TestThree,@TestFour,@UserId)", connection);
            //    w1.Parameters.AddWithValue("@IdTest", c);

            //    w1.Parameters.AddWithValue("@TestName", "Числа и цифры");
            //    w1.Parameters.AddWithValue("@TestOne", a);
            //    w1.Parameters.AddWithValue("@TestTwo", a);
            //    w1.Parameters.AddWithValue("@TestThree", a);
            //    w1.Parameters.AddWithValue("@TestFour", a);

            //    w1.Parameters.AddWithValue("@UserId", App.currentUser.IdUser);
            //    w1.Connection.Open();
            //    w1.ExecuteNonQuery();
            //    w1.Connection.Close();
            //    btncl.IsEnabled = false;
            //    this.NavigationService.Navigate(new Classfour());
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Random a = new Random();
            int b = a.Next(1,3);
            if (b == 1)
            {
                MessageBox.Show("Ваш вариант:" +b);
                FrameOne.NavigationService.Navigate(new NumOne());
            }
            else if (b == 2) 
            {
                MessageBox.Show("Ваш вариант:" + b);
                FrameOne.NavigationService.Navigate(new NumTwo());
            }
            
        }

        private void FrameOne_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
