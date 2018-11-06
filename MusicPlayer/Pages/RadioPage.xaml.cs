using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using MusicPlayer.BassNet;
using MusicPlayer.BassNet.Radio;
using MusicPlayer.MainAppLogic;

namespace MusicPlayer.Pages
{
    /// <summary>
    /// Логика взаимодействия для RadioPage.xaml
    /// </summary>
    public partial class RadioPage : Page
    {
        public static RadioPage Instance;
        List<RadioCategories> Categories = new List<RadioCategories>();
        StationFillToList fill = new StationFillToList();
        BassNetHelper bass = new BassNetHelper();
        StationToPlay ps = new StationToPlay();
        ChangeColorRadioLogo ccl = new ChangeColorRadioLogo();
        InternetConnection ic = new InternetConnection();
        DoubleAnimation AnimHigh = new DoubleAnimation(0.1, 1.1, TimeSpan.FromSeconds(1));
        DoubleAnimation AnimDown = new DoubleAnimation(1.1, 0.1, TimeSpan.FromSeconds(1));

        Random rand = new Random();

        public RadioPage()
        {
            InitializeComponent();
            Instance = this;
            InitCategories();
        }

        public void InitCategories()
        {
            Categories.Add(new RadioCategories()
            {
                RadioName = "Record Radio",
                RadioPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Radio/Categories/record.jpg"))
            });
            Categories.Add(new RadioCategories()
            {
                RadioName = "Russian Radios",
                RadioPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Radio/Categories/rus.jpg"))
            });
            Categories.Add(new RadioCategories()
            {
                RadioName = "BBC Radio",
                RadioPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Radio/Categories/bbc.png"))
            });
            Categories.Add(new RadioCategories()
            {
                RadioName = "Custom Radios",
                RadioPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Radio/Categories/custom.jpg"))
            });
            RadioPage.Instance.RadioCategoriesList.ItemsSource = Categories;
        }
        public async void ChangeBorderColor(Brush brush, System.Windows.Media.Effects.DropShadowEffect effectlow, System.Windows.Media.Effects.DropShadowEffect effecthigh, double opacity )
        {
            await Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() => RadioLogoLow.BorderBrush = brush);
                Dispatcher.Invoke(() => RadioLogoLow.Effect = effectlow);
                Dispatcher.Invoke(() => RadioLogoLow.Opacity = opacity);
                Dispatcher.Invoke(() => RadioLogoHigh.BorderBrush = brush);
                Dispatcher.Invoke(() => RadioLogoHigh.Effect = effecthigh);
                Dispatcher.Invoke(() => RadioLogoHigh.Opacity = opacity);
            })
                 .ContinueWith((prevTask) =>
                 {
                     prevTask.Wait();
                     //Dispatcher.Invoke(() => RadioLogoBack.BorderBrush.BeginAnimation(Border.OpacityProperty, AnimHigh));
                 });
        }
        public void AddStations(string station)
        {
            RadioListView.Items.Add(station);
        }
        public async void SetStationInfo()
        {
            await Task.Factory.StartNew(() =>
                     {
                         Dispatcher.Invoke(() => RadioName.BeginAnimation(Label.OpacityProperty, AnimDown)); //NOT WORKING
                         Dispatcher.Invoke(() => RadioArtist.BeginAnimation(Label.OpacityProperty, AnimDown)); //NOT WORKING
                         Dispatcher.Invoke(() => RadioSongName.BeginAnimation(Label.OpacityProperty, AnimDown)); //NOT WORKING
                         Dispatcher.Invoke(() => RadioInfo.BeginAnimation(Label.OpacityProperty, AnimDown)); //NOT WORKING
                         Dispatcher.Invoke(() => RadioLogo.BeginAnimation(Image.OpacityProperty, AnimDown)); //NOT WORKING
                     })
                    .ContinueWith((prevTask) =>
                    {
                        prevTask.Wait();
                        Dispatcher.Invoke(() => ClearStationInfo());
                        Dispatcher.Invoke(() => RadioName.Content = StationToPlay.StationName);
                        Dispatcher.Invoke(() => RadioArtist.Content = StationToPlay.TrackArtist);
                        Dispatcher.Invoke(() => RadioSongName.Content = StationToPlay.TrackName);
                        Dispatcher.Invoke(() => RadioInfo.Content = StationToPlay.ChannelInfo);
                        Dispatcher.Invoke(() => RadioLogo.Source = StationToPlay.TrackPicture); 
                    })
                    .ContinueWith((prevTask) =>
                    {
                        prevTask.Wait();
                        Dispatcher.Invoke(() => RadioName.BeginAnimation(Label.OpacityProperty, AnimHigh));
                        Dispatcher.Invoke(() => RadioArtist.BeginAnimation(Label.OpacityProperty, AnimHigh));
                        Dispatcher.Invoke(() => RadioSongName.BeginAnimation(Label.OpacityProperty, AnimHigh));
                        Dispatcher.Invoke(() => RadioInfo.BeginAnimation(Label.OpacityProperty, AnimHigh));
                        Dispatcher.Invoke(() => RadioLogo.BeginAnimation(Image.OpacityProperty, AnimHigh));
                    });
        }
        void ClearStationInfo()
        {
            RadioName.Content = null;
            RadioArtist.Content = null;
            RadioSongName.Content = null;
            RadioInfo.Content = null;
        }

        private void RadioCategoriesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RadioListView.ItemsSource = null;
            RadioListView.Items.Clear();

            switch (RadioCategoriesList.SelectedIndex)
            {
                case 0:
                    fill.RecordStationsFill();
                    break;
                case 1:
                    fill.MoscowStationsFill();
                    break;
                case 2:
                    fill.BBCStationsFill();
                    break;
            }
        }
        private void RadioListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainVars.InternetConnection == true)
            {
                PlayRadio.Visibility = Visibility.Hidden;
                StopRadio.Visibility = Visibility.Visible;
                ps.Getindex(RadioListView.SelectedIndex, RadioCategoriesList.SelectedIndex);
                bass.PlayFromURL(StationToPlay.URL, Properties.Settings.Default.UserVolume);
                ps.GetStationInfo();
                SetStationInfo();
            }
            else
            {
                RadioError();
            }
        }

        private void PlayRadio_Click(object sender, RoutedEventArgs e)
        {
            bass.PlayFromURL(StationToPlay.URL, Properties.Settings.Default.UserVolume);
            PlayRadio.Visibility = Visibility.Hidden;
            StopRadio.Visibility = Visibility.Visible;
            PlayGif.Visibility = Visibility.Visible;
        }
        private void StopRadio_Click(object sender, RoutedEventArgs e)
        {
            PlayRadio.Visibility = Visibility.Visible;
            StopRadio.Visibility = Visibility.Hidden;
            bass.StopUrlStream();
            PlayGif.Visibility = Visibility.Hidden;

        }

        private void RadioVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BassNetHelper.SetStreamVolume(BassNetHelper.Stream, (float)RadioVolume.Value);
            Properties.Settings.Default.UserVolume = (float)RadioVolume.Value;
        }

        private void HighQ_Checked(object sender, RoutedEventArgs e)
        {
            MainVars.RadioQuality = true;
            ps.Getindex(RadioListView.SelectedIndex, RadioCategoriesList.SelectedIndex);
            bass.PlayFromURL(StationToPlay.URL, Properties.Settings.Default.UserVolume);
            ps.GetStationInfo();
            SetStationInfo();
        }
        private void LowQ_Checked(object sender, RoutedEventArgs e)
        {
            MainVars.RadioQuality = false;
            ps.Getindex(RadioListView.SelectedIndex, RadioCategoriesList.SelectedIndex);
            bass.PlayFromURL(StationToPlay.URL, Properties.Settings.Default.UserVolume);
            ps.GetStationInfo();
            SetStationInfo();
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
        private void UpRadioList_Click(object sender, RoutedEventArgs e)
        {
            ShowHideRadioMenu("sbRadioListShow", DownRadioList, UpRadioList, RadioListsGrid);
        }
        private void DownRadioList_Click(object sender, RoutedEventArgs e)
        {
            ShowHideRadioMenu("sbRadioListHide", DownRadioList, UpRadioList, RadioListsGrid);
        }
        
        public async void RadioError()
        {
            await Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() => ErrorRadio.Visibility = Visibility.Visible);
                Thread.Sleep(2000);
                Dispatcher.Invoke(() => ErrorBar.Visibility = Visibility.Visible);
                Dispatcher.Invoke(() => ErrorLabel.Visibility = Visibility.Visible);
                ic.TryToConnect();
            }).ContinueWith((prevTask) =>
            {
                prevTask.Wait();
                if (MainVars.InternetConnection == true)
                {
                    Dispatcher.Invoke(() => ErrorLabel.Content = "Найдено пару интернетов...");
                    Thread.Sleep(2000);
                    Dispatcher.Invoke(() => ErrorLabel.Content = "Вроде все окей");
                    Thread.Sleep(2000);
                    Dispatcher.Invoke(() => ErrorRadio.Visibility = Visibility.Hidden);
                    Dispatcher.Invoke(() => ErrorBar.Visibility = Visibility.Hidden);
                    Dispatcher.Invoke(() => ErrorLabel.Visibility = Visibility.Hidden);
                }
                else
                {
                    ErrorLabel.Content = "Нет интернета...";
                    Dispatcher.Invoke(() => ErrorRadio.Visibility = Visibility.Hidden);
                    Dispatcher.Invoke(() => ErrorBar.Visibility = Visibility.Hidden);
                    Dispatcher.Invoke(() => ErrorLabel.Visibility = Visibility.Hidden);
                }
            });
        }

    }
}
