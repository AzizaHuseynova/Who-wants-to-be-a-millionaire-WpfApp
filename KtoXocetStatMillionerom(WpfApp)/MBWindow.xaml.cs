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
    /// Логика взаимодействия для ChooWindow1.xaml
    /// </summary>
    public partial class MBWindow : Window
    {
        List<Question> Questions;
        public MBWindow(string text, ref List<Question> Questions)
        {
            InitializeComponent();
            textBlock.Text = text;
            this.Questions = Questions;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(ref Questions);
            this.Close();
            gameWindow.ShowDialog();
        }
    }
}
