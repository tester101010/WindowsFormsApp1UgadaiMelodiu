using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WindowsFormsApp1UgadaiMelodiu
{
    static class Victorina
    {
        public static List<string> list = new List<string>();

        public static int gameDuration = 60;
        public static int musicDuration = 10;
        public static bool randomStart = false;
        public static string lastFolder = "";
        public static bool allDirectories = false;

        public static void ReadMusic()
        {
            string[] music_files = Directory.GetFiles(lastFolder, "*mp3", allDirectories ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);
            Victorina.list.Clear();
            Victorina.list.AddRange(music_files);
            //listBox1.Items.Clear();
            //listBox1.Items.AddRange(music_list);
        }

        static string regKeyName = "Software\\MySomeCompanyName\\MusicVictorina";

        public static void ReadParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKeyName);
                if (rk != null)
                {
                    lastFolder = (string)rk.GetValue("lastFolder");
                    gameDuration = (int)rk.GetValue("GameDuration");
                    randomStart = Convert.ToBoolean(rk.GetValue("RandomStart", false));
                    musicDuration = (int)rk.GetValue("MusicDuration");
                    allDirectories = Convert.ToBoolean(rk.GetValue("AllDirectories", false));
                }
            }
            finally
            {

                if (rk != null)
                {
                    rk.Close();
                }
            }
        }

        public static void WriteParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKeyName);
                if (rk == null) return;
                rk.SetValue("lastFolder", lastFolder);
                rk.SetValue("RandomStart", randomStart);
                rk.SetValue("GameDuration", gameDuration);
                rk.SetValue("MusicDuration", musicDuration);
                rk.SetValue("AllDirectories", allDirectories);
            }
            finally
            {

                if (rk != null)
                {
                    rk.Close();
                }
            }
        }
    }
}
