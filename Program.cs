using Butterfly.Machine;

ButterflyMachine butterfly = new ButterflyMachine();

// Print the memory map
Console.WriteLine("Memory map:");
Console.WriteLine(butterfly.MemoryController.GetMemoryMap());

// Print the CPU registers
Console.WriteLine("CPU registers:");
Console.WriteLine(butterfly.CPU.GetRegisters());

// Ask the user for a path to a .bin file
Console.Write("Enter path to .bin file: ");
string path = Console.ReadLine();

// Check for null or empty string
if (string.IsNullOrEmpty(path))
{
    Console.WriteLine("Invalid path.");
    return;
}

// Trim the path
path = path.Trim();

// Strip the single quote from the beginning and end of the path
if (path.StartsWith("'") && path.EndsWith("'"))
{
    path = path.Substring(1, path.Length - 2);
}

Console.WriteLine();

// Print the path and exit
Console.WriteLine("Path: " + path);

butterfly.MemoryController.LoadROM(path);

// Print the first 16 bytes of ROM
Console.WriteLine("First 17 bytes of ROM:");
for (int i = 0; i < 17; i++)
{
    Console.Write(butterfly.MemoryController.ReadMemory((UInt16)(butterfly.MemoryController.ROM.ROMBaseAddress + i)).ToString("X2") + " ");
}

Console.WriteLine();

// Print the data in the reset vector (butterfly.resetVector)
Console.WriteLine("Data in reset vector:");
Console.WriteLine(butterfly.MemoryController.ReadMemory(butterfly.resetVector).ToString("X2") + " " + butterfly.MemoryController.ReadMemory((UInt16)(butterfly.resetVector + 1)).ToString("X2"));

butterfly.Reset();
Console.WriteLine();

// Print the CPU registers
Console.WriteLine("CPU registers:");
Console.WriteLine(butterfly.CPU.GetRegisters());
