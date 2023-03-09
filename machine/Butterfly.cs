using Butterfly.Machine.CPU;
using Butterfly.Machine.Devices;

namespace Butterfly.Machine
{
    public class ButterflyMachine
    {
        public Generic CPU;
        public MemoryController MemoryController;

        public ButterflyMachine()
        {
            CPU = new Generic();
            MemoryController = new MemoryController();
            // Set the CPU's memory controller to the Butterfly's memory controller
            CPU.MemoryController = MemoryController;
        }

        public void Reset()
        {
            CPU.Reset();
        }

        public void Run()
        {
            // Set the running flag
            CPU.Running = true;
            // Set the cycle duration based on the clock speed
            double cycleDuration = 1 / (CPU.ClockSpeed * 1000000);
            // Loop until the running flag is set to false
            while (CPU.Running && !CPU.IllegalOpcode)
            {
                // Get the current time
                long startTime = DateTime.Now.Ticks;
                // Execute the next instruction
                CPU.ExecuteNextInstruction();
                // Get the current time
                long endTime = DateTime.Now.Ticks;
                // Calculate the time taken to execute the instruction
                long timeTaken = endTime - startTime;
                // Calculate the time we need to wait to reach the next cycle
                long waitTime = (long)(cycleDuration * 10000000) - timeTaken;
                // Wait for the next cycle
                if (waitTime > 0)
                {
                    Thread.Sleep(new TimeSpan(waitTime));
                }
            }

            // Emulation has stopped
            Console.WriteLine();
            Console.WriteLine("Emulation stopped");
        }
    }
}