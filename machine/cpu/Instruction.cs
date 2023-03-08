namespace Butterfly.Machine.CPU
{
    /// <summary>
    /// A single instruction
    /// </summary>
    /// <remarks>
    /// The instruction class stores the information about a single instruction.
    /// </remarks>
    public class Instruction
    {
        /// <summary>
        /// The mnemonic for the instruction
        /// </summary>
        /// <remarks>
        /// The mnemonic is the name of the instruction, such as "LDA" or "STA".
        /// </remarks>
        public string? Mnemonic { get; set; }

        /// <summary>
        /// The opcode for the instruction
        /// </summary>
        /// <remarks>
        /// The opcode is the byte value that identifies the instruction.
        /// </remarks>
        public byte OpCode { get; set; }

        /// <summary>
        /// The number of bytes in the instruction
        /// </summary>
        /// <remarks>
        /// The number of bytes in the instruction is the number of bytes that follow the opcode.
        /// </remarks>
        public byte Bytes { get; set; }

        /// <summary>
        /// The number of cycles the instruction takes
        /// </summary>
        /// <remarks>
        /// The number of cycles the instruction takes is the number of cycles that the instruction takes to execute.
        /// </remarks>
        public byte Cycles { get; set; }

        /// <summary>
        /// The addressing mode for the instruction
        /// </summary>
        /// <remarks>
        /// The addressing mode is the method by which the instruction accesses the data it needs to operate.
        /// </remarks>
        public AddressingModes AddressingMode { get; set; }
    }
}