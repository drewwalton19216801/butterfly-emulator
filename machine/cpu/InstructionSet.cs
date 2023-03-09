namespace Butterfly.Machine.CPU
{
    public static class InstructionSet
    {
        /// <summary>
        /// The list of instructions
        /// </summary>
        /// <remarks>
        /// The list of instructions is a list of all the instructions that the CPU can execute.
        /// </remarks>
        public static readonly Instruction[] Instructions =
        {
            // ADC (Add with Carry)
            new Instruction { Mnemonic = "ADC", OpCode = 0x69, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "ADC", OpCode = 0x65, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "ADC", OpCode = 0x75, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "ADC", OpCode = 0x6D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "ADC", OpCode = 0x7D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "ADC", OpCode = 0x79, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "ADC", OpCode = 0x61, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "ADC", OpCode = 0x71, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // AND (Logical AND)
            new Instruction { Mnemonic = "AND", OpCode = 0x29, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "AND", OpCode = 0x25, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "AND", OpCode = 0x35, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "AND", OpCode = 0x2D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "AND", OpCode = 0x3D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "AND", OpCode = 0x39, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "AND", OpCode = 0x21, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "AND", OpCode = 0x31, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // ASL (Arithmetic Shift Left)
            new Instruction { Mnemonic = "ASL", OpCode = 0x0A, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Accumulator },
            new Instruction { Mnemonic = "ASL", OpCode = 0x06, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "ASL", OpCode = 0x16, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "ASL", OpCode = 0x0E, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "ASL", OpCode = 0x1E, Bytes = 3, Cycles = 7, AddressingMode = AddressingModes.AbsoluteX },

            // BCC (Branch if Carry Clear)
            new Instruction { Mnemonic = "BCC", OpCode = 0x90, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BCS (Branch if Carry Set)
            new Instruction { Mnemonic = "BCS", OpCode = 0xB0, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BEQ (Branch if Equal)
            new Instruction { Mnemonic = "BEQ", OpCode = 0xF0, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BIT (Bit Test)
            new Instruction { Mnemonic = "BIT", OpCode = 0x24, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "BIT", OpCode = 0x2C, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },

            // BMI (Branch if Minus)
            new Instruction { Mnemonic = "BMI", OpCode = 0x30, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BNE (Branch if Not Equal)
            new Instruction { Mnemonic = "BNE", OpCode = 0xD0, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BPL (Branch if Positive)
            new Instruction { Mnemonic = "BPL", OpCode = 0x10, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BRK (Break)
            new Instruction { Mnemonic = "BRK", OpCode = 0x00, Bytes = 1, Cycles = 7, AddressingMode = AddressingModes.Implied },

            // BVC (Branch if Overflow Clear)
            new Instruction { Mnemonic = "BVC", OpCode = 0x50, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // BVS (Branch if Overflow Set)
            new Instruction { Mnemonic = "BVS", OpCode = 0x70, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Relative },

            // CLC (Clear Carry Flag)
            new Instruction { Mnemonic = "CLC", OpCode = 0x18, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // CLD (Clear Decimal Mode)
            new Instruction { Mnemonic = "CLD", OpCode = 0xD8, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // CLI (Clear Interrupt Disable)
            new Instruction { Mnemonic = "CLI", OpCode = 0x58, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // CLV (Clear Overflow Flag)
            new Instruction { Mnemonic = "CLV", OpCode = 0xB8, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // CMP (Compare)
            new Instruction { Mnemonic = "CMP", OpCode = 0xC9, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "CMP", OpCode = 0xC5, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "CMP", OpCode = 0xD5, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "CMP", OpCode = 0xCD, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "CMP", OpCode = 0xDD, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "CMP", OpCode = 0xD9, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "CMP", OpCode = 0xC1, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "CMP", OpCode = 0xD1, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // CPX (Compare X Register)
            new Instruction { Mnemonic = "CPX", OpCode = 0xE0, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "CPX", OpCode = 0xE4, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "CPX", OpCode = 0xEC, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },

            // CPY (Compare Y Register)
            new Instruction { Mnemonic = "CPY", OpCode = 0xC0, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "CPY", OpCode = 0xC4, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "CPY", OpCode = 0xCC, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },

            // DEC (Decrement Memory)
            new Instruction { Mnemonic = "DEC", OpCode = 0xC6, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "DEC", OpCode = 0xD6, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "DEC", OpCode = 0xCE, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "DEC", OpCode = 0xDE, Bytes = 3, Cycles = 7, AddressingMode = AddressingModes.AbsoluteX },

            // DEX (Decrement X Register)
            new Instruction { Mnemonic = "DEX", OpCode = 0xCA, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // DEY (Decrement Y Register)
            new Instruction { Mnemonic = "DEY", OpCode = 0x88, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // EOR (Exclusive OR)
            new Instruction { Mnemonic = "EOR", OpCode = 0x49, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "EOR", OpCode = 0x45, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "EOR", OpCode = 0x55, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "EOR", OpCode = 0x4D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "EOR", OpCode = 0x5D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "EOR", OpCode = 0x59, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "EOR", OpCode = 0x41, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "EOR", OpCode = 0x51, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // INC (Increment Memory)
            new Instruction { Mnemonic = "INC", OpCode = 0xE6, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "INC", OpCode = 0xF6, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "INC", OpCode = 0xEE, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "INC", OpCode = 0xFE, Bytes = 3, Cycles = 7, AddressingMode = AddressingModes.AbsoluteX },

            // INX (Increment X Register)
            new Instruction { Mnemonic = "INX", OpCode = 0xE8, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // INY (Increment Y Register)
            new Instruction { Mnemonic = "INY", OpCode = 0xC8, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // JMP (Jump)
            new Instruction { Mnemonic = "JMP", OpCode = 0x4C, Bytes = 3, Cycles = 3, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "JMP", OpCode = 0x6C, Bytes = 3, Cycles = 5, AddressingMode = AddressingModes.Indirect },

            // JSR (Jump to Subroutine)
            new Instruction { Mnemonic = "JSR", OpCode = 0x20, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },

            // LDA (Load Accumulator)
            new Instruction { Mnemonic = "LDA", OpCode = 0xA9, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "LDA", OpCode = 0xA5, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "LDA", OpCode = 0xB5, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "LDA", OpCode = 0xAD, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "LDA", OpCode = 0xBD, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "LDA", OpCode = 0xB9, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "LDA", OpCode = 0xA1, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "LDA", OpCode = 0xB1, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // LDX (Load X Register)
            new Instruction { Mnemonic = "LDX", OpCode = 0xA2, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "LDX", OpCode = 0xA6, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "LDX", OpCode = 0xB6, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageY },
            new Instruction { Mnemonic = "LDX", OpCode = 0xAE, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "LDX", OpCode = 0xBE, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },

            // LDY (Load Y Register)
            new Instruction { Mnemonic = "LDY", OpCode = 0xA0, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "LDY", OpCode = 0xA4, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "LDY", OpCode = 0xB4, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "LDY", OpCode = 0xAC, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "LDY", OpCode = 0xBC, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },

            // LSR (Logical Shift Right)
            new Instruction { Mnemonic = "LSR", OpCode = 0x4A, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Accumulator },
            new Instruction { Mnemonic = "LSR", OpCode = 0x46, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "LSR", OpCode = 0x56, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "LSR", OpCode = 0x4E, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "LSR", OpCode = 0x5E, Bytes = 3, Cycles = 7, AddressingMode = AddressingModes.AbsoluteX },

            // NOP (No Operation)
            new Instruction { Mnemonic = "NOP", OpCode = 0xEA, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // ORA (Logical Inclusive OR)
            new Instruction { Mnemonic = "ORA", OpCode = 0x09, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "ORA", OpCode = 0x05, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "ORA", OpCode = 0x15, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "ORA", OpCode = 0x0D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "ORA", OpCode = 0x1D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "ORA", OpCode = 0x19, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "ORA", OpCode = 0x01, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "ORA", OpCode = 0x11, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // PHA (Push Accumulator)
            new Instruction { Mnemonic = "PHA", OpCode = 0x48, Bytes = 1, Cycles = 3, AddressingMode = AddressingModes.Implied },

            // PHP (Push Processor Status)
            new Instruction { Mnemonic = "PHP", OpCode = 0x08, Bytes = 1, Cycles = 3, AddressingMode = AddressingModes.Implied },

            // PLA (Pull Accumulator)
            new Instruction { Mnemonic = "PLA", OpCode = 0x68, Bytes = 1, Cycles = 4, AddressingMode = AddressingModes.Implied },

            // PLP (Pull Processor Status)
            new Instruction { Mnemonic = "PLP", OpCode = 0x28, Bytes = 1, Cycles = 4, AddressingMode = AddressingModes.Implied },

            // ROL (Rotate Left)
            new Instruction { Mnemonic = "ROL", OpCode = 0x2A, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Accumulator },
            new Instruction { Mnemonic = "ROL", OpCode = 0x26, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "ROL", OpCode = 0x36, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "ROL", OpCode = 0x2E, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "ROL", OpCode = 0x3E, Bytes = 3, Cycles = 7, AddressingMode = AddressingModes.AbsoluteX },

            // ROR (Rotate Right)
            new Instruction { Mnemonic = "ROR", OpCode = 0x6A, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Accumulator },
            new Instruction { Mnemonic = "ROR", OpCode = 0x66, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "ROR", OpCode = 0x76, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "ROR", OpCode = 0x6E, Bytes = 3, Cycles = 6, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "ROR", OpCode = 0x7E, Bytes = 3, Cycles = 7, AddressingMode = AddressingModes.AbsoluteX },

            // RTI (Return from Interrupt)
            new Instruction { Mnemonic = "RTI", OpCode = 0x40, Bytes = 1, Cycles = 6, AddressingMode = AddressingModes.Implied },

            // RTS (Return from Subroutine)
            new Instruction { Mnemonic = "RTS", OpCode = 0x60, Bytes = 1, Cycles = 6, AddressingMode = AddressingModes.Implied },

            // SBC (Subtract with Carry)
            new Instruction { Mnemonic = "SBC", OpCode = 0xE9, Bytes = 2, Cycles = 2, AddressingMode = AddressingModes.Immediate },
            new Instruction { Mnemonic = "SBC", OpCode = 0xE5, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "SBC", OpCode = 0xF5, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "SBC", OpCode = 0xED, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "SBC", OpCode = 0xFD, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "SBC", OpCode = 0xF9, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "SBC", OpCode = 0xE1, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "SBC", OpCode = 0xF1, Bytes = 2, Cycles = 5, AddressingMode = AddressingModes.IndirectY },

            // SEC (Set Carry Flag)
            new Instruction { Mnemonic = "SEC", OpCode = 0x38, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // SED (Set Decimal Flag)
            new Instruction { Mnemonic = "SED", OpCode = 0xF8, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // SEI (Set Interrupt Disable)
            new Instruction { Mnemonic = "SEI", OpCode = 0x78, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // STA (Store Accumulator)
            new Instruction { Mnemonic = "STA", OpCode = 0x85, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "STA", OpCode = 0x95, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "STA", OpCode = 0x8D, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },
            new Instruction { Mnemonic = "STA", OpCode = 0x9D, Bytes = 3, Cycles = 5, AddressingMode = AddressingModes.AbsoluteX },
            new Instruction { Mnemonic = "STA", OpCode = 0x99, Bytes = 3, Cycles = 5, AddressingMode = AddressingModes.AbsoluteY },
            new Instruction { Mnemonic = "STA", OpCode = 0x81, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectX },
            new Instruction { Mnemonic = "STA", OpCode = 0x91, Bytes = 2, Cycles = 6, AddressingMode = AddressingModes.IndirectY },

            // STX (Store X Register)
            new Instruction { Mnemonic = "STX", OpCode = 0x86, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "STX", OpCode = 0x96, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageY },
            new Instruction { Mnemonic = "STX", OpCode = 0x8E, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },

            // STY (Store Y Register)
            new Instruction { Mnemonic = "STY", OpCode = 0x84, Bytes = 2, Cycles = 3, AddressingMode = AddressingModes.ZeroPage },
            new Instruction { Mnemonic = "STY", OpCode = 0x94, Bytes = 2, Cycles = 4, AddressingMode = AddressingModes.ZeroPageX },
            new Instruction { Mnemonic = "STY", OpCode = 0x8C, Bytes = 3, Cycles = 4, AddressingMode = AddressingModes.Absolute },

            // TAX (Transfer Accumulator to X)
            new Instruction { Mnemonic = "TAX", OpCode = 0xAA, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // TAY (Transfer Accumulator to Y)
            new Instruction { Mnemonic = "TAY", OpCode = 0xA8, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // TSX (Transfer Stack Pointer to X)
            new Instruction { Mnemonic = "TSX", OpCode = 0xBA, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // TXA (Transfer X to Accumulator)
            new Instruction { Mnemonic = "TXA", OpCode = 0x8A, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // TXS (Transfer X to Stack Pointer)
            new Instruction { Mnemonic = "TXS", OpCode = 0x9A, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied },

            // TYA (Transfer Y to Accumulator)
            new Instruction { Mnemonic = "TYA", OpCode = 0x98, Bytes = 1, Cycles = 2, AddressingMode = AddressingModes.Implied }
        };

        /// <summary>
        /// Get an instruction by its opcode
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public static Instruction GetInstruction(byte opcode)
        {
            // Loop through the instruction set and return the instruction that matches the opcode
            foreach (Instruction instruction in Instructions)
            {
                if (instruction.OpCode == opcode)
                {
                    // Return the instruction
                    return instruction;
                }
            }

            // If we get here, the instruction was not found
            return new Instruction { Mnemonic = "XXX", OpCode = opcode, Bytes = 1, Cycles = 0, AddressingMode = AddressingModes.Implied };
        }
    }
}