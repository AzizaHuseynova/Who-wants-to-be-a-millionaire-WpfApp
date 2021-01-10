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
    /// Логика взаимодействия для AudienceHelpWindow.xaml
    /// </summary>
    public partial class AudienceHelpWindow : Window
    {
        MediaPlayer mediaPlayer;
        int Aheight;
        int Bheight;
        int Cheight;
        int Dheight;

        public AudienceHelpWindow(int Aheight, int Bheight, int Cheight, int Dheight)
        {
            InitializeComponent();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("C:/Users/Азиза/source/repos/KtoXocetStatMillionerom(WpfApp)/KtoXocetStatMillionerom(WpfApp)/AudienceSound.mp3"));
            mediaPlayer.Play();
            Arectangle.Height = Aheight;
            Brectangle.Height = Bheight;
            Crectangle.Height = Cheight;
            Drectangle.Height = Dheight;

            APercentLabel.Content = $"  {Aheight}%";
            BPercentLabel.Content = $" {Bheight}%";
            CPercentLabel.Content = $" {Cheight}%";
            DPercentLabel.Content = $" {Dheight}%";

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            this.Close();
        }
    }
}
