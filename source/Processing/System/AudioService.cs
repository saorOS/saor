using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using saor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace saor.Processing.System
{
    public class AudioService : Process
    {
        public AudioMixer audioMixer;
        public AC97 audioDriver;
        public AudioService() : base("audio", "Audio service, used to play sounds in the system.")
        {
            try
            {
                Enable();
            }
            catch(Exception ex)
            {
                Console.WriteLine(Events.Error("audio", "Audio not initialized: " + ex.Message));
                Console.WriteLine(Events.Warning("audio", "Audio disabled."));
                running = false;
            }
        }
        public void PlayAudio(AudioStream audioStream)
        {
            audioMixer.Streams.Add(audioStream);
        }
        public void Enable()
        {
            Console.WriteLine(Events.Neutral("audio", "Initializing audio..."));
            audioMixer = new AudioMixer();
            var audioStream = MemoryAudioStream.FromWave(Resources.bootAudio);
            audioDriver = AC97.Initialize(bufferSize: 4096);
            audioMixer.Streams.Add(audioStream);

            var audioManager = new AudioManager()
            {
                Stream = audioMixer,
                Output = audioDriver
            };
            audioManager.Enable();
            Console.WriteLine(Events.Success("audio", "Audio initialized and boot sound played."));
            running = true;
        }
        public void Disable()
        {
            Console.WriteLine(Events.Warning("audio", "Audio disabled."));
            audioDriver.Disable();
            running = false;
        }
    }
}
