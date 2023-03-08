namespace Butterfly.Machine.Devices
{
    public class ROM
    {
        // ROM is top 16 KB of address space
        public const UInt16 ROMBaseAddress = 0xBFFF; // Start of read-only memory address space
        public const UInt16 ROMEndAddress = 0xFFFF; // End of read-only memory address space
        public byte[] ROMData; // Read-only memory

        /// <summary>
        /// Butterfly read-only memory
        /// </summary>
        /// <remarks>
        /// This is the read-only memory for the Butterfly machine. It is responsible for handling all read-only memory operations.
        /// </remarks>
        public ROM()
        {
            ROMData = new byte[ROMEndAddress - ROMBaseAddress + 1];
        }

        /// <summary>
        /// Read a byte from read-only memory
        /// </summary>
        /// <param name="address">The address to read from</param>
        /// <returns>The memory at the address</returns>
        public byte ReadMemory(UInt16 address)
        {
            return ROMData[address - ROMBaseAddress];
        }

        public UInt16 RomSize()
        {
            return (UInt16)ROMData.Length;
        }

        public void LoadROM(string filename)
        {
            try
            {
                // Open the file
                FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);

                // Read the file into the ROM, one byte at a time
                for (int i = 0; i < ROMData.Length; i++)
                {
                    ROMData[i] = (byte)file.ReadByte();
                }
            }
            catch (Exception e)
            {
                // We got an error, so we can't load the ROM
                throw new Exception("Error loading ROM: " + e.Message);
            }
        }
    }
}