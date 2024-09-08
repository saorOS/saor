using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saor.Core
{
    /// <summary>
    /// Resources class, used for accessing system resources like audio, images text and more. All the resources are in byte[] format.
    /// </summary>
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "saor.Resources.bootAudio.wav")]
        public static byte[] bootAudio;
    }
}
