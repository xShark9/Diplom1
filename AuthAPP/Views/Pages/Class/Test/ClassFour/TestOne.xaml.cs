using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace AuthAPP.Views.Pages.Class.Test.ClassFour
{
    /// <summary>
    /// Логика взаимодействия для TestOne.xaml
    /// </summary>
    public partial class TestOne : Window
    {
        int question_count;
        int correct_answers;
        int wront_answer;
        string[] array;
        int correct_answer_number;
        int selected_response;
        float a;
        int q;
        int r;
        System.IO.StreamReader Read;

        void Random()
        {
            Random random = new Random();
             r = random.Next(1, 3);
        }

        public TestOne()
        {
            InitializeComponent();
        }
        void Start()
        {
            if (r == 1) 
            { 
                try
                {
                    Read = new System.IO.StreamReader("4-2-1.txt");
                    question_count = 0;
                    correct_answers = 0;
                    wront_answer = 0;
                    array = new string[20];
                    lbl2.Text = Read.ReadLine();
                    lbvar.Content = Read.ReadLine();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка с файлом теста");
                }
                MessageBox.Show("Ваш вариант:" + r);
            }
            else if (r == 2)
            {
                try
                {
                    Read = new System.IO.StreamReader("4-2-2.txt");
                    question_count = 0;
                    correct_answers = 0;
                    wront_answer = 0;
                    array = new string[20];
                    lbl2.Text = Read.ReadLine();
                    lbvar.Content = Read.ReadLine();
                    //  int linenumber = 0;
                    //   string line = Read.ReadLine();
                    //  while (line != null)
                    //  {
                    //    linenumber++;
                    //  MessageBox.Show("Строка"+ linenumber, line);
                    // line = Read.ReadLine();
                    //}
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка с файлом теста");

                }
                MessageBox.Show("Ваш вариант:" + r);
            }
            Question();
        }
        void Question()
        {
            
            tbx1.Text = Read.ReadLine();
            rb1.Content = Read.ReadLine();
            rb2.Content = Read.ReadLine();
            rb3.Content = Read.ReadLine();
            rb4.Content = Read.ReadLine();
            correct_answer_number = int.Parse(Read.ReadLine());
            
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            bt1.IsEnabled = false;
            question_count = question_count + 1;
            if (Read.EndOfStream == true) bt1.Content = "Завершить";
        }
        void Switch(object sender, RoutedEventArgs e)
        {
            bt1.IsEnabled = true;
            bt2.IsEnabled = false;
            bt1.Focus();
            RadioButton p = (RadioButton)sender;
            var t = p.Name;
            selected_response = int.Parse(t.Substring(2));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            bt1.Content = "Следующий вопрос";
            bt2.Content = "Выход";
            rb1.Checked += new RoutedEventHandler(Switch);
            rb2.Checked += new RoutedEventHandler(Switch);
            rb3.Checked += new RoutedEventHandler(Switch);
            rb4.Checked += new RoutedEventHandler(Switch);
            

            Random();
            Start();
        }
        private void bt1_Click(object sender, RoutedEventArgs e)
        {

            if (selected_response == correct_answer_number)
            {
                correct_answers = correct_answers + 1;
            }

            if (selected_response != correct_answer_number)
            {
                wront_answer = wront_answer + 1;
                array[wront_answer] = (string)tbx1.Text;
            }

            if ((string)bt1.Content == "Начать тестирование сначала")
            {
                bt1.Content = "Следующий вопрос";
                Start();
                return;
            }
            if ((string)bt1.Content == "Завершить")
            {
                Read.Close();
                tbx1.Text = String.Format("Тестирование завершено.\n" +
                    "Правильных ответов: {0} из {1}.\n" +
                    "Набранные балы: {2:F2}.", correct_answers, question_count, (correct_answers * 5.0F) / question_count);
                a = (correct_answers * 5.0F) / question_count;
                if (a < 2.5) q = 2;else if (a>= 2.5 && a < 3.5) q = 3; else if (a >= 3.5 && a <4.5) q = 4; else q = 5;
                var str = "Список ошибок" +
                    ":\n\n";
                for (int i = 1; i <= wront_answer; i++)
                {
                    str = str + array[i] + "\n";
                }

                if (wront_answer != 0)
                {
                    MessageBox.Show(str, "Тестирование завершено");
                }

                using (SqlConnection connection = new SqlConnection(@"Database=auth; Data Source=XSHARK; Integrated Security=SSPI"))
                {
                    SqlCommand w2 = new SqlCommand("SELECT IdTest FROM Tests WHERE IdTest=(Select max(IdTest) FROM Tests)", connection);
                    w2.Connection.Open();
                    int c = int.Parse(w2.ExecuteScalar().ToString()) + 1;
                    w2.ExecuteNonQuery();
                    w2.Connection.Close();

                    SqlCommand w1 = new SqlCommand("Insert into Tests Values (@IdTest,@TestName,@TaskOption,@NumberQuestions,@CorrectAnswers,@NumberPoints,@Evaluation,@IdUser)", connection);
                    w1.Parameters.AddWithValue("@IdTest", c);
                    w1.Parameters.AddWithValue("@TestName", lbl2.Text);
                    w1.Parameters.AddWithValue("@TaskOption", r);
                    w1.Parameters.AddWithValue("@NumberQuestions", question_count);
                    w1.Parameters.AddWithValue("@CorrectAnswers", correct_answers);
                    w1.Parameters.AddWithValue("@NumberPoints", a);
                    w1.Parameters.AddWithValue("@Evaluation", q);
                    w1.Parameters.AddWithValue("@IdUser", App.currentUser.IdUser);
                    w1.Connection.Open();
                    w1.ExecuteNonQuery();
                    w1.Connection.Close();
                    bt1.IsEnabled = false;
                    bt2.IsEnabled = true;
                }
            }
            if ((string)bt1.Content == "Следующий вопрос")
            {
                Question();
            }
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
