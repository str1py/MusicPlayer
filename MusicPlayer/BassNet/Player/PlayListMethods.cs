using MusicPlayer.Pages;
using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace MusicPlayer.BassNet.Player
{
    class PlayListMethods : BassNetHelper
    {
        public void PlayListFill()
        {
            playlist.Clear();
            int count = Files.Count();
            for (int i = 0; i < count; i++)
            {
                var audioFile = TagLib.File.Create(Files[i]);
                if (audioFile.Tag.Pictures.Length != 0)
                {
                    if (String.IsNullOrEmpty(audioFile.Tag.FirstPerformer) == false)
                    {
                        TagLib.IPicture pic = audioFile.Tag.Pictures[0];
                        MemoryStream ms = new MemoryStream(pic.Data.Data);
                        ms.Seek(0, SeekOrigin.Begin);
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.EndInit();
                        playlist.Add(new PlayList()
                        {
                            ArtName = audioFile.Tag.FirstPerformer,
                            SongName = audioFile.Tag.Title,
                            SongTime = BassNetDataPlayer.songTime,
                            SongPict = bitmap
                        });
                    }
                    else
                    {
                        TagLib.IPicture pic = audioFile.Tag.Pictures[0];
                        MemoryStream ms = new MemoryStream(pic.Data.Data);
                        ms.Seek(0, SeekOrigin.Begin);
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.EndInit();
                        string WithOutMP3 = Path.GetFileName(Files[i]);
                        playlist.Add(new PlayList()
                        {
                            ArtName = GetSongInfo(WithOutMP3)[0],
                            SongName = GetSongInfo(WithOutMP3)[1],
                            SongTime = BassNetDataPlayer.songTime,
                            SongPict = bitmap
                        });
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(audioFile.Tag.FirstPerformer) == false)
                    {
                        BitmapImage b = new BitmapImage(new Uri("pack://application:,,,/Resources/Player/MusicDefault.png"));
                        playlist.Add(new PlayList()
                        {
                            ArtName = audioFile.Tag.FirstPerformer,
                            SongName = audioFile.Tag.Title,
                            SongTime = BassNetDataPlayer.songTime,
                            SongPict = b
                        });

                    }
                    else
                    {
                        BitmapImage b = new BitmapImage(new Uri("pack://application:,,,/Resources/Player/MusicDefault.png"));
                        string WithOutMP3 = Path.GetFileName(Files[i]);
                        playlist.Add(new PlayList()
                        {
                            ArtName = GetSongInfo(WithOutMP3)[0],
                            SongName = GetSongInfo(WithOutMP3)[1],
                            SongTime = BassNetDataPlayer.songTime,
                            SongPict = b
                        });

                    }
                }
            }
            PlayerLocal.Instance.PlayList.ItemsSource = playlist;
        }

        protected string[] GetSongInfo(string SongName)
        {
            string[] words = SongName.Split(new char[] { '-' });
            for (int i = 0; i < words.Count(); i++)
            {
                if (words[i].Contains(".mp3"))
                    words[i] = words[i].Remove(words[i].Length - 4);

                words[i] = words[i].Trim();
            }
            return words;
        }

        public void ClearPlayList()
        {
            playlist.Clear();
            PlayerLocal.Instance.PlayList.ItemsSource = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
