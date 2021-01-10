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
using System.Windows.Shapes;

namespace KtoXocetStatMillionerom_WpfApp_
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        List<Question> Questions;
        Question NewQuestion { get; set; }
        public QuestionWindow(ref List<Question> Questions, Question question)
        {
            InitializeComponent();
            hardLevelComboBox.ItemsSource = new int[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            this.Questions = Questions;
            NewQuestion = question;
            if (question != null)
            {
                addButton.Content="SAVE";
                questionTextbox.Text = question.Text;
                answer1TextBox.Text = question.CorrectAnswer;
                answer2TextBox.Text = question.IncorrectAnswer1;
                answer3TextBox.Text = question.IncorrectAnswer2;
                answer4TextBox.Text = question.IncorrectAnswer3;
                hardLevelComboBox.SelectedItem = question.HardLevel as object;
            }

        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(questionTextbox.Text.Trim()) || String.IsNullOrEmpty(answer1TextBox.Text.Trim()) || String.IsNullOrEmpty(answer2TextBox.Text.Trim())
                || String.IsNullOrEmpty(answer3TextBox.Text.Trim()) || String.IsNullOrEmpty(answer4TextBox.Text.Trim()) || hardLevelComboBox.SelectedItem == null)
                MessageBox.Show("You must fill in all of the fields", "Exclamation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else if (answer1TextBox.Text == answer2TextBox.Text || answer1TextBox.Text == answer3TextBox.Text || answer1TextBox.Text == answer4TextBox.Text || answer2TextBox.Text == answer3TextBox.Text || answer2TextBox.Text == answer4TextBox.Text || answer3TextBox.Text == answer4TextBox.Text)
                MessageBox.Show("Answers are repeated", "Exclamation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                if (NewQuestion != null)
                {
                    Questions.Remove(NewQuestion);
                    Questions.Add(new Question { Text = questionTextbox.Text, CorrectAnswer = answer1TextBox.Text, IncorrectAnswer1 = answer2TextBox.Text, IncorrectAnswer2 = answer3TextBox.Text, IncorrectAnswer3 = answer4TextBox.Text, HardLevel = (int)hardLevelComboBox.SelectedItem });
                    this.Close();
                }
                else
                {
                    Questions.Add(new Question { Text = questionTextbox.Text, CorrectAnswer = answer1TextBox.Text, IncorrectAnswer1 = answer2TextBox.Text, IncorrectAnswer2 = answer3TextBox.Text, IncorrectAnswer3 = answer4TextBox.Text, HardLevel = (int)hardLevelComboBox.SelectedItem });
                    questionTextbox.Clear();
                    answer1TextBox.Clear();
                    answer2TextBox.Clear();
                    answer3TextBox.Clear();
                    answer4TextBox.Clear();
                    hardLevelComboBox.SelectedItem = null;
                }
            }
        }

    }
}
