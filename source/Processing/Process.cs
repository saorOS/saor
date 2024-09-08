using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saor.Processing
{
    public class Process
    {
        public string name, description;
        public bool running;
        public Process(string name, string description, bool running = true)
        {
            this.name = name;
            this.description = description;
            this.running = running;
        }
        public void Update()
        {
            if (running)
            {
                Run();
            }
        }
        protected virtual void Run()
        {

        }
    }
}
