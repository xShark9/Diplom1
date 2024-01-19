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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuthAPP.Views.Pages.Auth;
using AuthAPP.Views.Windows;

namespace AuthAPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

           // var newForm = new RegisteWin();
            //newForm.Show();
            //Application.Current.Windows[0].Close();
            AuthFrame.NavigationService.Navigate(new SignlnPage());
        }

        private void AuthFrameContentRendered(object sender, EventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
            
        }

        private void AuthFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        public enum ShutdownMode
        {
            // OnExplicitShutdow = 1;
        }
        private void btnMinClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnCloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_Min(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Img_close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
