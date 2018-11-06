using MusicPlayer.MainAppLogic;
using MusicPlayer.MainAppLogic.Weather;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static MainPage Instance;

        System.Windows.Threading.DispatcherTimer ClockTimer = new System.Windows.Threading.DispatcherTimer();
        bool ClockSeparatorVisibility { get; set; }
        WeatherToday weather = new WeatherToday();
        WeatherTommorow weatherTom = new WeatherTommorow();
        CultureInfo rus = new CultureInfo("ru-RU");
        InternetConnection ic = new InternetConnection();

        DoubleAnimation AnimClockHigh = new DoubleAnimation(0.1, 1.1, TimeSpan.FromSeconds(1));
        DoubleAnimation AnimClockDown = new DoubleAnimation(1.1, 0.1, TimeSpan.FromSeconds(1));

        DoubleAnimation AnimSepHigh = new DoubleAnimation(0.1, 1.1, TimeSpan.FromSeconds(1));
        DoubleAnimation AnimSepDown = new DoubleAnimation(1.1, 0.1, TimeSpan.FromSeconds(1));

        DoubleAnimation AnimWeatherHigh = new DoubleAnimation(0.0, 1.1, TimeSpan.FromSeconds(1));
        DoubleAnimation AnimWeatherkDown = new DoubleAnimation(1.0, 0.0, TimeSpan.FromSeconds(1));
        public MainPage()
        {
            InitializeComponent();
            TimerStart();
            ClockSeparatorVisibility = false;
            Instance = this;
            ic.TryToConnect();
            DataSet();
        }

        public async void DataSet() //Для вывода погоды на сегодня/завтра
        {
            if (MainVars.InternetConnection == true)
            {
                await Task.Factory.StartNew(() =>
                {
                    Dispatcher.Invoke(() => WeatherLoadGrid.Visibility = Visibility.Visible);
                    Dispatcher.Invoke(() => WeatherNoData.Visibility = Visibility.Hidden);
                    weather.GetWeatherNow();
                    weatherTom.GetWeatherTommorow();
                }).ContinueWith((prevTask) =>
                {
                    prevTask.Wait();
                    Dispatcher.Invoke(() => LoadInfo.Content = "Еще чуть-чуть...");
                    Thread.Sleep(1000);
                }).ContinueWith((prevTask) =>
                {
                    prevTask.Wait();
                    Dispatcher.Invoke(() => SetWearherTommorow());
                    Dispatcher.Invoke(() => SetWearher());
                }).ContinueWith((prevTask) =>
                {
                    prevTask.Wait();
                    Dispatcher.Invoke(() => WeatherLoadGrid.Visibility = Visibility.Hidden);
                }).ContinueWith((prevTask) =>
                {
                    prevTask.Wait();
                    Dispatcher.Invoke(() => WeatherTodayGrid.Visibility = Visibility.Visible);
                    Dispatcher.Invoke(() => WeatherTodayGrid.BeginAnimation(Grid.OpacityProperty, AnimWeatherHigh));
                });
            }
            else
            {
                WeatherLoadGrid.Visibility = Visibility.Hidden;
                WeatherNoData.Visibility = Visibility.Visible;
            }
        }
        public void SetWearher()
        {
            Temp.Content = WeatherToday.temp;
            FeelTemp.Content = WeatherToday.feeltemp;
            Cloudiness.Content = WeatherToday.cloudiness;
            Wind.Content = WeatherToday.wind;
            Humidity.Content = WeatherToday.humidity;
            if (WeatherToday.weatherImage != null)
                WeatherImg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Weather/" + WeatherToday.weatherImage));

        }//Получение погоды на сегодня
        public void SetWearherTommorow()
        {

            TempMin.Content = WeatherTommorow.tempMin;
            TempMax.Content = WeatherTommorow.tempMax;
            WindDefault.Content = WeatherTommorow.windMin;
            WindMax.Content = WeatherTommorow.windMax;
            Osadki.Content = WeatherTommorow.Osadki;
            WeatherDiscription.Content = WeatherTommorow.discription;

        }//Получение погоды на завтра

        private void TimerStart()
        {
            ClockTimer.Tick += new EventHandler(timerTick);
            ClockTimer.Interval = new TimeSpan(0, 0, 0, 1);
            ClockTimer.Start();
        }
        private void timerStop()
        {
            ClockTimer.Stop();
            ClockTimer.IsEnabled = false;
        }
        public async void timerTick(object sender, EventArgs e)
        {

            if (ClockSeparatorVisibility == false)
            {
                ClockSeparate.BeginAnimation(Label.OpacityProperty, AnimSepDown);
                ClockSeparatorVisibility = true;
            }
            else
            {
                ClockSeparate.BeginAnimation(Label.OpacityProperty, AnimSepHigh);
                ClockSeparatorVisibility = false;
            }

            string clock = DateTime.Now.ToShortTimeString();
            string[] Time = clock.Split(':');
             
            string day = rus.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            day = char.ToUpper(day[0]) + day.Substring(1);
            int dayofweek = DateTime.Today.Day;
            string month = rus.DateTimeFormat.GetMonthName(DateTime.Today.Month);



            string[] TimeOld = new string[2];
            TimeOld[0] = ClockHours.Content.ToString();
            TimeOld[1] = ClockMinutes.Content.ToString();


            if (Time[0] != TimeOld[0])
            {
                await Task.Factory.StartNew(() =>
                {
                    Dispatcher.Invoke(() => ClockHours.BeginAnimation(Label.OpacityProperty, AnimClockDown)); //NOT WORKING
                })
                .ContinueWith((prevTask) =>
                {
                    prevTask.Wait();
                    Dispatcher.Invoke(() => ClockHours.Content = Time[0]);
                    })
                .ContinueWith((prevTask) =>
                {
                    prevTask.Wait();
                    Dispatcher.Invoke(() => ClockHours.BeginAnimation(Label.OpacityProperty, AnimClockHigh));
                });

            }
            else if (Time[1] != TimeOld[1])
            {
                await Task.Factory.StartNew(() =>
                {
                    Dispatcher.Invoke(() => ClockMinutes.BeginAnimation(Label.OpacityProperty, AnimClockDown)); //NOT WORKING
               })
               .ContinueWith((prevTask) =>
               {
                   prevTask.Wait();
                   Dispatcher.Invoke(() => ClockMinutes.Content = Time[1]);
               })
               .ContinueWith((prevTask) =>
               {
                   prevTask.Wait();
                   Dispatcher.Invoke(() => ClockMinutes.BeginAnimation(Label.OpacityProperty, AnimClockHigh));
               });
            }
            else if (Time[0] != TimeOld[0] && Time[1] != TimeOld[1])
            {
                await Task.Factory.StartNew(() =>
                {
                    Dispatcher.Invoke(() => ClockMinutes.BeginAnimation(Label.OpacityProperty, AnimClockDown));
                    Dispatcher.Invoke(() => ClockHours.BeginAnimation(Label.OpacityProperty, AnimClockDown));
                })
           .ContinueWith((prevTask) =>
           {
               prevTask.Wait();
               Dispatcher.Invoke(() => ClockMinutes.Content = Time[1]);
               Dispatcher.Invoke(() => ClockHours.Content = Time[0]);
           })
           .ContinueWith((prevTask) =>
           {
               prevTask.Wait();
               Dispatcher.Invoke(() => ClockMinutes.BeginAnimation(Label.OpacityProperty, AnimClockHigh));
               Dispatcher.Invoke(() => ClockHours.BeginAnimation(Label.OpacityProperty, AnimClockHigh));
           });
            }

            DayOfWeek.Content = day;
            Month.Content = month + ", " + dayofweek;
        }

        private async void ToTomorrowWeather_Click(object sender, RoutedEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() => WeatherTodayGrid.BeginAnimation(Grid.OpacityProperty, AnimWeatherkDown));
                Dispatcher.Invoke(() => WeatherTodayGrid.Visibility = Visibility.Hidden);
            }).ContinueWith((prevTask) =>
            {
                prevTask.Wait();
                Dispatcher.Invoke(() => WeatherTommorowGrid.Visibility = Visibility.Visible);
                Dispatcher.Invoke(() => WeatherTommorowGrid.BeginAnimation(Grid.OpacityProperty, AnimWeatherHigh));
            });
        }
        private async void ToTodayWeather_Click(object sender, RoutedEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() => WeatherTommorowGrid.BeginAnimation(Grid.OpacityProperty, AnimWeatherkDown));
                Dispatcher.Invoke(() => WeatherTommorowGrid.Visibility = Visibility.Hidden);
            }).ContinueWith((prevTask) =>
            {
                prevTask.Wait();
                Dispatcher.Invoke(() => WeatherTodayGrid.Visibility = Visibility.Visible);
                Dispatcher.Invoke(() => WeatherTodayGrid.BeginAnimation(Grid.OpacityProperty, AnimWeatherHigh));
            });
        }

        private void WeatherUpdate_Click(object sender, RoutedEventArgs e)
        {
            ic.TryToConnect();
            DataSet();
        }
    }
}
