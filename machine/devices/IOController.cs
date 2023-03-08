namespace Butterfly.Machine.Devices
{
    // TODO: Actually implement an IO controller
    public class IOController
    {
        public UInt16 IOControllerBaseAddress = 0x8000; // Start of IO controller address space
        public UInt16 IOControllerEndAddress =  0x80FF; // End of IO controller address space

        public byte[] IOControllerData; // IO controller memory

        /// <summary>
        /// Butterfly IO controller
        /// </summary>
        /// <remarks>
        /// This is the IO controller for the Butterfly machine. It is responsible for handling all IO operations.
        /// </remarks>
        public IOController()
        {
            IOControllerData = new byte[IOControllerEndAddress - IOControllerBaseAddress + 1];
        }

        /// <summary>
        /// Read a byte from IO controller memory
        /// </summary>
        /// <param name="address">The address to read from</param>
        /// <returns>The memory at the address</returns>
        public byte ReadMemory(UInt16 address)
        {
            // TODO: Implement IO controller read, just read from memory for now
            return IOControllerData[address - IOControllerBaseAddress];
        }

        /// <summary>
        /// Write a byte to IO controller memory
        /// </summary>
        /// <param name="address">The address to write to</param>
        /// <param name="value">The value to write</param>
        public void WriteMemory(UInt16 address, byte value)
        {
            // TODO: Implement IO controller write, just write to memory for now
            IOControllerData[address - IOControllerBaseAddress] = value;
        }
    }
}