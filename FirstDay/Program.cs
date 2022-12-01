var rawText = File.ReadAllText("input.txt");
var caloriesOfElves = rawText
    .Split("\n\n")
    .Select(x => 
        x.Split("\n")
            .Select(int.Parse)
            .Sum())
    .OrderByDescending(x => x)
    .Take(3)
    .ToList();
System.Console.WriteLine(caloriesOfElves.First());
System.Console.WriteLine(caloriesOfElves.Sum());

