using Cosmos.HAL.Drivers.Audio;
using Cosmos.System;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using saor.Processing.System;
using System;
using System.Threading;
using Console = System.Console;

namespace saor.Core
{
    /// <summary>
    /// saór entry point. Most objects here are public and static for a direct access from other classes.
    /// </summary>
    public class Program : Kernel
    {
        AudioService audioService;
        protected override void BeforeRun()
        {
            Console.WriteLine(Events.Neutral("vga", "Initializing VGA Font..."));
            try
            {
                VGAScreen.SetFont(PCScreenFont.Default.CreateVGAFont(), PCScreenFont.Default.Height);
                Console.Clear();
                Console.WriteLine(Events.Success("vga", "VGA Font initialized!"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(Events.FatalError("vga", "Fatal error while setting the VGA Font: " + ex.Message));
                Console.WriteLine("Press any key to shutdown.");
                Console.ReadKey();
                Power.Shutdown();
            }
            audioService = new();
        }
        protected override void Run()
        {

        }
    }
}
