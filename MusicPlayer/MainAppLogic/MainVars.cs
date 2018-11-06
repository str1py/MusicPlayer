using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MusicPlayer.MainAppLogic
{
    class MainVars
    {
        public bool isWindowMaximaze { get; set; } = false;
        public static bool InternetConnection { get; set; }
        public static bool IsMusicOn { get; set; } = false;
        public static bool IsRadioOn { get; set; } = false;
        public static bool IsTvOn { get; set; } = false;
        public static bool IsTwitchOn { get; set; } = false;
        public static bool RadioQuality { get; set; } = true; // true-good //false-bad

        public static List<string> ftracks = new List<string>();

        public static bool isTelegramPhoneCorrect { get; set; }
        public static int TelegramUserID { get; set; }
        public static bool isTelegramLogicSeccused { get; set; }
        public static string SongNameTlgrm { get; set; }

        public static string UserCommand { get; set; }
        public static string CommandToAction { get; set; }
        public static string AnastasiaAnswer { get; set; }
        public static string SongName { get; set; }

        public static string GifPath { get; set; }
        public static string Genres { get; set; }
    }
}