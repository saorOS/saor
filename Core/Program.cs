using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Console = System.Console;

namespace saór.Core
{
    /// <summary>
    /// saór entry point. Most objects here are public and static for a direct access from other classes.
    /// </summary>
    public class Program : Kernel
    {
        protected override void BeforeRun()
        {
            Events.Neutral("vga", "Initializing VGA Font...");
            VGAScreen.SetFont(PCScreenFont.Default.CreateVGAFont(), PCScreenFont.Default.Height);
            Console.Clear();
            Events.Success("vga", "VGA Font initialized!");

        }
        protected override void Run()
        {
        }
    }
}
