using Butterfly.Machine.Devices;

namespace Butterfly.Machine.CPU
{
    public class Disassembler
    {
        public string DisassembleInstruction(Generic CPU, Instruction instruction)
        {
            AddressingModes addressingMode = instruction.AddressingMode;

            UInt16 operand = 0;
            string operandString = string.Empty;

            switch (addressingMode)
            {
                case AddressingModes.Immediate:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"#${operand:X2}";
                    break;
                case AddressingModes.ZeroPage:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"${operand:X2}";
                    break;
                case AddressingModes.ZeroPageX:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"${operand:X2},X";
                    break;
                case AddressingModes.ZeroPageY:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"${operand:X2},Y";
                    break;
                case AddressingModes.Absolute:
                    operand = (ushort)((CPU.ReadMemory((ushort)(CPU.PC + 1)) << 8) | CPU.ReadMemory((ushort)(CPU.PC)));
                    operandString = $"${operand:X4}";
                    break;
                case AddressingModes.AbsoluteX:
                    operand = (ushort)((CPU.ReadMemory((ushort)(CPU.PC + 1)) << 8) | CPU.ReadMemory((ushort)(CPU.PC)));
                    operandString = $"${operand:X4},X";
                    break;
                case AddressingModes.AbsoluteY:
                    operand = (ushort)((CPU.ReadMemory((ushort)(CPU.PC + 1)) << 8) | CPU.ReadMemory((ushort)(CPU.PC)));
                    operandString = $"${operand:X4},Y";
                    break;
                case AddressingModes.Indirect:
                    operand = (ushort)((CPU.ReadMemory((ushort)(CPU.PC + 1)) << 8) | CPU.ReadMemory((ushort)(CPU.PC)));
                    operandString = $"(${operand:X4})";
                    break;
                case AddressingModes.IndirectX:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"(${operand:X2},X)";
                    break;
                case AddressingModes.IndirectY:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"(${operand:X2}),Y";
                    break;
                case AddressingModes.Relative:
                    operand = CPU.ReadMemory((ushort)(CPU.PC));
                    operandString = $"${operand:X2}";
                    break;
                case AddressingModes.Accumulator:
                    operandString = "A";
                    break;
                case AddressingModes.Implied:
                    operandString = string.Empty;
                    break;
                default:
                    break;
            }

            return $"{instruction.Mnemonic} {operandString}";
        }
    }
}