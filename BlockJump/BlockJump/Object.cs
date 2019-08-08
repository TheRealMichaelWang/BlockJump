using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockJump
{
    public enum ObjectType
    {
        Floor,
        Obstacle,
        SpeedUp
    }

    public class Object
    {
        public int X;
        public int Y;
        public int WIDTH;
        public int HEIGHT;
        public bool FitToSize = true;

        public RectangleF rectangle
        {
            get
            {
                if (FitToSize)
                {
                    return new RectangleF(X * ResizeConstants.XRatio, Y * ResizeConstants.YRatio, WIDTH * ResizeConstants.XRatio, HEIGHT * ResizeConstants.YRatio);
                }
                else
                {
                    return new RectangleF(X, Y, WIDTH, HEIGHT);
                }
            }
        }

        public Object(int X, int SEA_LEVEL, int WIDTH, int HEIGHT)
        {
            this.X = X;
            this.Y = SEA_LEVEL+100;
            this.WIDTH = WIDTH;
            this.HEIGHT = HEIGHT;
        }

        public Object(int X, int Y, int WIDTH, int HEIGHT, bool param=false)
        {
            this.X = X;
            this.Y = Y;
            this.WIDTH = WIDTH;
            this.HEIGHT = HEIGHT;
        }

        public void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillRectangle(brush, rectangle);
        }
    }
}
