using HtmlAgilityPack;
using MusicPlayer.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.MainAppLogic.Weather
{
    class WeatherTommorow
    {
        System.Windows.Threading.DispatcherTimer UpdateWeatherInfo = new System.Windows.Threading.DispatcherTimer();
        public static List<string> temp = new List<string>();
        public static string Osadki;
        public static string tempMax;
        public static string tempMin;
        public static string windMax;
        public static string windMin;
        public static string discription;
        bool isTimerOn = false;

        public void GetWeatherTommorow()
        {
            temp.Clear();
            if (isTimerOn == false)
            {
                TimerStart();
                isTimerOn = true;
            }
            Stream responseStream = null;
            try
            {
                WebRequest request = WebRequest.Create("https://www.meteoservice.ru/weather/tomorrow/moskva");
                WebResponse webResponse = request.GetResponse();
                responseStream = webResponse.GetResponseStream();
            }
            catch { }

            HtmlDocument doc = new HtmlDocument();
            doc.Load(responseStream, Encoding.UTF8);

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(".//div[@class='stat ']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//span[@class='value']"))
                {
                    temp.Add(node2.InnerText);
                }
            }
            tempMin = temp[4];
            tempMax = temp[5];
            windMin = temp[6];
            windMax = temp[7];
            tempMin = tempMin.Replace("&deg;", "");
            tempMax = tempMax.Replace("&deg;", "");

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(".//div[@class='stat precip-prob']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//div[@class='bar']"))
                {
                    foreach (HtmlNode node3 in node.SelectNodes(".//span[@class='value']"))
                    {
                        Osadki = node3.InnerText;
                    }
                }
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(".//div[@class='column text-left']"))
            {
                temp.Add(node.InnerText);
            }

            discription = temp[12];
        }

        private void TimerStart()
        {
            UpdateWeatherInfo.Tick += new EventHandler(timerTick);
            UpdateWeatherInfo.Interval = new TimeSpan(0, 0, 10, 0);
            UpdateWeatherInfo.Start();
        }
        private void timerStop()
        {

        }
        public void timerTick(object sender, EventArgs e)
        {
            GetWeatherTommorow();
            MainPage.Instance.SetWearherTommorow();
        }
    }
}
