using HtmlAgilityPack;
using MusicPlayer.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace MusicPlayer.MainAppLogic.Weather
{
    class WeatherToday
    {
        System.Windows.Threading.DispatcherTimer UpdateWeatherInfo = new System.Windows.Threading.DispatcherTimer();
        public static string cloudiness;
        public static string temp;
        public static string feeltemp;
        public static string wind;
        public static string humidity;
        public static string weatherImage;
        bool isTimerOn = false;


        public void GetWeatherNow()
        {
            HtmlDocument doc = new HtmlDocument();
            Stream responseStream = null;
            if (isTimerOn==false)
            {
                TimerStart();
                isTimerOn = true;
            }

            try
            {
                WebRequest request =  WebRequest.Create("http://www.meteoservice.ru/weather/now/moskva.html");
                WebResponse webResponse = request.GetResponse();
                responseStream = webResponse.GetResponseStream();
                doc.Load(responseStream, Encoding.UTF8); //error
            }
            catch  { }

           
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='temperature']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//span[@class]"))
                {
                    temp = node2.InnerText;
                }
            }
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='h5 feeled-temperature']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//span[@class]"))
                {
                    feeltemp = node2.InnerText;
                }
            }
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//p[@class='margin-bottom-0']"))
            {
                cloudiness = node.InnerText;
            }
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='h5 margin-bottom-0']"))
            {
                humidity = node.InnerText;
            }    
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='small-5 medium-5 columns']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//div[@class='h5 margin-bottom-0']"))
                {
                    wind = node2.InnerText;
                    wind = wind.Replace("\n", "");
                    wind = wind.Replace("\t", "");
                    wind = wind.Replace("&nbsp;", "");
                    wind.Trim();
                }
                
            }
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='small-4 medium-4 columns']"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//div[@class='h5 margin-bottom-0']"))
                {
                    humidity = node2.InnerText;
                }
            }
            temp = temp.Replace("&deg;", "");
            feeltemp = feeltemp.Replace("&deg;", "");
            switch (cloudiness)
            {
                case "Значительная облачность":
                    weatherImage = "VeryCloud.png";
                        break;
                case "Облачно":
                    weatherImage = "Cloud.png";
                    break;
                case "Малооблачно":
                    weatherImage = "Cloud.png";
                    break;
                case "Ясно, ясно":
                    weatherImage = "Sun.png";
                    break;
                case "Ясно":
                    weatherImage = "Sun.png";
                    break;
                case "Значительная облачность, облачно":
                    weatherImage = "VeryCloud.png";
                    break;
                case null:
                    weatherImage = "Cloud.png";
                    break;
                    //Сплошная облачность без просветов, небольшой дождь, возможна гроза
                    //Малооблачно, слабые осадки
                    //Малооблачно
                    //Облачно, малооблачно, кучевые облака
            }
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
            GetWeatherNow();
            MainPage.Instance.SetWearher();    
        }
    }
}
