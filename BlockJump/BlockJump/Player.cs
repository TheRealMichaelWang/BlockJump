using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockJump
{
    public class Player
    {
        public int X;
        public int Y;
        public int SEA_LEVEL;
        double jumpstage = -1;
        bool jumping = false;

        public bool FitToSize = true;

        public RectangleF rectangle
        {
            get
            {
                if (FitToSize)
                {
                    return new RectangleF(X * ResizeConstants.XRatio, Y * ResizeConstants.YRatio, 100 * ResizeConstants.XRatio, 100 * ResizeConstants.YRatio);
                }
                else
                {
                    return new RectangleF(X, Y, 100, 100);
                }
            }
        }
       

        public Brush brush
        {
            get
            {
                return Brushes.Red;
            }
        }

        public Player(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            SEA_LEVEL = 600;
        }

        public Player(int X)
        {
            this.X = X;
            SEA_LEVEL = 600;
            this.Y = SEA_LEVEL;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(new Pen(Color.DarkRed, 3),rectangle.X,rectangle.Y,rectangle.Width,rectangle.Height);
        }

        public void Jump()
        {
            if (!jumping)
            {
                jumping = true;
                jumpstage = 0;
            }
        }

        public void Update()
        {
            if(jumpstage!=-1)
            {
                if (jumpstage == 0)
                {
                    Y = SEA_LEVEL - 40;
                }
                else if (jumpstage == 1)
                {
                    Y = SEA_LEVEL - 60;
                }
                else if (jumpstage == 2)
                {
                    Y = SEA_LEVEL - 80;
                }
                else if (jumpstage ==  3)
                {
                    Y = SEA_LEVEL - 100;
                }
                else if (jumpstage == 4)
                {
                    Y = SEA_LEVEL - 120;
                    //do up to here
                }
                else if (jumpstage == 5)
                {
                    Y = SEA_LEVEL - 140;
                }
                else if (jumpstage == 6)
                {
                    Y = SEA_LEVEL - 160;
                }
                else if (jumpstage == 7)
                {
                    Y = SEA_LEVEL - 180;
                }
                else if (jumpstage == 8)
                {
                    Y = SEA_LEVEL - 200;
                }
                else if (jumpstage == 9)
                {
                    Y = SEA_LEVEL - 220;
                }
                else if (jumpstage == 10)
                {
                    Y = SEA_LEVEL - 240;
                }
                else if (jumpstage == 11)
                {
                    Y = SEA_LEVEL - 270;
                }
                else if (jumpstage == 12)
                {
                    Y = SEA_LEVEL - 270;
                }
                else if(jumpstage == 13)
                {
                    Y = SEA_LEVEL - 240;
                }
                else if (jumpstage == 14)
                {
                    Y = SEA_LEVEL - 220;
                }
                else if (jumpstage == 15)
                {
                    Y = SEA_LEVEL - 200;
                }
                else if (jumpstage == 16)
                {
                    Y = SEA_LEVEL - 180;
                }
                else if (jumpstage == 18)
                {
                    Y = SEA_LEVEL - 160;
                }
                else if (jumpstage == 19)
                {
                    Y = SEA_LEVEL - 140;
                }
                else if (jumpstage == 20)
                {
                    Y = SEA_LEVEL - 120;
                }
                else if (jumpstage == 21)
                {
                    Y = SEA_LEVEL - 100;
                }

                else if (jumpstage == 22)
                {
                    Y = SEA_LEVEL - 80;
                }
                else if (jumpstage == 23)
                {
                    Y = SEA_LEVEL - 60;
                }
                else if (jumpstage == 24)
                {
                    Y = SEA_LEVEL - 40;
                }
                else if(jumpstage == 25)
                {
                    Y = SEA_LEVEL;
                    jumpstage = -1;
                    jumping = false;
                    return;
                }
                jumpstage = jumpstage + 1;
            }
        }
    }
}
