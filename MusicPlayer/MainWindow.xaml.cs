using MusicPlayer.BassNet.Radio;
using MusicPlayer.Pages;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Microsoft.Speech;
using Microsoft.Speech.Recognition;

namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        Page pl = new PlayerLocal(); Page mp = new MainPage(); Page rp = new RadioPage();
        Page tp = new TvPage(); Page sp = new SettingsPage(); Page up = new UpdatePage();
        Page tw = new TwitchPage(); Page CurrentPage;

        RadioHelper rh = new RadioHelper();
        MainAppLogic.InternetConnection ic = new MainAppLogic.InternetConnection();

        DoubleAnimation animation1 = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5));
        DoubleAnimation animation2 = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));

        System.Globalization.CultureInfo nf_info = new System.Globalization.CultureInfo("ru-ru");
        SpeechRecognitionEngine sre;
   
        public MainWindow()
        {
            InitializeComponent();
            Un4seen.Bass.BassNet.Registration("stripyclear@gmail.com", "2X28183721152222");
            Instance = this;
            MainFrame.Content = mp;
            CurrentPage = mp;
            ic.TryToConnect();
            RecognitionInit();
            MessageBox.Show(sre.RecognizerInfo.Description.ToString());
        }

        async void ChangePage(Frame mainframe, Page newpage)
        {
            await Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() => mainframe.BeginAnimation(Frame.OpacityProperty, animation1)); //NOT WORKING
            })
            .ContinueWith((prevTask) =>
            {
                prevTask.Wait();
                Dispatcher.Invoke(() => MainFrame.Content = newpage);
            })
            .ContinueWith((prevTask) =>
            {
                prevTask.Wait();
                Dispatcher.Invoke(() => mainframe.BeginAnimation(Frame.OpacityProperty, animation2));
            });
        }
        private  void MainMenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (MainMenuListBox.SelectedIndex)
            {
                case 1:
                    if (MainFrame.Content != mp.Content)
                        ChangePage(MainFrame, mp);
                    break;
                case 2:
                    if (MainFrame.Content != pl.Content)
                        ChangePage(MainFrame, pl);
                    break;
                case 3:
                    if (MainFrame.Content != rp.Content)
                        ChangePage(MainFrame, rp);
                    break;
                case 4:
                    if (MainFrame.Content != tp.Content)
                        ChangePage(MainFrame, tp);
                    break;
                case 5:
                    if (MainFrame.Content != tw.Content)
                        ChangePage(MainFrame, tw);
                    break;
                case 6:
                    break;
                case 7:
                    if(MainFrame.Content != sp.Content)
                        ChangePage(MainFrame, sp);
                    break;
                case 8:
                    if(MainFrame.Content != up.Content)
                        ChangePage(MainFrame, up);
                    break;
            }
        }



        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7 && e.Result.Text == "предыдущий") //ЗАЛИПАЕТ КНОПКА

                PlayerLocal.Instance.Prev();
            else if (e.Result.Confidence > 0.7 && e.Result.Text == "включи плеер")
                PlayerLocal.Instance.Play();
            else if (e.Result.Confidence > 0.7 && e.Result.Text == "пауза")
                PlayerLocal.Instance.Pause();
            else if (e.Result.Confidence > 0.7 && e.Result.Text == "следующий")
                PlayerLocal.Instance.Next();
            else if (e.Result.Confidence > 0.7 && e.Result.Text == "продолжай")
                PlayerLocal.Instance.Play();
            else if (e.Result.Confidence > 0.7 && e.Result.Text == "громче")
                PlayerLocal.Instance.VolumeUp();
            else if (e.Result.Confidence > 0.7 && e.Result.Text == "тише")
                PlayerLocal.Instance.VolumeDown();

        }
        public void RecognitionInit()
        {
            sre = new SpeechRecognitionEngine(nf_info);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            Choices choisePlayer = new Choices();
            choisePlayer.Add(new string[] { "предыдущий", "пауза", "продолжай","следующий","громче","тише" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = nf_info;
            gb.Append(choisePlayer);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

    }
}
