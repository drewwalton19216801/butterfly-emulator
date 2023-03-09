using Butterfly.Machine;

ButterflyMachine butterfly = new ButterflyMachine();

// Print the memory map
Console.WriteLine("Memory map:");
Console.WriteLine(butterfly.MemoryController.GetMemoryMap());

// Ask the user for a path to a .bin file
Console.Write("Enter path to .bin file: ");
string path = Console.ReadLine()!;

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

// Ask the user to specify the CPU speed (in MHz)
Console.Write("Enter CPU speed (in MHz): ");
string speed = Console.ReadLine()!;

// Check for null or empty string
if (string.IsNullOrEmpty(speed))
{
    Console.WriteLine("Invalid speed.");
    return;
}

// Convert the speed to a double
double speedDouble = double.Parse(speed);

// Set the CPU speed
butterfly.CPU.ClockSpeed = speedDouble;

butterfly.Reset();

Console.WriteLine();

butterfly.Run();