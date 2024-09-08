using Cosmos.HAL.Drivers.Audio;
using Cosmos.System;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
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
        public static bool audioEnabled;

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
            try
            {
                Console.WriteLine(Events.Neutral("audio", "Initializing audio..."));
                var mixer = new AudioMixer();
                var audioStream = MemoryAudioStream.FromWave(Resources.bootAudio);
                var driver = AC97.Initialize(bufferSize: 8000);
                mixer.Streams.Add(audioStream);

                var audioManager = new AudioManager()
                {
                    Stream = mixer,
                    Output = driver
                };
                audioManager.Enable();
                Console.WriteLine(Events.Success("audio", "Audio initialized and boot sound played."));
                Thread.Sleep(3000);
                audioManager.Disable();
            }
            catch (Exception ex)
            {
                audioEnabled = false;
                Console.WriteLine(Events.Error("audio", "Audio not initialized: " + ex.Message));
                Console.WriteLine(Events.Warning("audio", "Audio disabled."));
            }
        }
        protected override void Run()
        {

        }
    }
}
