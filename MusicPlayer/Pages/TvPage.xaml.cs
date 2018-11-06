using MusicPlayer.BassNet.Tv;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MusicPlayer.Pages
{
    /// <summary>
    /// Логика взаимодействия для TvPage.xaml
    /// </summary>
    public partial class TvPage : Page
    {
        public static TvPage Instance;
        TvChannelsToFill fill = new TvChannelsToFill();
        public TvPage()
        {
            Instance = this;
            InitializeComponent();
            InitCategories();
        }

        public void InitCategories()
        {
            fill.TvFill();
        }

        private void PlayTV_Click(object sender, RoutedEventArgs e)
        {
            MediaTV.Source = new Uri("http://iptv.multi-net.ru:80/udp/239.255.1.12:1234");
            MediaTV.LoadedBehavior = MediaState.Manual;
            MediaTV.Play();
        }

        private void StopTV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DownTvList_Click(object sender, RoutedEventArgs e)
        {
            ShowHideRadioMenu("sbTvListHide", DownTvList, UpTvList, TvGrid);
        }

        private void UpTvList_Click(object sender, RoutedEventArgs e)
        {
            ShowHideRadioMenu("sbTvListShow", DownTvList, UpTvList, TvGrid);
        }

        private void ShowHideRadioMenu(string Storyboard, System.Windows.Controls.Button btnHide, System.Windows.Controls.Button btnShow, Grid pnl)
        {
            Storyboard sb = FindResource(Storyboard) as Storyboard;

            sb.Begin(pnl);

            if (Storyboard.Contains("Show")) //⬆⬆
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide")) //⬇⬇
            {
                btnShow.Visibility = System.Windows.Visibility.Visible;
                btnHide.Visibility = System.Windows.Visibility.Hidden;
            }
        }





    }
}
