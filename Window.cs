using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleX
{
    public abstract class Window
    {
        private CursesSharp.Window window;

        public Window()
        {
            this.window = new CursesSharp.Window(MainConsole.HEIGHT, MainConsole.WIDTH, 0, 0);
        }

        public static implicit operator CursesSharp.Window(Window window)
        {
            return window.window;
        }

        public abstract void Run();
    }
}
