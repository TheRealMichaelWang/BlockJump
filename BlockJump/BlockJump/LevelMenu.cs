using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockJump
{
    public partial class LevelMenu : Form
    {
        Graphics gfx;
        Bitmap bitmap;
        Font level_font;
        GameWindow gameWindow;
        bool maximize_gamewindow;
        public int range;
        public int page = 0;

        public LevelMenu()
        {
            InitializeComponent();
            bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
            gfx = Graphics.FromImage(bitmap);
            level_font = new Font(FontFamily.GenericMonospace,28);
            maximize_gamewindow = true;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            range = (Width - 70) / 50;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.LightGray);
            DrawLevels();
            canvas.Image = bitmap;
        }

        public void DrawLevels()
        {
            gfx.FillRectangle(Brushes.Blue, new Rectangle(0, 20, Width/2, 49));
            gfx.DrawRectangle(new Pen(Brushes.Red, 3), new Rectangle(0, 20, Width/2, 49));
            gfx.DrawString("Import A Level", level_font, Brushes.Black, new Rectangle(0,20, Width/2, 49));
            gfx.FillRectangle(Brushes.Blue, new Rectangle(Width/2+1, 20, Width/2, 49));
            gfx.DrawRectangle(new Pen(Brushes.Red, 3), new Rectangle(Width/2+1, 20, Width/2, 49));
            gfx.DrawString("Quit Game", level_font, Brushes.Black, new Rectangle(Width/2+1, 20, Width/2, 49));
            gfx.FillRectangle(Brushes.Blue, new Rectangle(0, Height-50, Width, 49));
            gfx.DrawRectangle(new Pen(Brushes.Red, 3), new Rectangle(0,Height - 50, Width, 49));
            gfx.DrawString("Page: "+(page+1)+". Use Left Arrow and Right Arrow to navigate pages", level_font, Brushes.Black, new Rectangle(0,Height-50, Width, 49));
            string[] levels = Level.GetLevelList();
            for (int i = page *range; i < Math.Min(page*range+range,levels.Length); i++)
            {
                gfx.FillRectangle(Brushes.Blue, new Rectangle(0, i * 50+70, Width, 49));
                gfx.DrawRectangle(new Pen(Brushes.Red,3), new Rectangle(0, i * 50+70, Width, 49));
                gfx.DrawString(Level.GetLevelName(levels[i])+"  "+Level.GetHiscore(levels[i])+"%", level_font, Brushes.Black, new Rectangle(0, i * 50+70, Width, 49));
            }
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point newpoint = me.Location;
            Rectangle importrect = new Rectangle(0, 20, Width / 2, 49);
            Rectangle quitrect = new Rectangle(Width / 2 + 1, 20, Width / 2, 49);
            if (importrect.Contains(newpoint))
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(openFileDialog.FileName);
                    File.Copy(openFileDialog.FileName, Environment.CurrentDirectory + "\\"+info.Name);
                    MessageBox.Show("Remember, you can right click a level to delete it.", "Info");
                }
                return;
            }
            else if(quitrect.Contains(newpoint))
            {
                this.Close();
                return;
            }
            string[] levels = Level.GetLevelList();
            for (int i = page * range; i < Math.Min(page * range + range, levels.Length); i++)
            {
                Rectangle rectangle = new Rectangle(0, i * 50 + 70, Width, 49);
                if (rectangle.Contains(newpoint))
                {
                    if (me.Button == MouseButtons.Left)
                    {
                        PlayLevel(levels[i]);
                        MusicPlayer.PlayRandomSong();
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to delete the level, " + Level.GetLevelName(levels[i]), "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            File.Delete(Environment.CurrentDirectory + "\\" + levels[i] + ".lev");
                        }
                    }
                    break;
                }
            }
        }

        public void PlayLevel(string levelname)
        {
            gameWindow = new GameWindow(levelname);
            if(maximize_gamewindow)
            { 
                gameWindow.FormBorderStyle = FormBorderStyle.None;
                gameWindow.WindowState = FormWindowState.Maximized;
            }
            this.Hide();
            timer.Enabled = false;
            gameWindow.ShowDialog();
            timer.Enabled = true;
            this.Show();
        }

        private void LevelMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                if(page!=0)
                {
                    page--;
                }
            }
            else if(e.KeyCode == Keys.Right)
            {
                if(page+1*range <= Level.GetLevelList().Length)
                {
                    page++;
                }
            }
        }
    }
}
