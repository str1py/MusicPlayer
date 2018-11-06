using MusicPlayer.MainAppLogic;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MusicPlayer.BassNet.Player
{
    class GetFullMusicInfo : BassNetHelper
    {
            public static void GetTrackInfo()
            {
                BassNetDataPlayer.SongDataClear();
                var audioFile = TagLib.File.Create(Files[CurrentTrackNumber]);
                if (audioFile.Tag.Pictures.Length != 0)
                {
                    TagLib.IPicture pic = audioFile.Tag.Pictures[0];
                    MemoryStream ms = new MemoryStream(pic.Data.Data);
                    ms.Seek(0, SeekOrigin.Begin);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    BassNetDataPlayer.songPicture = bitmap;
                }
                else
                {
                    Uri imagePlayUri = (new Uri(@"pack://application:,,,/Resources/Player/MusicDefault.png", UriKind.Absolute));
                    BassNetDataPlayer.songPicture = new BitmapImage(imagePlayUri);
                }
                if (String.IsNullOrEmpty(audioFile.Tag.FirstPerformer) == false)
                {
                    BassNetDataPlayer.artist = audioFile.Tag.FirstPerformer;
                    BassNetDataPlayer.songName = audioFile.Tag.Title;
                    MainVars.SongName = "Song: " + audioFile.Tag.FirstPerformer + " - " + audioFile.Tag.Title;
                }
                else
                {
                    string WithOutMP3 = Path.GetFileName(Files[CurrentTrackNumber]);
                    BassNetDataPlayer.artist = WithOutMP3.Substring(0, WithOutMP3.Length - 4);
                    MainVars.SongName = "Song:" + WithOutMP3.Substring(0, WithOutMP3.Length - 4);
                }
                    BassNetDataPlayer.songTime = TimeSpan.FromSeconds(GetTimeOfStream(Stream)).ToString();
                    BassNetDataPlayer.sliderMaximum = GetTimeOfStream(Stream);
            }
        }
}
