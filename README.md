Console-X
=========

Console-X adds a layer on top of [Curses Sharp] [1] for C# which improves the API and usability significantly.  Current improvements include:

* A natural, C#-style API (instead of a Curses-style API)
* Simplified setup and initalization
* A simpler way to write to the single, main console window
* Easy enumerations for all sixteen possible colours
* Fixes for some bugs (work-arounds)

Getting Started
---------------

To create a simple "Hello World" Console-X project:

* Fork the latest code from GitHub and add the project to your solution
* Assign an instance of `MainConsole.Instance`
* Draw stuff with the `Write` method
* Change colours by setting the `Color` property to one of the pre-defined `Color` values

Sample project
--------------------

This code fills the full window with numbers, and fluctuates the colours randomly.

```
var console = MainConsole.Instance;

int HEIGHT = 25;
int WIDTH = 80;

Random random = new Random();
string text = "";

var colors = new Color[] {
	Color.Black, Color.DarkBlue, Color.DarkGreen, Color.DarkCyan, Color.DarkRed, Color.DarkPurple,
	Color.DarkYellow, Color.Grey, Color.DarkGrey, Color.Blue, Color.Green, Color.Cyan, Color.Red,
	Color.Purple, Color.Yellow, Color.White };

while (true)
{
	console.Clear();

	for (int y = 0; y < HEIGHT; y++)
	{
		for (int x = 0; x < WIDTH; x++)
		{
			int c = random.Next(colors.Length);
			text = (x % 10).ToString();
			console.Color = colors[c];
			console.Write(x, y, text);                        
		}
	}

	console.Refresh();
} 
```

[1]: http://curses-sharp.sourceforge.net
