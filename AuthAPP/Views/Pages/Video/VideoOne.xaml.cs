using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthAPP.Views.Pages.Video
{
    /// <summary>
    /// Логика взаимодействия для VideoOne.xaml
    /// </summary>
    public partial class VideoOne : Page
    {
        public VideoOne()
        {
            InitializeComponent();
        }
        private bool go_player;

      

        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeLine.Maximum = Video.NaturalDuration.TimeSpan.TotalSeconds;
        }


        private void TimeLine_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!go_player)
                mediaStoryboard.Storyboard.Seek(MyPage, TimeSpan.FromSeconds(TimeLine.Value), TimeSeekOrigin.BeginTime);
        }

        private void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            // Получаем значение времени для раскадровки
            Clock storyboardClock = (Clock)sender;

            if (storyboardClock.CurrentProgress != null)
            {
                go_player = true;
                TimeLine.Value = storyboardClock.CurrentTime.Value.TotalSeconds;
                go_player = false;
            }
        }
        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            Video.Volume = (double)(Volume.Value);
        }

        private void btnleft_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnright_Click(object sender, RoutedEventArgs e)
        {
            if ( MessageBox.Show("Вы хотите начать смотреть следующий урок ?","Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new VideoTwo());
            }
            
        }


    }
}
