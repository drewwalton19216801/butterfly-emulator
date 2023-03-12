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
                case "ADC":
                    ADC();
                    break;
                case "BRK":
                    BRK();
                    break;
                case "BEQ":
                    BEQ();
                    break;
                case "CMP":
                    CMP();
                    break;
                case "CPX":
                    CPX();
                    break;
                case "CPY":
                    CPY();
                    break;
                case "DEC":
                    DEC();
                    break;
                case "DEX":
                    DEX();
                    break;
                case "DEY":
                    DEY();
                    break;
                case "INC":
                    INC();
                    break;
                case "INX":
                    INX();
                    break;
                case "INY":
                    INY();
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
                case "LDX":
                    LDX();
                    break;
                case "LDY":
                    LDY();
                    break;
                case "RTS":
                    RTS();
                    break;
                case "SBC":
                    SBC();
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

        public void ADC()
        {
            UInt16 address = CPU.GetAddress();
            byte data = CPU.ReadMemory(address);
            UInt16 tmp = (UInt16)(CPU.A + data + (CPU.CarryFlag ? 1 : 0));
            // Set zero flag
            CPU.ZeroFlag = (tmp & 0xFF) == 0;
            // Check for decimal mode
            if (CPU.DecimalModeFlag)
            {
                // Do BCD addition
                if (((CPU.A & 0x0F) + (data & 0x0F) + (CPU.CarryFlag ? 1 : 0)) > 9)
                {
                    tmp += 6;
                }
                // Set negative flag
                CPU.NegativeFlag = (tmp & 0x80) != 0;
                // Set overflow flag
                CPU.OverflowFlag = ((CPU.A ^ data) & 0x80) == 0 && ((CPU.A ^ tmp) & 0x80) != 0;
                if (tmp > 0x99)
                {
                    tmp += 0x96;
                }
                // Set carry flag
                CPU.CarryFlag = tmp > 0x99;
            }
            else
            {
                // Set negative flag
                CPU.NegativeFlag = (tmp & 0x80) != 0;
                // Set overflow flag
                CPU.OverflowFlag = ((CPU.A ^ data) & 0x80) == 0 && ((CPU.A ^ tmp) & 0x80) != 0;
                // Set carry flag
                CPU.CarryFlag = tmp > 0xFF;
            }

            CPU.A = (byte)(tmp & 0xFF);
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

        public void BEQ()
        {
            if (CPU.ZeroFlag)
            {
                CPU.PC += CPU.GetAddress();
            }

            CPU.PC++;
        }

        public void CMP()
        {
            UInt16 tmp = (UInt16)(CPU.A - CPU.ReadMemory(CPU.GetAddress()));
            // Set carry flag
            CPU.CarryFlag = tmp < 0x100;
            // Set negative flag
            CPU.NegativeFlag = (tmp & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = (tmp & 0xFF) == 0;
        }

        public void CPX()
        {
            UInt16 tmp = (UInt16)(CPU.X - CPU.ReadMemory(CPU.GetAddress()));
            // Set carry flag
            CPU.CarryFlag = tmp < 0x100;
            // Set negative flag
            CPU.NegativeFlag = (tmp & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = (tmp & 0xFF) == 0;
        }

        public void CPY()
        {
            UInt16 tmp = (UInt16)(CPU.Y - CPU.ReadMemory(CPU.GetAddress()));
            // Set carry flag
            CPU.CarryFlag = tmp < 0x100;
            // Set negative flag
            CPU.NegativeFlag = (tmp & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = (tmp & 0xFF) == 0;
        }

        public void DEC()
        {
            UInt16 address = CPU.GetAddress();
            byte data = CPU.ReadMemory(address);
            data = (byte)((data - 1) % 256);
            // Set negative flag
            CPU.NegativeFlag = (data & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = data == 0;
            CPU.WriteMemory(address, data);
        }

        public void DEX()
        {
            byte data = (byte)((CPU.X - 1) % 256);
            // Set negative flag
            CPU.NegativeFlag = (data & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = data == 0;
            CPU.X = data;
        }

        public void DEY()
        {
            byte data = (byte)((CPU.Y - 1) % 256);
            // Set negative flag
            CPU.NegativeFlag = (data & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = data == 0;
            CPU.Y = data;
        }

        public void INC()
        {
            UInt16 address = CPU.GetAddress();
            byte value = CPU.ReadMemory(address);
            value++;
            CPU.WriteMemory(address, value);
            CPU.ZeroFlag = value == 0;
            CPU.NegativeFlag = (value & 0x80) != 0;
        }

        public void INX()
        {
            CPU.X++;
            CPU.ZeroFlag = CPU.X == 0;
            CPU.NegativeFlag = (CPU.X & 0x80) != 0;
        }

        public void INY()
        {
            CPU.Y++;
            CPU.ZeroFlag = CPU.Y == 0;
            CPU.NegativeFlag = (CPU.Y & 0x80) != 0;
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

        public void LDX()
        {
            UInt16 address = CPU.GetAddress();
            byte value = CPU.ReadMemory(address);
            CPU.X = value;
            CPU.ZeroFlag = value == 0;
            CPU.NegativeFlag = (value & 0x80) != 0;
        }

        public void LDY()
        {
            UInt16 address = CPU.GetAddress();
            byte value = CPU.ReadMemory(address);
            CPU.Y = value;
            CPU.ZeroFlag = value == 0;
            CPU.NegativeFlag = (value & 0x80) != 0;
        }

        public void RTS()
        {
            CPU.PC = (UInt16)(CPU.StackPop() | (CPU.StackPop() << 8));
            CPU.PC += 2;
        }

        public void SBC()
        {
            UInt16 address = CPU.GetAddress();
            byte data = CPU.ReadMemory(address);
            UInt16 tmp = (UInt16)(CPU.A - data - (CPU.CarryFlag ? 0 : 1));
            // Set negative flag
            CPU.NegativeFlag = (tmp & 0x80) != 0;
            // Set zero flag
            CPU.ZeroFlag = (tmp & 0xFF) == 0;
            // Set overflow flag
            CPU.OverflowFlag = ((CPU.A ^ data) & 0x80) != 0 && ((CPU.A ^ tmp) & 0x80) != 0;
            // Check for decimal mode
            if (CPU.DecimalModeFlag)
            {
                // Do BCD subtraction
                if (((CPU.A & 0x0F) - (data & 0x0F) - (CPU.CarryFlag ? 0 : 1)) < 0)
                {
                    tmp -= 6;
                }
                if (tmp > 0x99)
                {
                    tmp -= 0x60;
                }
            }
            // Set carry flag
            CPU.CarryFlag = tmp < 0x100;
            // Store the result
            CPU.A = (byte)(tmp & 0xFF);
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