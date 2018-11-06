using MusicPlayer.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicPlayer.BassNet.Tv
{
    class TvChannelsToFill
    {
        List<TvChannels> TvList = new List<TvChannels>();

        public void TvFill()
        {
            TvList.Clear();
            string path = System.IO.Directory.GetCurrentDirectory();
            XDocument xDoc = XDocument.Load(path + @"/Data/TvChannels.xml");

            int channels = 2;
            for (int i = 1; i <= channels; i++)
            {
                TvList.Add(new TvChannels()
                {
                    //RadioPicFromCategories = xDoc.Root.Element("RecordStation" + i).Element("RadioDataIco").Value,
                    TvName = xDoc.Root.Element("Channel" + i).Element("title").Value,
                });

            }
            TvPage.Instance.RadioListView.ItemsSource = TvList;
        }
    }
}
