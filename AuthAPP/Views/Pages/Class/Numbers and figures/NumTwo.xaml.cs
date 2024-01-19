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

namespace AuthAPP.Views.Pages.Class.Numbers_and_figures
{
    /// <summary>
    /// Логика взаимодействия для NumTwo.xaml
    /// </summary>
    public partial class NumTwo : Page
    {
        public NumTwo()
        {
            InitializeComponent();
        }
        int a = 0;
        int b = 0;
        int c = 0;
        bool ValidateText(string Text)
        {
            if (string.IsNullOrEmpty(Text))
            {
                
                return false;
            }
            return true;
        }

        private void btnFin_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateText(txtbx1.Text) == false || ValidateText(txtbx2.Text) == false || ValidateText(txtbx3.Text) == false || ValidateText(txtbx4.Text) == false || ValidateText(txtbx5.Text) == false || ValidateText(txtbx6.Text) == false || ValidateText(txtbx7.Text) == false || ValidateText(txtbx8.Text) == false || ValidateText(txtbx9.Text) == false || ValidateText(txtbx10.Text) == false || ValidateText(txtbx11.Text) == false || ValidateText(txtbx12.Text) == false || ValidateText(txtbx13.Text) == false || ValidateText(txtbx14.Text) == false || ValidateText(txtbx15.Text) == false || ValidateText(txtbx16.Text) == false)
            {
                MessageBox.Show("Вы заполнили не все поля.");

            if (ValidateText(txtbx1.Text) == false )
            {
                txtbx1.BorderBrush = Brushes.Red;
                
            } else
            {
                a = a + 1;
                txtbx1.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx2.Text) == false)
            {
                txtbx2.BorderBrush = Brushes.Red;
                
            }
            else
            {
                a = a + 1;
                txtbx2.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx3.Text) == false)
            {
                txtbx3.BorderBrush = Brushes.Red;

            }
            else
            {
                a = a + 1;
                txtbx3.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx4.Text) == false)
            {
                txtbx4.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx4.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx5.Text) == false)
            {
                txtbx5.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx5.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx6.Text) == false)
            {
                txtbx6.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx6.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx7.Text) == false)
            {
                txtbx7.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx7.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx8.Text) == false)
            {
                txtbx8.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx8.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx9.Text) == false)
            {
                txtbx9.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx9.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx10.Text) == false)
            {
                txtbx10.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx10.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx11.Text) == false)
            {
                txtbx11.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx11.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx12.Text) == false)
            {
                txtbx12.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx12.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx13.Text) == false)
            {
                txtbx13.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx13.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx14.Text) == false)
            {
                txtbx14.BorderBrush = Brushes.Red;

            }
            else
            {a = a + 1;
                txtbx14.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx15.Text) == false)
            {
                txtbx15.BorderBrush = Brushes.Red;

            }
            else
            {
                a = a + 1;
                txtbx15.BorderBrush = Brushes.Gray;
            }
            if (ValidateText(txtbx16.Text) == false)
            {
                txtbx16.BorderBrush = Brushes.Red;

            }
            else
            {
                a = a + 1;
                txtbx16.BorderBrush = Brushes.Gray;
            }
            }
            else 
            {
                if (Int32.Parse(txtbx1.Text) == 1)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx2.Text) == 2)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx3.Text) == 3)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx4.Text) == 4)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx5.Text) == 5)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx6.Text) == 6)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx7.Text) == 7)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx8.Text) == 8)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx9.Text) == 9)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx10.Text) == 10)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx11.Text) == 11)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx12.Text) == 12)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx13.Text) == 13)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx14.Text) == 14)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx15.Text) == 15)
                {
                    b = b + 1;
                }
                if (Int32.Parse(txtbx16.Text) == 16)
                {
                    b = b + 1;
                }
               if (b < 8)
                {
                    c = 2;
                }
               if (b >= 8 && b < 12)
                {
                    c = 3;
                }
               if (b >= 12 && b <14)
                {
                    c = 4;
                }
               if (b >= 14)
                {
                    c = 5;
                }
                    MessageBox.Show("Вы набрали " + b + "  баллов, выша оценка - " + c);
                b = 0; c = 0;
            }

        }

        private void txtbx1_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
