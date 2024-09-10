using System.Collections.Generic;

namespace saor.Processing
{
    public class ProcessManager
    {
        public List<Process> ProcessList;
        public bool running;
        public ProcessManager(bool running = true)
        {
            this.running = running;
        }
        public void RegisterProcess(Process process)
        {
            this.ProcessList.Add(process);
        }
        public void Update()
        {
            if (running)
            {
                foreach (Process process in ProcessList)
                {
                    process.Update();
                }
            }
        }
    }
}
