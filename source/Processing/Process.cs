namespace saor.Processing
{
    /// <summary>
    /// Process class.
    /// </summary>
    public class Process
    {
        public string name, description;
        public bool running;

        /// <summary>
        /// Initialize process.
        /// </summary>
        /// <param name="name">Process name.</param>
        /// <param name="description">Process description.</param>
        /// <param name="running">Process running.</param>
        public Process(string name, string description, bool running = true)
        {
            this.name = name;
            this.description = description;
            this.running = running;
        }

        /// <summary>
        /// Checks if the process is running. If yes, it executes the Run() void. If not it does nothing.
        /// </summary>
        public void Update()
        {
            if (running)
            {
                Run();
            }
        }

        /// <summary>
        /// Custom process running.
        /// </summary>
        protected virtual void Run()
        {

        }
    }
}
