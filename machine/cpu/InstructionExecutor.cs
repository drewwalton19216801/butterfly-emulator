using Butterfly.Machine.Devices;

namespace Butterfly.Machine.CPU
{
    public class InstructionExecutor
    {
        public Generic CPU;

        public InstructionExecutor(Generic cpu)
        {
            CPU = cpu;
        }

        public void ExecuteInstruction(Instruction instruction, bool disassemble = false)
        {
            string mnemonic = instruction.Mnemonic;

            if (disassemble)
            {
                Disassembler disassembler = new Disassembler();
                Console.WriteLine(disassembler.DisassembleInstruction(CPU, instruction));
            }

            switch (mnemonic)
            {
                case "BRK":
                    BRK();
                    break;
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
            CPU.PushPC();
            // Push the processor status onto the stack
            CPU.PushByte(CPU.GetProcessorStatus());
            // Set the interrupt disable flag
            CPU.InterruptDisableFlag = true;
            // Set the program counter to the interrupt vector
            CPU.PC = CPU.interruptVector;
            CPU.Running = false;
        }

        public void LDA()
        {
            UInt16 address = CPU.GetAddress();
            byte value = CPU.ReadMemory(address);
            CPU.A = value;
            CPU.ZeroFlag = value == 0;
            CPU.NegativeFlag = (value & 0x80) != 0;
        }

        public void STA()
        {
            UInt16 address = CPU.GetAddress();
            CPU.WriteMemory(address, CPU.A);
        }
    }
}