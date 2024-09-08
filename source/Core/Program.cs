using Cosmos.HAL.Drivers.Audio;
using Cosmos.System;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using Console = System.Console;

namespace saor.Core
{
    /// <summary>
    /// saór entry point. Most objects here are public and static for a direct access from other classes.
    /// </summary>
    public class Program : Kernel
    {
        public static AudioMixer audioMixer;
        public static AC97 audioDriver;
        public static AudioManager audioManager;
        public static bool audioEnabled;
        private static AudioStream bootAudio;

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
                bootAudio = MemoryAudioStream.FromWave(Resources.bootAudio);
                audioMixer = new();
                audioDriver = AC97.Initialize(bufferSize: 4096);
                audioMixer.Streams.Add(bootAudio);
                audioManager = new()
                {
                    Stream = audioMixer,
                    Output = audioDriver
                };
                audioManager.Enable();
                audioEnabled = true;
                Console.WriteLine(Events.Success("audio", "Audio initialized and boot sound played."));
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
