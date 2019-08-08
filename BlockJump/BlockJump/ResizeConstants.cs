using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockJump
{
    public static class ResizeConstants
    {
        public static float XRatio
        {
            get
            {
                return (float)Screen.PrimaryScreen.Bounds.Width / (float)1360;
            }
        }

        public static float YRatio
        {
            get
            {
                return (float)Screen.PrimaryScreen.Bounds.Height / (float)768;
            }
        }
    }
}
