using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace KtoXocetStatMillionerom_WpfApp_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Question> Questions;
        public MainWindow()
        {
            InitializeComponent();
            Questions = new List<Question>();
            LoadQuestions();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow(ref Questions);
            rulesWindow.ShowDialog();
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionWindow questionWindow = new QuestionWindow(ref Questions, null);
            questionWindow.ShowDialog();
        }

        private void EditQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            EditQuWindow editQuWindow = new EditQuWindow(ref Questions);
            editQuWindow.ShowDialog();
        }

        private void SaveQuestions()
        {
            var json = JsonConvert.SerializeObject(Questions);
            File.WriteAllText("Questions.json", json);
        }

        private void LoadQuestions()
        {
            var json = File.ReadAllText("Questions.json");
            Questions = JsonConvert.DeserializeObject<List<Question>>(json);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveQuestions();
            base.OnClosing(e);
        }
    }
}
