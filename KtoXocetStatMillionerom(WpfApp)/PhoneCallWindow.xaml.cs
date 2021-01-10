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
    /// Логика взаимодействия для PhoneCallWindow.xaml
    /// </summary>
    public partial class PhoneCallWindow : Window
    {
        MediaPlayer mediaPlayer;
        public PhoneCallWindow(string text)
        {
            InitializeComponent();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/PhoneCallSound.mp3"));
            mediaPlayer.Play();
            Text.Text += text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            this.Close();
        }
    }
}
