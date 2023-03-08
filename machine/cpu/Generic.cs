using Butterfly.Machine.Devices;

namespace Butterfly.Machine.CPU
{
    /// <summary>
    /// A generic 6502 CPU
    /// </summary>
    /// <remarks>
    /// This is a generic 6502 CPU. It is not a specific implementation of a 6502 CPU.
    /// </remarks>
    public class Generic
    {
        // Registers
        public byte A; // Accumulator
        public byte X; // X register
        public byte Y; // Y register
        public byte SP; // Stack pointer
        public UInt16 PC; // Program counter
        public byte P; // Status register

        public MemoryController? MemoryController; // Memory controller

        // Status flag bitmask enum
        public enum StatusFlag
        {
            Carry = 0x01,
            Zero = 0x02,
            InterruptDisable = 0x04,
            DecimalMode = 0x08,
            BreakCommand = 0x10,
            Unused = 0x20,
            Overflow = 0x40,
            Negative = 0x80
        }

        // Status flag accessors
        public bool CarryFlag
        {
            get { return (P & (byte)StatusFlag.Carry) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.Carry : P & ~(byte)StatusFlag.Carry); }
        }

        public bool ZeroFlag
        {
            get { return (P & (byte)StatusFlag.Zero) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.Zero : P & ~(byte)StatusFlag.Zero); }
        }

        public bool InterruptDisableFlag
        {
            get { return (P & (byte)StatusFlag.InterruptDisable) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.InterruptDisable : P & ~(byte)StatusFlag.InterruptDisable); }
        }

        public bool DecimalModeFlag
        {
            get { return (P & (byte)StatusFlag.DecimalMode) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.DecimalMode : P & ~(byte)StatusFlag.DecimalMode); }
        }

        public bool BreakCommandFlag
        {
            get { return (P & (byte)StatusFlag.BreakCommand) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.BreakCommand : P & ~(byte)StatusFlag.BreakCommand); }
        }

        public bool UnusedFlag
        {
            get { return (P & (byte)StatusFlag.Unused) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.Unused : P & ~(byte)StatusFlag.Unused); }
        }

        public bool OverflowFlag
        {
            get { return (P & (byte)StatusFlag.Overflow) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.Overflow : P & ~(byte)StatusFlag.Overflow); }
        }

        public bool NegativeFlag
        {
            get { return (P & (byte)StatusFlag.Negative) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.Negative : P & ~(byte)StatusFlag.Negative); }
        }

        // Reset the CPU
        public void Reset()
        {
            A = 0;
            X = 0;
            Y = 0;
            SP = 0xFD;
            // Read PC from reset vector
            PC = (UInt16)(MemoryController!.ReadMemory(0xFFFC) | (MemoryController.ReadMemory(0xFFFD) << 8));
            // Set status register
            P = (byte)(StatusFlag.Unused | StatusFlag.InterruptDisable);
        }

        public string GetRegisters()
        {
            return $"A: {A:X2} X: {X:X2} Y: {Y:X2} SP: {SP:X2} PC: {PC:X4} P: {P:X2}";
        }

        public byte ReadMemory(UInt16 address)
        {
            return MemoryController!.ReadMemory(address);
        }

        public byte ReadMemory16(UInt16 address)
        {
            // Read the low byte
            byte lowByte = MemoryController!.ReadMemory(address);
            // Read the high byte
            byte highByte = MemoryController.ReadMemory((UInt16)(address + 1));
            // Return the 16-bit value
            return (byte)(lowByte | (highByte << 8));
        }

        public void WriteMemory(UInt16 address, byte value)
        {
            MemoryController!.WriteMemory(address, value);
        }

        public void WriteMemory16(UInt16 address, byte value)
        {
            // Write the low byte
            MemoryController!.WriteMemory(address, value);
            // Write the high byte
            MemoryController.WriteMemory((UInt16)(address + 1), value);
        }
    }
}