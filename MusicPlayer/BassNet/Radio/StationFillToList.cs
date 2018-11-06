using MusicPlayer.Pages;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MusicPlayer.BassNet.Radio
{
    class StationFillToList
    {
        List<Stations> StationsList = new List<Stations>();
        string path { get; set; } = System.IO.Directory.GetCurrentDirectory();


        public void RecordStationsFill()
        {
            StationsList.Clear();
            XDocument xDoc = XDocument.Load(path + @"/Data/RecordStations.xml");

            int station = 71; //Почему 71? - 71 станция рекорда          
            for (int i = 1; i <= station; i++)
            {
                StationsList.Add(new Stations() { RadioNameFromCategories = xDoc.Root.Element("RecordStation" + i).Element("title").Value,  });
            }
            RadioPage.Instance.RadioListView.ItemsSource = StationsList;
        }
        public void MoscowStationsFill()
        {
            StationsList.Clear();
            XDocument xDoc1 = XDocument.Load(path + @"/Data/MoscowRadioStations.xml");
            int station = 6;
            for (int i = 1; i <= station; i++)
            {
                StationsList.Add(new Stations() { RadioNameFromCategories = xDoc1.Root.Element("MRS" + i).Element("title").Value });
            }
            RadioPage.Instance.RadioListView.ItemsSource = StationsList;
        }
        public void BBCStationsFill()
        {
            StationsList.Clear();
            XDocument xDoc2 = XDocument.Load(path + @"/Data/BBCRadioStations.xml");

            int station = 13;
            for (int i = 1; i <= station; i++)
            {
                StationsList.Add(new Stations()
                {
                    RadioNameFromCategories = xDoc2.Root.Element("BBCRadio" + i).Element("title").Value
                });
            }
            RadioPage.Instance.RadioListView.ItemsSource = StationsList;
        }
    }
}
