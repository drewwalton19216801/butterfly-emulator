using Butterfly.Machine;

Console.WriteLine("Hello, 6502 world!");

ButterflyMachine butterfly = new ButterflyMachine();

butterfly.Reset();

// Print the memory map
Console.WriteLine("Memory map:");
Console.WriteLine(butterfly.MemoryController.GetMemoryMap());

// Print the CPU registers
Console.WriteLine("CPU registers:");
Console.WriteLine(butterfly.CPU.GetRegisters());