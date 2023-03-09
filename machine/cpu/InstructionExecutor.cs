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
            string mnemonic = instruction.Mnemonic!;

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
                case "JMP":
                    JMP();
                    break;
                case "JSR":
                    JSR();
                    break;
                case "LDA":
                    LDA();
                    break;
                case "RTS":
                    RTS();
                    break;
                case "STA":
                    STA();
                    break;
                case "STX":
                    STX();
                    break;
                case "TAX":
                    TAX();
                    break;
                default:
                    CPU.IllegalOpcode = true;
                    break;
            }
        }

        public void BRK()
        {
            // Push the program counter onto the stack
            CPU.PC++;
            CPU.StackPush((byte)((CPU.PC >> 8) & 0xFF));
            CPU.StackPush((byte)(CPU.PC & 0xFF));
            // Push the processor status onto the stack
            CPU.PushByte(CPU.GetProcessorStatus());
            // Set the interrupt disable flag
            CPU.InterruptEnableFlag = true;
            // Set the program counter to the interrupt vector
            CPU.PC = CPU.interruptVector;
            CPU.Running = false;
        }

        public void JMP()
        {
            CPU.PC = CPU.GetAddress();
        }

        public void JSR()
        {
            CPU.StackPush((byte)((CPU.PC >> 8) & 0xFF));
            CPU.StackPush((byte)(CPU.PC & 0xFF));
            CPU.PC = CPU.GetAddress();
        }

        public void LDA()
        {
            UInt16 address = CPU.GetAddress();
            byte value = CPU.ReadMemory(address);
            CPU.A = value;
            CPU.ZeroFlag = value == 0;
            CPU.NegativeFlag = (value & 0x80) != 0;
        }

        public void RTS()
        {
            CPU.PC = (UInt16)(CPU.StackPop() | (CPU.StackPop() << 8));
            CPU.PC += 2;
        }

        public void STA()
        {
            UInt16 address = CPU.GetAddress();
            CPU.WriteMemory(address, CPU.A);
        }

        public void STX()
        {
            UInt16 address = CPU.GetAddress();
            CPU.WriteMemory(address, CPU.X);
        }

        public void TAX()
        {
            CPU.X = CPU.A;
            CPU.ZeroFlag = CPU.X == 0;
            CPU.NegativeFlag = (CPU.X & 0x80) != 0;
        }
    }
}