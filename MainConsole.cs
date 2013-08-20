using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursesSharp;

namespace ConsoleX
{
    public class MainConsole : IDisposable
    {
        private CursesSharp.Window currentWindow;
        private Color currentColor;

        private static MainConsole instance = new MainConsole();

        public static MainConsole Instance { get { return instance; } }

        private MainConsole()
        {
            Curses.InitScr();
            Curses.StartColor();
            
            Curses.InitPair(1, Colors.BLACK, Colors.BLACK);
            Curses.InitPair(2, Colors.BLUE, Colors.BLACK);
            Curses.InitPair(3, Colors.GREEN, Colors.BLACK);
            Curses.InitPair(4, Colors.CYAN, Colors.BLACK);
            Curses.InitPair(5, Colors.RED, Colors.BLACK);
            Curses.InitPair(6, Colors.MAGENTA, Colors.BLACK);
            Curses.InitPair(7, Colors.YELLOW, Colors.BLACK);
            Curses.InitPair(8, Colors.WHITE, Colors.BLACK);
            Curses.InitPair(9, Colors.WHITE, Colors.BLACK);
            Curses.InitPair(10, Colors.BLUE, Colors.BLACK);
            Curses.InitPair(11, Colors.GREEN, Colors.BLACK);
            Curses.InitPair(12, Colors.CYAN, Colors.BLACK);
            Curses.InitPair(13, Colors.RED, Colors.BLACK);
            Curses.InitPair(14, Colors.MAGENTA, Colors.BLACK);
            Curses.InitPair(15, Colors.YELLOW, Colors.BLACK);
            Curses.InitPair(16, Colors.WHITE, Colors.BLACK);            

            this.currentWindow = Curses.StdScr;
        }

        public void Clear()
        {
            this.currentWindow.Clear();
        }

        public void Dispose()
        {
            Curses.EndWin();
        }

        public void Refresh()
        {
            this.currentWindow.Refresh();
        }

        public void Write(int x, int y, string text)
        {
            if (x == 79 && y == 24)
            {
                // There's a bug in CursesSharp. This sucks down our performance, but, I dunno.
                // Alternatively, just always use Box() and hide this character, or don't draw it.
                // The exception occurs, but the character still draws.
                try
                {
                    this.currentWindow.Add(y, x, text);
                }
                catch
                {
                }
            }
            else
            {
                // Black doesn't show
                if (this.currentColor != Color.Black)
                {
                    this.currentWindow.Add(y, x, text);
                }
            }
        }

        public Color Color { set {

            currentColor = value;
            this.currentWindow.Color = (short)currentColor;
            var colorAsShort = (short)currentColor;

            if (currentColor.UseBold)
            {
                this.currentWindow.AttrOn(CursesSharp.Attrs.BOLD);
            }
            else
            {
                this.currentWindow.AttrOff(CursesSharp.Attrs.BOLD);
            }
        } }

        public void SetCurrentWindow(Window window)
        {
            this.currentWindow = window;
            window.Run();
        }

        public static readonly int Height = 25;
        public static readonly int Width = 80;

        internal void Write(int x, int y, char p)
        {
            this.Write(x, y, p.ToString());
        }
    }
}
