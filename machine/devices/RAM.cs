namespace Butterfly.Machine.Devices
{
    public class RAM
    {
        public const UInt16 RAMBaseAddress = 0x0000; // Start of RAM address space
        public const UInt16 RAMEndAddress = 0x7FFF; // End of RAM address space
        public byte[] RAMData; // RAM

        /// <summary>
        /// Butterfly RAM
        /// </summary>
        /// <remarks>
        /// This is the RAM for the Butterfly machine. It is responsible for handling all RAM operations.
        /// </remarks>
        public RAM()
        {
            RAMData = new byte[RAMEndAddress - RAMBaseAddress + 1];
        }

        /// <summary>
        /// Read a byte from RAM
        /// </summary>
        /// <param name="address">The address to read from</param>
        /// <returns>The memory at the address</returns>
        public byte ReadMemory(UInt16 address)
        {
            return RAMData[address - RAMBaseAddress];
        }

        /// <summary>
        /// Write a byte to RAM
        /// </summary>
        /// <param name="address">The address to write to</param>
        /// <param name="value">The value to write</param>
        public void WriteMemory(UInt16 address, byte value)
        {
            RAMData[address - RAMBaseAddress] = value;
        }
    }
}