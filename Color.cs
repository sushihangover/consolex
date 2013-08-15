using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleX
{
    public class Color
    {
        private short cursesColor;
        private Boolean useBold;

        public static Color Black = new Color(1, false);
        public static Color DarkBlue = new Color(2, false);
        public static Color DarkGreen = new Color(3, false);
        public static Color DarkCyan = new Color(4, false);
        public static Color DarkRed = new Color(5, false);
        public static Color DarkPurple = new Color(6, false);
        public static Color DarkYellow = new Color(7, false);
        public static Color Grey = new Color(8, false);
        public static Color DarkGrey = new Color(1, true);  // 9 doesn't work, oddly.
        public static Color Blue = new Color(10, true);
        public static Color Green = new Color(11, true);
        public static Color Cyan = new Color(12, true);
        public static Color Red = new Color(13, true);
        public static Color Purple = new Color(14, true);
        public static Color Yellow = new Color(15, true);
        public static Color White = new Color(16, true);

        public Color(short cursesColor, bool useBold)
        {
            this.cursesColor = cursesColor;
            this.useBold = useBold;
        }

        public static implicit operator short(Color c)
        {
            return c.cursesColor;
        }

        public int CursesColor { get { return this.cursesColor; } }
        public bool UseBold { get { return this.useBold; } }
    }
}
