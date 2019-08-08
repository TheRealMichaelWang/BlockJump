using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockJump
{
    public class Level
    {
        string[] commands;
        int currentcom = 0;
        public string name;
        public int length;
        public string fname;
        public int highscore;

        public static string[] GetLevelList()
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            List<string> toret = new List<string>();
            foreach(string file in files)
            {
                FileInfo levelfileinfo = new FileInfo(file);
                if (levelfileinfo.Extension == ".lev")
                {
                    toret.Add(levelfileinfo.Name.Replace(".lev", ""));
                }
            }
            return toret.ToArray();
        }

        public static string GetLevelName(string levelPath)
        {
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\" + levelPath + ".lev");
            return lines[0];
        }

        public static int GetHiscore(string fname)
        {
            try
            {
                int hiscore = int.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + fname + "_levdata.dat"));
                return hiscore;
            }
            catch
            {
                return 0;
            }
        }

        public static void ResetAllScores()
        {
            foreach(string level in GetLevelList())
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + level + "_levdata.dat");
            }
        }

        public bool LevelOver
        {
            get
            {
                return (currentcom == commands.Length);
            }
        }

        public string lastcom
        {
            get
            {
                try
                {
                    return commands[currentcom];
                }
                catch
                {
                    return "";
                }
            }
        }

        public void NextCom()
        {
            currentcom++;
        }

        public Level(string name)
        {
            List<string> data = File.ReadAllLines(Environment.CurrentDirectory+"\\"+name+".lev").ToList();
            this.name = data[0];
            commands = data.GetRange(1, data.Count - 1).ToArray();
            length = int.Parse(commands[commands.Length - 1].Split(' ')[0]);
            fname = name;
            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + fname + "_levdata.dat"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + fname + "_levdata.dat").Close();
                highscore = 0;
                Save();
            }
            else
            {
                highscore = int.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + fname + "_levdata.dat"));
            }
        }

        public void Save()
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + fname + "_levdata.dat", highscore.ToString());
        }
    }
}
