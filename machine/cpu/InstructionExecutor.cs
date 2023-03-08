using Butterfly.Machine.Devices;

namespace Butterfly.Machine.CPU
{
    public class InstructionExecutor
    {
        public Generic CPU;
        public MemoryController MemoryController;

        public InstructionExecutor(Generic cpu, MemoryController memoryController)
        {
            CPU = cpu;
            MemoryController = memoryController;
        }

        public void ExecuteInstruction(Instruction instruction)
        {
            string mnemonic = instruction.Mnemonic;

            switch (mnemonic)
            {
                case "LDA":
                    LDA();
                    break;
                case "STA":
                    STA();
                    break;
                default:
                    CPU.IllegalOpcode = true;
                    break;
            }
        }

        public void BRK()
        {
            // Push the program counter onto the stack
            CPU.PushStack((byte)(CPU.PC >> 8));
            CPU.PushStack((byte)(CPU.PC & 0xFF));
            // Push the processor status onto the stack
            CPU.PushStack(CPU.GetProcessorStatus());
            // Set the interrupt disable flag
            CPU.InterruptDisableFlag = true;
            // Set the program counter to the interrupt vector
            CPU.PC = CPU.interruptVector;
            CPU.Running = false;
        }

        public void LDA()
        {
            UInt16 address = CPU.GetAddress();
            byte value = MemoryController.ReadMemory(address);
            CPU.A = value;
            CPU.ZeroFlag = value == 0;
            CPU.NegativeFlag = (value & 0x80) != 0;
            // Advance the program counter
            CPU.PC += CPU.CurrentInstruction.Bytes;
        }

        public void STA()
        {
            UInt16 address = CPU.GetAddress();
            MemoryController.WriteMemory(address, CPU.A);
            // Advance the program counter
            CPU.PC += CPU.CurrentInstruction.Bytes;
        }
    }
}