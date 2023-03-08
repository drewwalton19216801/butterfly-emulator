namespace Butterfly.Machine.Devices
{
    public class MemoryController
    {
        public RAM RAM;
        public IOController IOController;
        public VideoController VideoController;
        public ROM ROM;

        public MemoryController()
        {
            RAM = new RAM();
            IOController = new IOController();
            VideoController = new VideoController();
            ROM = new ROM();
        }

        public byte ReadMemory(UInt16 address)
        {
            if (address >= RAM.RAMBaseAddress && address <= RAM.RAMEndAddress)
            {
                return RAM.ReadMemory(address);
            }
            else if (address >= IOController.IOControllerBaseAddress && address <= IOController.IOControllerEndAddress)
            {
                return IOController.ReadMemory(address);
            }
            else if (address >= VideoController.VideoControllerBaseAddress && address <= VideoController.VideoControllerEndAddress)
            {
                return VideoController.ReadMemory(address);
            }
            else if (address >= ROM.ROMBaseAddress && address <= ROM.ROMBaseAddress + ROM.RomSize())
            {
                return ROM.ReadMemory(address);
            }
            else
            {
                throw new Exception("Invalid memory address");
            }
        }

        public void WriteMemory(UInt16 address, byte value)
        {
            if (address >= RAM.RAMBaseAddress && address <= RAM.RAMEndAddress)
            {
                RAM.WriteMemory(address, value);
            }
            else if (address >= IOController.IOControllerBaseAddress && address <= IOController.IOControllerEndAddress)
            {
                IOController.WriteMemory(address, value);
            }
            else if (address >= VideoController.VideoControllerBaseAddress && address <= VideoController.VideoControllerEndAddress)
            {
                VideoController.WriteMemory(address, value);
            }
            else if (address >= ROM.ROMBaseAddress && address <= ROM.ROMBaseAddress + ROM.RomSize())
            {
                throw new Exception("Cannot write to ROM");
            }
            else
            {
                throw new Exception("Invalid memory address");
            }
        }

        public void LoadROM(string filename)
        {
            ROM.LoadROM(filename);
        }

        public string GetMemoryMap()
        {
            string memoryMap = "";
            memoryMap += "RAM: " + RAM.RAMBaseAddress.ToString("X4") + " - " + RAM.RAMEndAddress.ToString("X4")
                + " (" + RAM.RAMData.Length.ToString() + " bytes)" + Environment.NewLine;
            memoryMap += "IO Controller: " + IOController.IOControllerBaseAddress.ToString("X4") + " - " + IOController.IOControllerEndAddress.ToString("X4")
                + " (" + IOController.IOControllerData.Length.ToString() + " bytes)" + Environment.NewLine;
            memoryMap += "Video Controller: " + VideoController.VideoControllerBaseAddress.ToString("X4") + " - " + VideoController.VideoControllerEndAddress.ToString("X4")
                + " (" + VideoController.VideoControllerData.Length.ToString() + " bytes)" + Environment.NewLine;
            memoryMap += "ROM: " + ROM.ROMBaseAddress.ToString("X4") + " - " + (ROM.ROMBaseAddress + ROM.RomSize()).ToString("X4")
                + " (" + ROM.RomSize().ToString() + " bytes)" + Environment.NewLine;
            return memoryMap;
        }
    }
}