using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для EditQuWindow.xaml
    /// </summary>
    public partial class EditQuWindow : Window
    {
        List<Question> Questions;
        bool flag = true;
        public EditQuWindow(ref List<Question> Questions)
        {
            InitializeComponent();
            hardLevelComboBox.ItemsSource = new int[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            editButton.IsEnabled = false;
            removeButton.IsEnabled = false;
            this.Questions = Questions;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HardLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Question> findQuestions = Questions.FindAll(x => x.HardLevel.Equals((int)(hardLevelComboBox.SelectedItem)));
            if (findQuestions != null)
            {
                questionsListBox.ItemsSource = findQuestions;
            }
        }

        private void QuestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (questionsListBox.Items.Count == 1 && questionsListBox.SelectedIndex == 0)
            {
                removeButton.Click -= RemoveButton_Click;
                removeButton.Click += RemoveButton_Click2;
                flag = false;
            }
            else if (!flag)
            {
                removeButton.Click -= RemoveButton_Click2;
                removeButton.Click += RemoveButton_Click;
                flag = true;
            }
            if (questionsListBox.SelectedItem != null)
                editButton.IsEnabled = true;
            else
                editButton.IsEnabled = false;
            if (questionsListBox.SelectedItem != null)
                removeButton.IsEnabled = true;
            else
                removeButton.IsEnabled = false;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionWindow questionWindow = new QuestionWindow(ref Questions, Questions.Find(x => x == questionsListBox.SelectedItem as Question));
            questionWindow.ShowDialog();
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Questions.Remove(questionsListBox.SelectedItem as Question);
            List<Question> findQuestions = Questions.FindAll(x => x.HardLevel.Equals((int)(hardLevelComboBox.SelectedItem)));
            if (findQuestions != null)
            {
                questionsListBox.ItemsSource = findQuestions;
            }
        }

        private void RemoveButton_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can't delete the last question of the level, because for the correct operation of the game, at each level at least one question is needed. Try edit question.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
