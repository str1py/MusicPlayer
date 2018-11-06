using System.Windows.Media.Imaging;

namespace MusicPlayer.BassNet.Player
{
    class BassNetDataPlayer
    {
        public static string artist { get; set; }
        public static string songName { get; set; }
        public static BitmapImage songPicture { get; set; }
        public static string songTime { get; set; }
        public static double sliderMaximum { get; set; }

        public static void SongDataClear()
        {
            artist = null;
            songName = null;
            songPicture = null;
            songTime = null;
            sliderMaximum = 0;
        }
    }
}
