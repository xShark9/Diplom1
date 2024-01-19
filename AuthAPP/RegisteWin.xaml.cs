using System.Windows;
using System.Windows.Input;


namespace AuthAPP
{
    /// <summary>
    /// Логика взаимодействия для RegisteWin.xaml
    /// </summary>
    public partial class RegisteWin : Window
    {
        public RegisteWin()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) 
            {
                this.DragMove();
            }
        }
    }
}
