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
    public partial class LevelEditor : Form
    {
        public FileInfo file;
        public bool opened;
        public bool saved;
        public string fname;
        public Graphics levelDrawer_gfx;
        public Bitmap levelDrawer_bitmap;

        public LevelEditor()
        {
            InitializeComponent();
            opened = false;
            saved = true;
            OpenSaveButton.Text = "Open Lev";
            NewLevelButton.Text = "New Level";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            WindowState = FormWindowState.Maximized;
            levelDrawer_bitmap = new Bitmap(LevelDrawer.Width, LevelDrawer.Height);
            levelDrawer_gfx = Graphics.FromImage(levelDrawer_bitmap);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LevelDrawer.Width = Width - 120;
            textBox.Width = Width;
            textBox.Height = Height - 80;
            DrawLevel();
        }

        public void DrawLevel()
        {
            levelDrawer_gfx.Clear(Color.LightGray);
            string[] lines = textBox.Lines;
            if(lines.Length == 0)
            {
                LevelDrawer.Image = levelDrawer_bitmap;
                return;
            }
            try
            {
                int width = LevelDrawer.Width / int.Parse(lines[lines.Length - 1].Split(' ')[0])-1;
                levelDrawer_gfx.FillRectangle(Brushes.Black, new Rectangle(0, LevelDrawer.Height - 24, LevelDrawer.Width, LevelDrawer.Height - 30));
                int cline = 0;
                foreach (string line in lines)
                {
                    string[] args = line.Split(' ');
                    if (cline != 0)
                    {
                        int pos = int.Parse(args[0]);
                        string type = args[1];
                        if(type == "DOWN")
                        {
                            levelDrawer_gfx.FillRectangle(Brushes.Blue, new Rectangle(pos * width, LevelDrawer.Height - 44, 20, 20));
                        }
                        else if(type == "UP")
                        {
                            levelDrawer_gfx.FillRectangle(Brushes.Blue, new Rectangle(pos * width, LevelDrawer.Height - 64, 20, 20));
                        }
                        else if(type == "FLOOR")
                        {
                            levelDrawer_gfx.FillRectangle(Brushes.Blue, new Rectangle(pos * width, LevelDrawer.Height - 24, 20, 7));
                        }
                        else if(type == "SPEEDUP")
                        {
                            levelDrawer_gfx.FillRectangle(Brushes.Green, new Rectangle(pos * width, LevelDrawer.Height - 24, 20, 7));
                        }
                        else if(type == "SPRING")
                        {
                            levelDrawer_gfx.FillRectangle(Brushes.Yellow, new Rectangle(pos * width, LevelDrawer.Height - 24, 20, 7));
                        }
                    }
                    cline++;
                }
            }
            catch
            {

            }
            LevelDrawer.Image = levelDrawer_bitmap;
        }

        private void OpenSaveButton_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                File.WriteAllText(fname, textBox.Text);
                saved = true;
            }
            else if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(fname);
                opened = true;
                saved = true;
                OpenSaveButton.Text = "Save Lev";
                NewLevelButton.Text = "Close Lev";
            }
        }

        private void NewLevelButton_Click(object sender, EventArgs e)
        {
            if(opened)
            {
                if(!saved)
                {
                    if(MessageBox.Show("Are you sure you want to close this file without saving it?","BlockJump Level Editor Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                fname = "";
                saved = true;
                opened = false;
                textBox.Text = "";
                OpenSaveButton.Text = "Open Lev";
                NewLevelButton.Text = "New Level";
            }
            else
            {
                fname = CreateNewLevel("untitled");
                opened = true;
                NewLevelButton.Text = "Close Lev";
                OpenSaveButton.Text = "Save Lev";
            }
        }

        private string CreateNewLevel(string name, int count = 0)
        {
            string fname = name;
            if(count != 0)
            {
                fname += count.ToString();
            }
            fname += ".lev";
            if(File.Exists(Environment.CurrentDirectory+"\\"+fname))
            {
                return CreateNewLevel(name, count + 1);
            }
            else
            {
                File.Create(Environment.CurrentDirectory + "\\" + fname).Close();
                File.WriteAllText(Environment.CurrentDirectory + "\\" + fname,name);
                textBox.Text = name;
                return Environment.CurrentDirectory + "\\" + fname;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void LevelDrawer_SizeChanged(object sender, EventArgs e)
        {
            levelDrawer_bitmap = new Bitmap(LevelDrawer.Width, LevelDrawer.Height);
            levelDrawer_gfx = Graphics.FromImage(levelDrawer_bitmap);
        }
    }
}
