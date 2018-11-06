using System.Windows.Media.Imaging;

namespace MusicPlayer.BassNet.Player
{
    class PlayList
    {
        public BitmapImage SongPict { get; set; }
        public string ArtName { get; set; }
        public string SongName { get; set; }
        public string Album { get; set; }
        public string SongTime { get; set; }

        public override string ToString() => this.ArtName + ", " + this.SongName;
    }
}
