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

        public UInt16 resetVector = 0xFFFC;
        public UInt16 interruptVector = 0xFFFE;

        public MemoryController? MemoryController; // Memory controller
        public Int128 Cycles = 0; // Cycle count
        public Instruction? CurrentInstruction; // Current instruction
        public double ClockSpeed = 0.00001; // Clock speed in MHz
        public bool IllegalOpcode = false; // Illegal opcode flag
        public bool Running = true; // Running flag

        private InstructionExecutor? instructionExecutor;

        // Status flag bitmask enum
        public enum StatusFlag
        {
            Carry = 0x01,
            Zero = 0x02,
            InterruptEnable = 0x04,
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

        public bool InterruptEnableFlag
        {
            get { return (P & (byte)StatusFlag.InterruptEnable) != 0; }
            set { P = (byte)(value ? P | (byte)StatusFlag.InterruptEnable : P & ~(byte)StatusFlag.InterruptEnable); }
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
            SP = 0xFF;
            // Read PC from reset vector
            PC = (UInt16)(MemoryController!.ReadMemory(0xFFFC) | (MemoryController.ReadMemory(0xFFFD) << 8));
            // Set status register
            P = (byte)(StatusFlag.Unused | StatusFlag.InterruptEnable);
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

        public byte FetchByte()
        {
            // Read the byte
            byte value = MemoryController!.ReadMemory(PC);
            // Increment the program counter
            PC++;
            // Return the byte
            return value;
        }

        public sbyte FetchSignedByte()
        {
            // Read the byte
            sbyte value = (sbyte)MemoryController!.ReadMemory(PC);
            // Increment the program counter
            PC++;
            // Return the byte
            return value;
        }

        public UInt16 FetchWord()
        {
            // Read the low byte
            byte lowByte = FetchByte();
            // Read the high byte
            byte highByte = FetchByte();
            // Return the word
            return (UInt16)(lowByte | (highByte << 8));
        }

        public UInt16 StackPointerToAddress()
        {
            // Return the stack pointer address
            return (UInt16)(0x100 + SP);
        }

        public void PushByte(byte value)
        {
            // Write the value to the stack
            MemoryController!.WriteMemory((UInt16)(0x100 | SP), value);
            // Decrement the stack pointer
            SP--;
        }

        public void PushWord(UInt16 value)
        {
            // Push the high byte
            PushByte((byte)(value >> 8));
            // Push the low byte
            PushByte((byte)value);
        }

        public byte PopByte()
        {
            // Increment the stack pointer
            SP++;
            // Read the value from the stack
            return MemoryController!.ReadMemory(StackPointerToAddress());
        }

        public UInt16 PopWord()
        {
            // Pop the low byte
            byte lowByte = PopByte();
            // Pop the high byte
            byte highByte = PopByte();
            // Return the word
            return (UInt16)(lowByte | (highByte << 8));
        }

        public void StackPush(byte value)
        {
            WriteMemory((UInt16)(0x100 | SP), value);
            if (SP == 0x00)
                SP = 0xFF;
            else
                SP--;
        }

        public byte StackPop()
        {
            if (SP == 0xFF)
                SP = 0x00;
            else
                SP++;
            return ReadMemory((UInt16)(0x100 | SP));
        }

        public byte PeekByte()
        {
            // Read the byte
            return MemoryController!.ReadMemory(PC);
        }

        public UInt16 PeekWord()
        {
            // Read the low byte
            byte lowByte = MemoryController!.ReadMemory(PC);
            // Read the high byte
            byte highByte = MemoryController.ReadMemory((UInt16)(PC + 1));
            // Return the word
            return (UInt16)(lowByte | (highByte << 8));
        }

        public byte GetProcessorStatus()
        {
            // Get the processor status
            return (byte)(P | (byte)StatusFlag.Unused);
        }

        public void SetProcessorStatus(byte value)
        {
            // Set the processor status
            P = (byte)(value & ~(byte)StatusFlag.Unused);
        }

        public void ExecuteNextInstruction()
        {
            // Create the instruction executor
            instructionExecutor = new InstructionExecutor(this);

            // Fetch the opcode
            byte opcode = MemoryController!.ReadMemory(PC);

            // Get the instruction
            CurrentInstruction = InstructionSet.GetInstruction(opcode);

            // Increment the program counter
            PC++;

            // Execute the instruction
            instructionExecutor.ExecuteInstruction(CurrentInstruction, false);

            // Update the cycle count
            Cycles += CurrentInstruction.Cycles;
        }
    }
}