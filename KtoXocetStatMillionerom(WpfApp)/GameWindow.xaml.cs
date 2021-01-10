using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KtoXocetStatMillionerom_WpfApp_
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        MediaPlayer mediaPlayer;
        List<Question> Questions;
        List<Button> AnswerButtons;
        Question question;
        int questionNumber;
        int time = 30;
        DispatcherTimer timer;
        DispatcherTimer timer1;
        DispatcherTimer timer2;
        Button button;
        public GameWindow(ref List<Question> Questions)
        {
            InitializeComponent();
            mediaPlayer = new MediaPlayer();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();

            timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 3);
            timer1.Tick += Timer_Tick1;
            timer2 = new DispatcherTimer();
            timer2.Interval = new TimeSpan(0, 0, 2);
            timer2.Tick += Timer_Tick2;
            this.Questions = Questions;
            questionNumber = 1;
            AnswerButtons = new List<Button> { answerButton1, answerButton2, answerButton3, answerButton4 };
            foreach (var button in AnswerButtons)
            {
                button.Click += AnswerButton_Click;
                button.Background = new LinearGradientBrush(Color.FromArgb(100, 0, 0, 0), Color.FromArgb(100, 18, 14, 100), 0.0);
            }
            LevelPassing();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                timeButton.Content = $"{time}";
                time--;
            }
            else
            {
                mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/WrongAnswerSound.mp3"));
                mediaPlayer.Play();
                timer.Stop();
                string text = String.Empty;
                if (questionNumber > 5 && questionNumber < 11)
                    text = "Time is up. You LOSE😥 \n You have 1000💲";
                else if (questionNumber > 10 && questionNumber < 15)
                    text = "Time is up. You LOSE😥 \n You  have 32000💲";
                else
                    text = "Time is up. You LOSE😥 \n You  have 0️💲";
                MBWindow mBWindow = new MBWindow(text, ref Questions);
                this.Close();
                mBWindow.ShowDialog();
            }
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            button.IsEnabled = true;
            button.Click -= AnswerButton_Click;
            Button correctAnswerButton = AnswerButtons.Find(x => x.Content.ToString() == question.CorrectAnswer);
            correctAnswerButton.Background = new SolidColorBrush(Color.FromArgb(100, 46, 205, 39));
            if (button.Content.ToString() != question.CorrectAnswer)
            {
                mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/WrongAnswerSound.mp3"));
                mediaPlayer.Play();
                button.Background = new SolidColorBrush(Color.FromArgb(100, 205, 58, 39));
                string text = String.Empty;
                if (questionNumber > 5 && questionNumber < 11)
                    text = "You LOSE😥 \n You have 1000💲";
                else if (questionNumber > 10 && questionNumber < 15)
                    text = "You LOSE😥 \n You  have 32000💲";
                else
                    text = "You LOSE😥 \n You  have 0️💲";
                MBWindow mBWindow = new MBWindow(text, ref Questions);
                this.Close();
                mBWindow.ShowDialog();
            }
            else
            {
                mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/CorrectAnswerSound.mp3"));
                mediaPlayer.Play();
                if (questionNumber == 15)
                {
                    this.Close();
                    MBWindow mBWindow = new MBWindow("YOU ARE MILLIONAIR🎉💸💰", ref Questions);
                    mBWindow.ShowDialog();
                }
                else
                    timer2.Start();
                questionNumber++;
            }
            timer1.Stop();
        }
        private void Timer_Tick2(object sender, EventArgs e)
        {
            button.Background = new LinearGradientBrush(Color.FromArgb(100, 0, 0, 0), Color.FromArgb(100, 18, 14, 100), 0.0);
            for (int i = 0; i < AnswerButtons.Count; i++)
            {
                AnswerButtons[i].Click += AnswerButton_Click;
            }
            foreach (var item in AnswerButtons)
            {
                item.IsEnabled = true;
            }
            LevelPassing();
            timer2.Stop();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer1.Stop();
            timer2.Stop();
            this.Close();
        }

        private void LevelPassing()
        {
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/NewQuSound.mp3"));
            mediaPlayer.Play();
            timer.Start();
            List<Question> LevelQuestions = Questions.FindAll(x => x.HardLevel == questionNumber);
            Random random = new Random();
            int index = random.Next(0, LevelQuestions.Count);
            question = LevelQuestions[index];
            questionTextBlock.Text = question.Text;
            int number;
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    number = random.Next(1, 5);
                } while (numbers.Any(x => x == number));
                numbers[i] = number;
            }
            AnswerButtons[numbers[0] - 1].Content = question.CorrectAnswer;
            AnswerButtons[numbers[1] - 1].Content = question.IncorrectAnswer1;
            AnswerButtons[numbers[2] - 1].Content = question.IncorrectAnswer2;
            AnswerButtons[numbers[3] - 1].Content = question.IncorrectAnswer3;
            switch (questionNumber)
            {
                case 1:
                    level1Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    break;
                case 2:
                    level2Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level1Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 3:
                    level3Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level2Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 4:
                    level4Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level3Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 5:
                    level5Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level4Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 6:
                    level6Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level5Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 7:
                    level7Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level6Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 8:
                    level8Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level7Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 9:
                    level9Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level8Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 10:
                    level10Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level9Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 11:
                    level11Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level10Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 12:
                    level12Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level11Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 13:
                    level13Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level12Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 14:
                    level14Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level13Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                case 15:
                    level15Label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    level14Label.Background = new SolidColorBrush(Color.FromArgb(50, 29, 14, 35));
                    break;
                default:
                    break;
            }
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/AnswerClickedSound.mp3"));
            mediaPlayer.Play();
            timer.Stop();
            time = 30;
            button = sender as Button;
            button.IsEnabled = false;
            button.Background = new SolidColorBrush(Color.FromArgb(100, 18, 14, 255));
            int index = AnswerButtons.FindIndex(x => x == button);
            for (int i = 0; i < AnswerButtons.Count; i++)
            {
                if (i != index)
                    AnswerButtons[i].Click -= AnswerButton_Click;
            }
            timer1.Start();

        }

        private void FiftyButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/HelpSound.mp3"));
            mediaPlayer.Play();
            fiftyButton.IsEnabled = false;
            Button correctAnswerButton = AnswerButtons.Find(x => x.Content.ToString() == question.CorrectAnswer);
            int index = AnswerButtons.FindIndex(x => x == correctAnswerButton);
            Random random = new Random();
            int number;
            do
            {
                number = random.Next(0, 4);
            } while (number == index);
            for (int i = 0; i < AnswerButtons.Count; i++)
            {
                if (i != index && i != number)
                    AnswerButtons[i].IsEnabled = false;
            }
        }

        private void AudienceButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/HelpSound.mp3"));
            mediaPlayer.Play();
            audienceButton.IsEnabled = false;
            Random random = new Random();
            int number;
            int[] numbers = new int[4];
            Button correctAnswerButton = AnswerButtons.Find(x => x.Content.ToString() == question.CorrectAnswer);
            int APercent = 0, BPercent = 0, CPercent = 0, DPercent = 0;
            int percent1 = random.Next(0, 101);
            switch (correctAnswerButton.Name)
            {
                case "answerButton1":
                    APercent = percent1;
                    break;
                case "answerButton2":
                    BPercent = percent1;
                    break;
                case "answerButton3":
                    CPercent = percent1;
                    break;
                case "answerButton4":
                    DPercent = percent1;
                    break;
                default:
                    break;
            }
            int minNum = 1, maxNum = 5;
            if (APercent != 0 || DPercent != 0)
            {
                if (APercent != 0)
                    minNum = 2;
                else if (DPercent != 0)
                    maxNum = 4;
                for (int i = 0; i < 3; i++)
                {
                    do
                    {
                        number = random.Next(minNum, maxNum);
                    } while (numbers.Any(x => x == number));
                    numbers[i] = number;
                }
            }
            else
            {
                if (BPercent != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        do
                        {
                            number = random.Next(minNum, maxNum);
                        } while (numbers.Any(x => x == number && x == 2));
                        numbers[i] = number;
                    }
                }
                if (CPercent != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        do
                        {
                            number = random.Next(minNum, maxNum);
                        } while (numbers.Any(x => x == number && x == 3));
                        numbers[i] = number;
                    }
                }
            }

            int percent2 = random.Next(0, 101 - percent1);
            switch (numbers[0])
            {
                case 1:
                    APercent = percent2;
                    break;
                case 2:
                    BPercent = percent2;
                    break;
                case 3:
                    CPercent = percent2;
                    break;
                case 4:
                    DPercent = percent2;
                    break;
                default:
                    break;
            }

            int percent3 = random.Next(0, 101 - percent1 - percent2); ;
            switch (numbers[1])
            {
                case 1:
                    APercent = percent3;
                    break;
                case 2:
                    BPercent = percent3;
                    break;
                case 3:
                    CPercent = percent3;
                    break;
                case 4:
                    DPercent = percent3;
                    break;
                default:
                    break;
            }

            int percent4 = random.Next(0, 101 - percent1 - percent2 - percent3); ;
            switch (numbers[2])
            {
                case 1:
                    APercent = percent4;
                    break;
                case 2:
                    BPercent = percent4;
                    break;
                case 3:
                    CPercent = percent4;
                    break;
                case 4:
                    DPercent = percent4;
                    break;
                default:
                    break;
            }
            AudienceHelpWindow audienceHelpWindow = new AudienceHelpWindow(APercent, BPercent, CPercent, DPercent);
            audienceHelpWindow.ShowDialog();
        }

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/HelpSound.mp3"));
            mediaPlayer.Play();
            callButton.IsEnabled = false;
            Button correctAnswerButton = AnswerButtons.Find(x => x.Content.ToString() == question.CorrectAnswer);
            string correctAnswer = string.Empty;
            switch (correctAnswerButton.Name)
            {
                case "answerButton1":
                    correctAnswer = "A";
                    break;
                case "answerButton2":
                    correctAnswer = "B";
                    break;
                case "answerButton3":
                    correctAnswer = "C";
                    break;
                case "answerButton4":
                    correctAnswer = "D";
                    break;
                default:
                    break;
            }
            Random random = new Random();
            int questionNumber = random.Next(0, 5);
            string text = "";
            switch (questionNumber)
            {
                case 0:
                    text = "A";
                    break;
                case 1:
                    text = "B";
                    break;
                case 2:
                    text = "C";
                    break;
                case 3:
                    text = "D";
                    break;
                case 4:
                    text = correctAnswer;
                    break;
                default:
                    break;
            }
            PhoneCallWindow phoneCallWindow = new PhoneCallWindow(text);
            phoneCallWindow.ShowDialog();

        }
    }
}
