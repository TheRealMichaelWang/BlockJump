using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockJump
{
    public partial class GameWindow : Form
    {
        Graphics gfx;
        Bitmap bitmap;
        Player player;
        Object floor;
        List<Object> obstacles;
        List<Object> speedups;
        List<Object> springs;
        Random random;
        public int speed;
        public int pos;
        bool died;
        Level Level;
        Font mainFont;
        int titlepos;
        int defaultspeed = 15;
        public string levelName;
        public int Percent
        {
            get
            {
                return (LevelProgress.Value *100)/ LevelProgress.Maximum;
            }
        }

        public GameWindow(string levelName)
        {
            this.levelName = levelName;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            gfx = Graphics.FromImage(bitmap);
            player = new Player(100);
            floor = new Object(0, player.SEA_LEVEL - 1, 1366, 200);
            obstacles = new List<Object>();
            speedups = new List<Object>();
            springs = new List<Object>();
            random = new Random();
            Level = new Level(levelName);
            mainFont = new Font(FontFamily.GenericMonospace, 36);
            speed = defaultspeed;
            pos = 0;
            died = false;
            RestartButton.Visible = false;
            QuitButton.Visible = false;
            Select();
            titlepos = 500;
            LevelProgress.Maximum = Level.length+80;
            MusicPlayer.PlayRandomSong();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LevelProgress.Width = Width;
            if (!Level.LevelOver)
            {
                string[] lev_comargs = Level.lastcom.Split(' ');
                if (int.Parse(lev_comargs[0]) < pos)
                {
                    if (lev_comargs[1] == "DOWN")
                    {
                        obstacles.Add(new Object(1367, player.SEA_LEVEL - 91, 90, 90));
                        Level.NextCom();
                    }
                    else if (lev_comargs[1] == "UP")
                    {
                        obstacles.Add(new Object(1367, player.SEA_LEVEL - 221, 90, 90));
                        Level.NextCom();
                    }
                    else if (lev_comargs[1] == "FLOOR")
                    {
                        obstacles.Add(new Object(1367, player.SEA_LEVEL - 1, 90, 30));
                        Level.NextCom();
                    }
                    else if (lev_comargs[1] == "SPEEDUP")
                    {
                        speedups.Add(new Object(1367, player.SEA_LEVEL - 1, 90, 30));
                        Level.NextCom();
                    }
                    else if(lev_comargs[1] == "SPRING")
                    {
                        springs.Add(new Object(1367, player.SEA_LEVEL - 1, 90, 30));
                        Level.NextCom();
                    }
                }
            }
            gfx.Clear(Color.LightGray);
            gfx.DrawString(Level.name, mainFont, Brushes.Black, titlepos, bitmap.Height / 2-100);
            gfx.DrawString(Percent.ToString()+"%", mainFont, Brushes.Black, bitmap.Width / 2 - (gfx.MeasureString(Percent.ToString() + "%", mainFont).Width / 2 - 40),30);
            if (Level.LevelOver && obstacles[obstacles.Count - 1].X < player.X && !died && Percent == 100)
            {
                gfx.DrawString("Level Completed!", mainFont, Brushes.Black, bitmap.Width / 2 - (gfx.MeasureString("Level Completed!", mainFont).Width / 2), bitmap.Height / 2);
                Level.Save();
            }
            if (died)
            {
                gfx.DrawString("Level Failed!", mainFont, Brushes.Black, bitmap.Width / 2 - (gfx.MeasureString("Level Failed!", mainFont).Width / 2), bitmap.Height / 2);
                Level.Save();
            }
            if (died || (Level.LevelOver && obstacles[obstacles.Count - 1].X < player.X && !died && Percent == 100))
            {
                RestartButton.Location = new Point(Width / 2 - (RestartButton.Width / 2), Height / 2 + 50);
                QuitButton.Location = new Point(Width / 2 - (QuitButton.Width / 2), Height / 2 + QuitButton.Height + 60);
                RestartButton.Visible = true;
                QuitButton.Visible = true;
                MusicPlayer.Stop();
            }
            player.Draw(gfx);
            floor.Draw(gfx, Brushes.Black);
            if (died || (Level.LevelOver && obstacles[obstacles.Count - 1].X < player.X && !died && Percent == 100))
            {
                if (!died)
                {
                    player.Update();
                }
            }
            else
            {
                player.Update();
                pos = pos +(speed/defaultspeed);
                try
                {
                    LevelProgress.Value = pos;
                }
                catch
                {
                    LevelProgress.Value = LevelProgress.Maximum;
                }
                titlepos = titlepos - (int)(3 * ResizeConstants.XRatio);
            }
            if (Percent > Level.highscore)
            {
                Level.highscore = Percent;
            }
            UpdateAndDrawObstacles();
            UpdateAndDrawSpeedUps();
            UpdateAndDrawSprings();
            canvas.Image = bitmap;
        }

        public void UpdateAndDrawSprings()
        {
            foreach (Object spring in springs)
            {
                spring.Draw(gfx, Brushes.Yellow);
                if(!spring.rectangle.IntersectsWith(player.rectangle))
                {
                    gfx.DrawRectangle(new Pen(Color.Orange, 3), spring.rectangle.X, spring.rectangle.Y,spring.rectangle.Width,spring.rectangle.Height);
                }
                else
                {
                    gfx.DrawRectangle(new Pen(Color.Red, 3), spring.rectangle.X, spring.rectangle.Y, spring.rectangle.Width, spring.rectangle.Height);
                    player.Jump();
                }
                if(!died)
                {
                    spring.X -= (int)(speed*ResizeConstants.XRatio);
                }
            }
        }

        public void UpdateAndDrawSpeedUps()
        {
            foreach(Object speedup in speedups)
            {
                speedup.Draw(gfx, Brushes.LightGreen);
                if(!speedup.rectangle.IntersectsWith(player.rectangle))
                {
                    gfx.DrawRectangle(new Pen(Color.DarkGreen, 3), speedup.rectangle.X, speedup.rectangle.Y, speedup.rectangle.Width, speedup.rectangle.Height);
                }
                else
                {
                    gfx.DrawRectangle(new Pen(Color.Red, 3), speedup.rectangle.X, speedup.rectangle.Y, speedup.rectangle.Width, speedup.rectangle.Height);
                    speed++;
                }
                if(!died)
                {
                    speedup.X -= (int)(speed * ResizeConstants.XRatio);
                }
            }
        }

        public void UpdateAndDrawObstacles()
        {
            foreach (Object obstacle in obstacles)
            {
                obstacle.Draw(gfx, Brushes.Blue);
                if (obstacle.rectangle.IntersectsWith(player.rectangle))
                {
                    died = true;
                    gfx.DrawRectangle(new Pen(Color.Red,3),obstacle.rectangle.X, obstacle.rectangle.Y, obstacle.rectangle.Width, obstacle.rectangle.Height);
                }
                else
                {
                    gfx.DrawRectangle(new Pen(Color.DarkBlue, 3), obstacle.rectangle.X, obstacle.rectangle.Y, obstacle.rectangle.Width, obstacle.rectangle.Height);
                }
                if (!died)
                {
                    obstacle.X = obstacle.X - (int)(speed * ResizeConstants.XRatio);
                }
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {           
                player.Jump();
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        { 
            if(died|| (Level.LevelOver && obstacles[obstacles.Count - 1].X<player.X && !died && Percent == 100))
            {
                Initialize();
                this.Select();
            }
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
            player.Jump();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (died || (Level.LevelOver && obstacles[obstacles.Count - 1].X < player.X && !died && Percent == 100))
            {
                timer.Enabled = false;
                this.Close();
            }
        }
    }
}
