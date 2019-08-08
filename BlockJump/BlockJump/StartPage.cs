using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockJump
{
    public partial class StartPage : Form
    {
        LevelMenu levelMenu;
        LevelEditor levelEditor;
        Graphics gfx;
        Bitmap bitmap;
        Player player;
        Object floor;
        Object obstacle;
        long pos;
        bool summon_obstacle;
        Rectangle leveleditor_button;
        Rectangle playbutton;
        Rectangle helpbutton;
        StringFormat button_format;
        Font button_font;
        Font title_font;

        public StartPage()
        {
            InitializeComponent();
            levelMenu = new LevelMenu();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            bitmap = new Bitmap(startImage.Width, startImage.Height);
            gfx = Graphics.FromImage(bitmap);
            player = new Player(25,250);
            player.SEA_LEVEL = 250;
            floor = new Object(0, 250, Width, 100);
            obstacle = new Object(Width, 160, 100, 90);
            player.FitToSize = false;
            obstacle.FitToSize = false;
            floor.FitToSize = false;
            pos = 0;
            summon_obstacle = false;
            leveleditor_button = new Rectangle(Width / 2 - 110, Height / 2 - 25, 200, 50);
            helpbutton = new Rectangle(Width / 2 - 110, Height / 2 - 80, 200, 50);
            playbutton = new Rectangle(Width / 2 - 110, Height / 2 - 135, 200, 50);
            button_font = new Font(FontFamily.GenericMonospace, 30);
            button_format = new StringFormat();
            button_format.Alignment = StringAlignment.Center;
            title_font = button_font;
            MusicPlayer.PlayRandomSong();
        }

        private void StartImage_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if(playbutton.Contains(me.Location))
            {
                this.Hide();
                timer.Enabled = false;
                levelMenu.ShowDialog();
                this.Close();
            }
            else if(leveleditor_button.Contains(me.Location))
            {
                this.Hide();
                levelEditor = new LevelEditor();
                levelEditor.ShowDialog();
                this.Show();
            }
            else if(helpbutton.Contains(me.Location))
            {
                Process.Start("notepad.exe", Environment.CurrentDirectory + "\\help.txt");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(pos%70 == 0)
            {
                summon_obstacle = true;
                obstacle.X = Width;
            }
            if(obstacle.X == 175)
            {
                player.Jump();
            }
            if(summon_obstacle)
            {
                if(obstacle.X <= -obstacle.WIDTH)
                {
                    summon_obstacle = false;
                }
                obstacle.X = obstacle.X - 15;
            }
            player.Update();
            gfx.Clear(Color.LightGray);
            floor.Draw(gfx, Brushes.Black);
            player.Draw(gfx);
            obstacle.Draw(gfx, Brushes.Blue);
            gfx.DrawRectangle(new Pen(Color.DarkBlue, 3), obstacle.rectangle.X, obstacle.rectangle.Y, obstacle.rectangle.Width, obstacle.rectangle.Height);
            gfx.FillRectangle(Brushes.Blue, leveleditor_button);
            gfx.FillRectangle(Brushes.Blue, playbutton);
            gfx.FillRectangle(Brushes.Blue, helpbutton);
            gfx.DrawRectangle(new Pen(Color.Red, 3), leveleditor_button);
            gfx.DrawRectangle(new Pen(Color.Red, 3), playbutton);
            gfx.DrawRectangle(new Pen(Color.Red, 3), helpbutton);
            gfx.DrawString("Play", button_font, Brushes.Black, playbutton,button_format);
            gfx.DrawString("Editor", button_font, Brushes.Black, leveleditor_button, button_format);
            gfx.DrawString("Help", button_font, Brushes.Black, helpbutton, button_format);
            gfx.DrawString("BLOCK JUMP", title_font,Brushes.Black, new Point(Width/2-10, 10),button_format);
            startImage.Image = bitmap;
            pos++;
        }
    }
}
