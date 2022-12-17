//find the directories with size < 100000
Console.WriteLine("Analyzing input.txt...");
var lines = File.ReadAllLines("input.txt");
var rootDirectory = new Directory("root", null);
var currentDirectory = rootDirectory;
var allDirectories = new List<Directory>();

for (var i = 0; i < lines.Length; i++)
{
    var strList = lines[i].Split(' ');
    var (dollarSign, command, arg) =  ("", strList[1], strList.Length > 2 ? strList[2] : "");
    switch (command)
    {
        case "cd":
            currentDirectory = arg switch
            {
                "/" => rootDirectory,
                ".." => currentDirectory.Parent ?? currentDirectory,
                _ => currentDirectory.Subdirectories.First(d => d.Name == arg)
            };
            break;
        case "ls":
            var lsOutputs = lines.Skip(i + 1).TakeWhile(l => !l.StartsWith("$")).ToArray();
            i += lsOutputs.Count();
            foreach (var lsOutput in lsOutputs)
            {
                var itemParts = lsOutput.Split(' ');
                switch (itemParts[0])
                {
                    case "dir":
                        var subDirectory = new Directory(itemParts[1], currentDirectory);
                        currentDirectory.Subdirectories.Add(subDirectory);
                        allDirectories.Add(subDirectory);
                        break;
                    default:
                        currentDirectory.Size += int.Parse(itemParts[0]);
                        break;
                };
            }
            break;
    }
}
//Task 1
var totalSumLessThan100000 = allDirectories.Select(CalculateDirectorySize).Where(dirSize => dirSize <= 100000).Sum();
Console.WriteLine($"Answer for task 1: {totalSumLessThan100000}");
//Task 2

const int totalCapacity = 70_000_000;
const int spaceRequired = 30_000_000;
var spaceUsed = CalculateDirectorySize(rootDirectory);
var spaceRemaining = totalCapacity - spaceUsed;

var (smallestDirName, size) = allDirectories
    .Select(d => (Directory: d, Size: CalculateDirectorySize(d)))
    .Where(x => spaceRemaining + x.Size >= spaceRequired)
    .MinBy(x => x.Size);
Console.WriteLine($"Answer for task 2: smallest dir size is {size}");


int CalculateDirectorySize(Directory directory) =>
    directory.Subdirectories.Any()
        ? directory.Size + directory.Subdirectories.Sum(CalculateDirectorySize)
        : directory.Size;

public record Directory
{
    public Directory(string name, Directory? parent)
    {
        Name = name;
        Parent = parent;
    }
    public string Name { get; set; }
    public Directory? Parent { get; set; }
    public ICollection<Directory> Subdirectories { get; set; } = new List<Directory>();
    public int Size { get; set; }
}