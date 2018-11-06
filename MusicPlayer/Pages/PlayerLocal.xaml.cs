using MusicPlayer.BassNet;
using MusicPlayer.BassNet.Player;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlayerLocal.xaml
    /// </summary>
    public partial class PlayerLocal : Page
    {
        public static PlayerLocal Instance;
        private bool dragStarted = false;

        BassNetHelper bass = new BassNetHelper();

        public PlayerLocal()
        {
            InitializeComponent();
            Un4seen.Bass.BassNet.Registration("stripyclear@gmail.com", "2X28183721152222");
            Instance = this;
        }

        #region DataSet
        public void SetSongInfo()
        {
            MusicArtistPlayer.Content = BassNetDataPlayer.artist;
            SongNamePlayer.Content = BassNetDataPlayer.songName;
            MusicSongPicturePlayer.Source = BassNetDataPlayer.songPicture;
            AllTimePlayer.Content = BassNetDataPlayer.songTime;
            SliderTrackPlayer.Maximum = BassNetDataPlayer.sliderMaximum;
        }

        #endregion
        #region Player
        private void PlayerNext_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }
        public void Next()
        {
            bass.NextSongButton();
            SetSongInfo();
        }

        private void PlayerPrev_Click(object sender, RoutedEventArgs e)
        {
            Prev();
        }
        public void Prev()
        {
            bass.PreviousSongButton();
            SetSongInfo();
        }

        private void PlayerPlay_Click(object sender, RoutedEventArgs e)
        {
            Play();
        }
        public  void Play()
        {
            PlayerPlay.Visibility = Visibility.Hidden;
            PlayerPause.Visibility = Visibility.Visible;
            bass.PlayButton();
            SetSongInfo();
        }

        private void PlayerPause_Click(object sender, RoutedEventArgs e)
        {
            Pause();
        }
        public void Pause()
        {
            bass.StopButton();
            PlayerPlay.Visibility = Visibility.Visible;
            PlayerPause.Visibility = Visibility.Hidden;
        }

        private void PlayList_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            bass.PlayFromPlayListByIndex(PlayList.SelectedIndex);
            SetSongInfo();
        }

        private void SliderTrackPlayer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (dragStarted == true)
                BassNetHelper.SetPosOfScroll(BassNetHelper.Stream, SliderTrackPlayer.Value);
        }
        private void SliderTrackPlayer_DragStarted(object sender, RoutedEventArgs e) => this.dragStarted = true;
        private void SliderTrackPlayer_DragCompleted(object sender, RoutedEventArgs e) => this.dragStarted = false;

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BassNetHelper.SetStreamVolume(BassNetHelper.Stream, (float)SliderVolume.Value);
            Properties.Settings.Default.UserVolume = (float)SliderVolume.Value;
        }

        public void VolumeUp()
        {
            float volup = (float)SliderVolume.Value + 10;
            BassNetHelper.SetStreamVolume(BassNetHelper.Stream, volup);
            Properties.Settings.Default.UserVolume = volup;
            SliderVolume.Value = volup;
        }
        public void VolumeDown()
        {
            float voldown = (float)SliderVolume.Value - 10;
            BassNetHelper.SetStreamVolume(BassNetHelper.Stream, voldown);
            Properties.Settings.Default.UserVolume = voldown;
            SliderVolume.Value = voldown;
        }
        #endregion
    }
}
