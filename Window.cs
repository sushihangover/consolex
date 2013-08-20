using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleX
{
    public abstract class Window
    {
        private CursesSharp.Window window;

        private readonly IDictionary<char, Color> ColorLegend = new Dictionary<char, Color>() {
            { 'k', Color.Black },
            { 'b', Color.DarkBlue },
            { 'g', Color.DarkGreen },
            { 'c', Color.DarkCyan },
            { 'r', Color.DarkRed },
            { 'p', Color.DarkPurple },
            { 'y', Color.DarkYellow },
            { 'e', Color.DarkGrey },
            { 'E', Color.Grey },
            { 'B', Color.Blue },
            { 'G', Color.Green },
            { 'C', Color.Cyan },
            { 'R', Color.Red },
            { 'P', Color.Purple },
            { 'Y', Color.Yellow },
            { 'W', Color.White }
        };

        public Window()
        {
            this.window = new CursesSharp.Window(MainConsole.Height, MainConsole.Width, 0, 0);
        }

        public static implicit operator CursesSharp.Window(Window window)
        {
            return window.window;
        }

        /// <summary>
        /// Displays some ASCII art on the main console. Parameters are two: the content file
        /// (the characters to display), and a colour map file (one character represents a color).        
        /// </summary>
        /// <param name="contentFile">The content to display on screen; must be 80x25</param>
        /// <param name="colorMapFile">The colour map. See Window.ColorLEgend for mappings.</param>
        public void DisplayAsciiArt(string contentFile, string colorMapFile)
        {
            string content = File.ReadAllText(contentFile).Replace("\n", "").Replace("\r", "");
            string colorMap = File.ReadAllText(colorMapFile).Replace("\n", "").Replace("\r", "");

            for (int y = 0; y < MainConsole.Height; y++)
            {
                for (int x = 0; x < MainConsole.Width; x++)
                {
                    int index = (y * MainConsole.Width) + x;
                    char colorChar = colorMap[index];
                    if (ColorLegend.ContainsKey(colorChar))
                    {
                        MainConsole.Instance.Color = ColorLegend[colorChar];
                    }
                    else
                    {
                        MainConsole.Instance.Color = Color.DarkGrey;
                    }
                    
                    MainConsole.Instance.Write(x, y, content[index]);
                }
            }
        }

        public abstract void Run();
    }
}
