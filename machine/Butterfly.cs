using Butterfly.Machine.CPU;
using Butterfly.Machine.Devices;

namespace Butterfly.Machine
{
    public class ButterflyMachine
    {
        public Generic CPU;
        public MemoryController MemoryController;

        public UInt16 resetVector = 0xFFFC;
        public UInt16 interruptVector = 0xFFFE;

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
    }
}