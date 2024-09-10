using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;
using saor.Core;
using System;

namespace saor.Processing.System
{
    public class AudioService : Process
    {
        public AudioMixer audioMixer;
        public AC97 audioDriver;
        public AudioService(bool running = true) : base("audio", "Audio service, used to play sounds in the system.", running)
        {
            try
            {
                Enable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(Events.Error(name, "Audio not initialized: " + ex.Message));
                Console.WriteLine(Events.Warning(name, "Audio disabled."));
                running = false;
            }
        }
        public void PlayAudio(AudioStream audioStream)
        {
            audioMixer.Streams.Add(audioStream);
        }
        public void Enable()
        {
            Console.WriteLine(Events.Neutral(name, "Initializing audio..."));
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
            Console.WriteLine(Events.Success(name, "Audio initialized and boot sound played."));
            running = true;
        }
        public void Disable()
        {
            Console.WriteLine(Events.Warning(name, "Audio disabled."));
            audioDriver.Disable();
            running = false;
        }
    }
}
