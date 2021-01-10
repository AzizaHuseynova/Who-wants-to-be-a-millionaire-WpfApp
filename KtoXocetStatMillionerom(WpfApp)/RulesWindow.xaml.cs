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
    /// Логика взаимодействия для RulesWindow.xaml
    /// </summary>
    public partial class RulesWindow : Window
    {
        List<Question> Questions;
        public RulesWindow(ref List<Question> Questions)
        {
            InitializeComponent();
            this.Questions = Questions;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(ref Questions);
            gameWindow.ShowDialog();
            this.Close();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
