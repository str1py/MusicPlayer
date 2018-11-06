using MusicPlayer.Pages;
using System;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace MusicPlayer.BassNet.Radio
{
    class RadioHelper
    {
        public void ShowGif()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"pack://application:,,,/Resources/Player/RadioOn.gif", UriKind.Absolute);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(RadioPage.Instance.PlayGif, image);

        }
    }
}
