namespace Butterfly.Machine.Devices
{
    public class VideoController
    {
        // TODO: Actually implement a video controller
        public const UInt16 VideoControllerBaseAddress = 0x8100; // Start of video controller address space
        public const UInt16 VideoControllerEndAddress = 0xBFFF; // End of video controller address space
        public byte[] VideoControllerData; // Video controller memory

        /// <summary>
        /// Butterfly video controller
        /// </summary>
        /// <remarks>
        /// This is the video controller for the Butterfly machine. It is responsible for handling all video operations.
        /// </remarks>
        public VideoController()
        {
            VideoControllerData = new byte[VideoControllerEndAddress - VideoControllerBaseAddress + 1];
        }

        /// <summary>
        /// Read a byte from video controller memory
        /// </summary>
        /// <param name="address">The address to read from</param>
        /// <returns>The memory at the address</returns>
        public byte ReadMemory(UInt16 address)
        {
            return VideoControllerData[address - VideoControllerBaseAddress];
        }

        /// <summary>
        /// Write a byte to video controller memory
        /// </summary>
        /// <param name="address">The address to write to</param>
        /// <param name="value">The value to write</param>
        public void WriteMemory(UInt16 address, byte value)
        {
            VideoControllerData[address - VideoControllerBaseAddress] = value;
        }
    }
}