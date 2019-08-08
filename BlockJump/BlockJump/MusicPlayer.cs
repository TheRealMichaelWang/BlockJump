using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace BlockJump
{
    public class MusicPlayer
    {
        public static SoundPlayer player;

        public static int CurrentSongNumber = 0;

        public static Random random = new Random();

        public static string[] Songs
        {
            get
            {
                List<string> toret = new List<string>();
                string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
                foreach(string file in files)
                {
                    if(file.EndsWith(".wav"))
                    {
                        toret.Add(file);
                    }
                }
                return toret.ToArray();
            }
        }

        public static void Stop()
        {
            if(player!=null)
            {
                player.Stop();
            }
        }

        public static void PlayRandomSong()
        {
            if (player != null)
            {
                player.Stop();
            }
            if(Songs.Length == 0)
            {
                return;
            }
            CurrentSongNumber = random.Next(0, Songs.Length);
            player = new SoundPlayer(Songs[CurrentSongNumber]);
            player.Play();
            CurrentSongNumber++;
        }

        public static void PlaySong(string name)
        {
            if (player != null)
            {
                player.Stop();
            }
            player = new SoundPlayer(Environment.GetFolderPath(Environment.SpecialFolder
                .MyMusic)+"\\"+name+".wav");
            player.Play();
        }
    }
}
