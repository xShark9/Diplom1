using AuthAPP.Views.Pages.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using AuthAPP.Views.Pages.Class;
using AuthAPP.Views.Pages;
using System.Windows.Navigation;

namespace AuthAPP.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            FrameX.NavigationService.Navigate(new HomePage());
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void btnCloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void AuthFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        private void AuthFrameContentRendered(object sender, EventArgs e)
        {

        }

        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            FrameX.NavigationService.Navigate(new HomePage());
            
        }
        private void Img_close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Image_Min(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уверены?");
            var newForm = new MainWindow();
            newForm.Show();
            Application.Current.Windows[0].Close();
        }

        private void BtnMen_Click(object sender, RoutedEventArgs e)
        {
            

            
        }
    }

    
}
