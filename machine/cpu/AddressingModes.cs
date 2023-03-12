namespace Butterfly.Machine.CPU
{
    /// <summary>
    /// Addressing modes for the 6502 CPU
    /// </summary>
    public enum AddressingModes
    {
        Implied,
        Accumulator,
        Immediate,
        ZeroPage,
        ZeroPageX,
        ZeroPageY,
        Absolute,
        AbsoluteX,
        AbsoluteY,
        Indirect,
        IndirectX,
        IndirectY,
        Relative,
    }

    /// <summary>
    /// Extension methods for AddressingModes
    /// </summary>
    public static class AddressingModesExtensions
    {
        /// <summary>
        /// Returns true if the addressing mode is indirect
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is indirect</returns>
        public static bool IsIndirect(this AddressingModes mode)
        {
            return mode == AddressingModes.Indirect || mode == AddressingModes.IndirectX || mode == AddressingModes.IndirectY;
        }

        /// <summary>
        /// Returns true if the addressing mode is indexed
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is indexed</returns>
        public static bool IsIndexed(this AddressingModes mode)
        {
            return mode == AddressingModes.ZeroPageX || mode == AddressingModes.ZeroPageY || mode == AddressingModes.AbsoluteX || mode == AddressingModes.AbsoluteY || mode == AddressingModes.IndirectX || mode == AddressingModes.IndirectY;
        }

        /// <summary>
        /// Returns true if the addressing mode is zero page
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is zero page</returns>
        /// <remarks>Zero page addressing is used for addressing memory in the first 256 bytes of memory</remarks>
        public static bool IsZeroPage(this AddressingModes mode)
        {
            return mode == AddressingModes.ZeroPage || mode == AddressingModes.ZeroPageX || mode == AddressingModes.ZeroPageY;
        }

        /// <summary>
        /// Returns true if the addressing mode is absolute
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is absolute</returns>
        public static bool IsAbsolute(this AddressingModes mode)
        {
            return mode == AddressingModes.Absolute || mode == AddressingModes.AbsoluteX || mode == AddressingModes.AbsoluteY;
        }

        /// <summary>
        /// Returns true if the addressing mode is immediate
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is immediate</returns>
        public static bool IsImmediate(this AddressingModes mode)
        {
            return mode == AddressingModes.Immediate;
        }

        /// <summary>
        /// Returns true if the addressing mode is relative
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is relative</returns>
        public static bool IsRelative(this AddressingModes mode)
        {
            return mode == AddressingModes.Relative;
        }

        /// <summary>
        /// Returns true if the addressing mode is accumulator
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is accumulator</returns>
        public static bool IsAccumulator(this AddressingModes mode)
        {
            return mode == AddressingModes.Accumulator;
        }

        /// <summary>
        /// Returns true if the addressing mode is implied
        /// </summary>
        /// <param name="mode">The addressing mode</param>
        /// <returns>true if the addressing mode is implied</returns>
        public static bool IsImplied(this AddressingModes mode)
        {
            return mode == AddressingModes.Implied;
        }
    }

    public static class AddressingMode
    {
        /// <summary>
        /// The implied addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>0</returns>
        /// <remarks>Implied addressing mode is used for instructions that do not require an operand</remarks>
        public static UInt16 Implied(this Generic cpu)
        {
            return 0;
        }

        /// <summary>
        /// The accumulator addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>0</returns>
        /// <remarks>Accumulator addressing mode is used for instructions that operate on the accumulator</remarks>
        public static UInt16 Accumulator(this Generic cpu)
        {
            return 0;
        }

        /// <summary>
        /// The immediate addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next byte in memory</returns>
        /// <remarks>Immediate addressing mode is used for instructions that require an immediate value</remarks>
        public static UInt16 Immediate(this Generic cpu)
        {
            UInt16 address = cpu.PC;
            // Increment the program counter
            cpu.PC++;
            // Return the address
            return address;
        }

        /// <summary>
        /// The zero page addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next byte in memory</returns>
        /// <remarks>Zero page addressing mode is used for instructions that require an address in the first 256 bytes of memory</remarks>
        public static UInt16 ZeroPage(this Generic cpu)
        {
            return cpu.FetchByte();
        }

        /// <summary>
        /// The zero page X addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next byte in memory plus the X register</returns>
        /// <remarks>Zero page X addressing mode is used for instructions that require an address in the first 256 bytes of memory plus the X register</remarks>
        public static UInt16 ZeroPageX(this Generic cpu)
        {
            UInt16 address = (ushort)((cpu.FetchByte() + cpu.X) % 256);
            return address;
        }

        /// <summary>
        /// The zero page Y addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next byte in memory plus the Y register</returns>
        /// <remarks>Zero page Y addressing mode is used for instructions that require an address in the first 256 bytes of memory plus the Y register</remarks>
        public static UInt16 ZeroPageY(this Generic cpu)
        {
            UInt16 address = (ushort)((cpu.FetchByte() + cpu.Y) % 256);
            return address;
        }

        /// <summary>
        /// The absolute addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next two bytes in memory</returns>
        /// <remarks>Absolute addressing mode is used for instructions that require an absolute address</remarks>
        public static UInt16 Absolute(this Generic cpu)
        {
            UInt16 addressLow;
            UInt16 addressHigh;
            UInt16 address;

            // Get the low byte of the address
            addressLow = cpu.FetchByte();
            // Get the high byte of the address
            addressHigh = cpu.FetchByte();
            // Combine the two bytes to form the address
            address = (ushort)((addressHigh << 8) | addressLow);

            return address;
        }

        /// <summary>
        /// The absolute X addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next two bytes in memory plus the X register</returns>
        /// <remarks>Absolute X addressing mode is used for instructions that require an absolute address plus the X register</remarks>
        public static UInt16 AbsoluteX(this Generic cpu)
        {
            UInt16 address = (ushort)(cpu.FetchWord() + cpu.X);
            return address;
        }

        /// <summary>
        /// The absolute Y addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next two bytes in memory plus the Y register</returns>
        /// <remarks>Absolute Y addressing mode is used for instructions that require an absolute address plus the Y register</remarks>
        public static UInt16 AbsoluteY(this Generic cpu)
        {
            UInt16 address = (ushort)(cpu.FetchWord() + cpu.Y);
            return address;
        }

        /// <summary>
        /// The indirect addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next two bytes in memory</returns>
        /// <remarks>operand is address; effective address is contents of word at address: C.w($HHLL)</remarks>
        public static UInt16 Indirect(this Generic cpu)
        {
            UInt16 addressLow;
            UInt16 addressHigh;
            UInt16 effectiveLow;
            UInt16 effectiveHigh;
            UInt16 absoluteAddress;
            UInt16 address;

            // Get the low byte of the address
            addressLow = cpu.FetchByte();
            // Get the high byte of the address
            addressHigh = cpu.FetchByte();

            // Calculate the absolute address
            absoluteAddress = (ushort)((addressHigh << 8) | addressLow);

            // Get the low byte of the effective address
            effectiveLow = cpu.ReadMemory(absoluteAddress);
            // Get the high byte of the effective address (implements the Indirect JMP fix for the CMOS 6502)
            effectiveHigh = cpu.ReadMemory((ushort)((absoluteAddress & 0xFF00) | ((absoluteAddress + 1) & 0x00FF)));

            // Calculate the address
            address = ((ushort)(effectiveLow + 0x100 * effectiveHigh));

            // Return the address
            return address;
        }

        /// <summary>
        /// The indirect X addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next byte in memory plus the X register</returns>
        /// <remarks>operand is zeropage address; effective address is word in (LL + X, LL + X + 1), inc. without carry: C.w($00LL + X)</remarks>
        public static UInt16 IndirectX(this Generic cpu)
        {
            UInt16 zeroPageLow;
            UInt16 zeroPageHigh;
            UInt16 address;

            // Get the low byte of the zero page address
            zeroPageLow = (ushort)((cpu.FetchByte() + cpu.X) % 256);
            // Get the high byte of the zero page address
            zeroPageHigh = (ushort)((zeroPageLow + 1) % 256);
            // Get the address
            address = (ushort)(cpu.ReadMemory(zeroPageLow) + (cpu.ReadMemory(zeroPageHigh) << 8));
            // Return the address
            return address;
        }

        /// <summary>
        /// The indirect Y addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The value of the next byte in memory plus the Y register</returns>
        /// <remarks>operand is zeropage address; effective address is word in (LL, LL + 1) incremented by Y with carry: C.w($00LL) + Y</remarks>
        public static UInt16 IndirectY(this Generic cpu)
        {
            UInt16 zeroPageLow;
            UInt16 zeroPageHigh;
            UInt16 address;

            // Get the low byte of the zero page address
            zeroPageLow = cpu.FetchByte();
            // Get the high byte of the zero page address
            zeroPageHigh = (ushort)((zeroPageLow + 1) % 256);
            // Get the address
            address = (ushort)(cpu.ReadMemory(zeroPageLow) + (cpu.ReadMemory(zeroPageHigh) << 8) + cpu.Y);
            // Return the address
            return address;
        }

        /// <summary>
        /// The relative addressing mode
        /// </summary>
        /// <param name="cpu">The CPU</param>
        /// <returns>The address to jump to</returns>
        /// <remarks>Relative addresses are used when branching</remarks>
        public static UInt16 Relative(this Generic cpu)
        {
            UInt16 offset;
            UInt16 address;

            // Get the offset
            offset = cpu.FetchByte();

            // Increment the program counter
            cpu.PC++;

            // Check for negative offset
            if ((offset & 0x80) == 0x80)
            {
                // Negative offset
                offset = (UInt16)(0xFF00 | offset);
            }

            // Calculate the address
            address = (UInt16)(cpu.PC + offset);

            // Check for page-boundary crossing
            if ((address & 0xFF00) != (cpu.PC & 0xFF00))
            {
                // Page-boundary crossing
                cpu.Cycles++;
            }

            // Return the address
            return address;
        }

        public static UInt16 GetAddress(this Generic cpu)
        {
            Instruction instruction = cpu.CurrentInstruction!;
            // Get the addressing mode
            switch (instruction!.AddressingMode)
            {
                case AddressingModes.Accumulator:
                    return cpu.Accumulator();
                case AddressingModes.Immediate:
                    return cpu.Immediate();
                case AddressingModes.ZeroPage:
                    return cpu.ZeroPage();
                case AddressingModes.ZeroPageX:
                    return cpu.ZeroPageX();
                case AddressingModes.ZeroPageY:
                    return cpu.ZeroPageY();
                case AddressingModes.Absolute:
                    return cpu.Absolute();
                case AddressingModes.AbsoluteX:
                    return cpu.AbsoluteX();
                case AddressingModes.AbsoluteY:
                    return cpu.AbsoluteY();
                case AddressingModes.Indirect:
                    return cpu.Indirect();
                case AddressingModes.IndirectX:
                    return cpu.IndirectX();
                case AddressingModes.IndirectY:
                    return cpu.IndirectY();
                case AddressingModes.Relative:
                    return cpu.Relative();
                default:
                    throw new NotImplementedException("Addressing mode not implemented");
            }
        }
    }
}