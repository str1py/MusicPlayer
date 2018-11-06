using MusicPlayer.Pages;
using MusicPlayer.MainAppLogic;
using System;
using System.Xml.Linq;
using Un4seen.Bass.AddOn.Tags;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Drawing;

namespace MusicPlayer.BassNet.Radio
{
    class StationToPlay
    {
        System.Windows.Threading.DispatcherTimer UpdateStationInfo = new System.Windows.Threading.DispatcherTimer();
        string path { get; set; } = Directory.GetCurrentDirectory();
        public static string StationName { get; set; }
        public static string TrackName { get; set; }
        public static string TrackArtist { get; set; }
        public static string TrackGenre { get; set; }
        public static ImageSource TrackPicture { get; set; }
        public static string ChannelInfo { get; set; }
        public static string URL { get; set; }

        public static bool IsSongChanged { get; set; }
        public static string SongImageLink { get; set; }
        public static string ImageLink { get; set; }
        public static System.Drawing.Color BlurColor { get; set; }

        System.Windows.Threading.DispatcherTimer ChangeTimer = new System.Windows.Threading.DispatcherTimer();
        List<string> allColors = new List<string>();

        bool isColorFill { get; set; } = false;
        bool isTimerStart { get; set; } = false;
        int colorChange { get; set; } = 1000;
        System.Windows.Media.Brush brush { get; set; }
        System.Windows.Media.Color color { get; set; }

        System.Windows.Media.Effects.DropShadowEffect shadowEffectHigh = new System.Windows.Media.Effects.DropShadowEffect();
        System.Windows.Media.Effects.DropShadowEffect shadowEffectLow = new System.Windows.Media.Effects.DropShadowEffect();


        public void Getindex(int stationindex, int stationgroup)
        {
            if (stationgroup == 0)
            {
                XDocument xDoc = XDocument.Load(path + @"/Data/RecordStations.xml");

                if (MainVars.RadioQuality == true) //true = HQ  false=LQ
                    URL = xDoc.Root.Element("RecordStation" + (stationindex + 1)).Element("linkHQ").Value;
                else if (MainVars.RadioQuality == false)
                    URL = xDoc.Root.Element("RecordStation" + (stationindex + 1)).Element("linkLQ").Value; 
                StationName = xDoc.Root.Element("RecordStation" + (stationindex + 1)).Element("title").Value;
                SongImageLink = "https://www.radiorecord.ru/xml/" + xDoc.Root.Element("RecordStation" + (stationindex + 1)).Element("ImageWord").Value + "_online_v8.txt";
                GetImageLink(SongImageLink);
                timerStart();
                ChangeTimerStart();
            }
            if (stationgroup == 1)
            {
                XDocument xDoc = XDocument.Load(path + @"/Data/MoscowRadioStations.xml");
                URL = xDoc.Root.Element("MRS" + (stationindex + 1)).Element("link").Value;
                StationName = xDoc.Root.Element("MRS" + (stationindex + 1)).Element("title").Value;
                timerStart();
                ChangeTimerStart();
            }
            if (stationgroup == 2)
            {
                XDocument xDoc = XDocument.Load(path + @"/Data/BBCRadioStations.xml");
                URL = xDoc.Root.Element("BBCRadio" + (stationindex + 1)).Element("link").Value;
                StationName = xDoc.Root.Element("BBCRadio" + (stationindex + 1)).Element("title").Value;
                timerStart();
                ChangeTimerStart();
            }
        }
 
        public void GetStationInfo()
        {
            TAG_INFO tagInfo = new TAG_INFO(URL);
            if (BassTags.BASS_TAG_GetFromURL(BassNetHelper.Stream, tagInfo))
            {
                if (TrackArtist != tagInfo.artist && TrackName != tagInfo.title)
                {
                    TrackArtist = tagInfo.artist;
                    TrackName = tagInfo.title;
                    TrackGenre = tagInfo.genre;
                    if (tagInfo.bpm == "") { ChannelInfo = "Bitrate : " + tagInfo.bitrate; }
                    else { ChannelInfo = "Bitrate : " + tagInfo.bitrate + "kBit/sec   Bpm : " + tagInfo.bpm; }
                    GetImageLink(SongImageLink);
                    IsSongChanged = true;
                }
                else       
                    IsSongChanged = false;        
            }
            else { TrackArtist = "No Data"; TrackName = "No Data"; }

        }

        private void timerStart()
        {
            UpdateStationInfo.Tick += new EventHandler(timerTick);
            UpdateStationInfo.Interval = new TimeSpan(0, 0, 0, 30, 0);
            UpdateStationInfo.Start();
        }
        public void timerStop()
        {
            UpdateStationInfo.Stop();
        }
        public void timerTick(object sender, EventArgs e)
        {
            GetStationInfo();
            if (IsSongChanged == true)
                RadioPage.Instance.SetStationInfo();
        }

        /// Download and Convert Radio Image
        private void GetImageLink(string link)
        {
            string txt1;
            using (WebClient ftpClient = new WebClient()) {
                try  {
                    txt1 = ftpClient.DownloadString(new Uri(link));
                    dynamic stuff = JsonConvert.DeserializeObject(txt1);
                    if (stuff.image600 != null)  {
                        txt1 = stuff.image600;
                        txt1 = txt1.Replace('\\', ' ');
                        ImageLink = txt1;
                        LoadImage();
                    }
                    else  {
                        Uri imagePlayUri = (new Uri(@"pack://application:,,,/MusicPlayer/Radio/Categories/record.jpg", UriKind.Absolute));
                        TrackPicture = new BitmapImage(imagePlayUri);
                    }
                }
                catch { }
            }
        }
        public async void LoadImage()
        {
            WebClient ftpClient = new WebClient();
            byte[] imgbyte = await ftpClient.DownloadDataTaskAsync(new Uri(ImageLink));

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imgbyte))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            TrackPicture = image;

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(image));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);
                GetBlurColor(bitmap);
            }       
        }
        public void GetBlurColor(Image img)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            int total = 0;
            using (Bitmap bmp = new Bitmap(img))
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        System.Drawing.Color clr = bmp.GetPixel(x, y);

                        r += clr.R;
                        g += clr.G;
                        b += clr.B;

                        total++;
                    }
                }
                r /= total;
                g /= total;
                b /= total;

                r = r * 2;
                g = g * 2;
                b = b * 2;
                while(r>249)  
                    r = r - 10;
                while (g > 249)
                    g = g - 10;
                while (b > 249)
                    b = b - 10;
                BlurColor = System.Drawing.Color.FromArgb(r , g , b );

            }
       
        }

        // Blur Color Changer
        public void ColorChanger()
        {
            if (BassNetHelper.buffer[0] < 0.00 || BassNetHelper.buffer[0] > 0.25)
                shadowEffectLow.BlurRadius = Math.Round(BassNetHelper.buffer[0], 2) * 120;

            if (BassNetHelper.buffer[0] < 0.25)
                shadowEffectHigh.BlurRadius = Math.Round(BassNetHelper.buffer[0], 2) * 200;


            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(StationToPlay.BlurColor.A, StationToPlay.BlurColor.R, StationToPlay.BlurColor.G, StationToPlay.BlurColor.B);
            brush = new SolidColorBrush(newColor);
            shadowEffectLow.Color = newColor;
            shadowEffectHigh.Color = newColor;

            RadioPage.Instance.ChangeBorderColor(brush, shadowEffectLow, shadowEffectHigh, 2);
        }

        private void ChangeTimerStart()
        {
            ChangeTimer.Tick += new EventHandler(ChangeTimerTick);
            ChangeTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ChangeTimer.Start();
        }
        private void ChangeTimerStop()
        {
            ChangeTimer.Stop();
            isTimerStart = false;
        }
        public void ChangeTimerTick(object sender, EventArgs e)
        {
            ColorChanger();
        }

    }
}
