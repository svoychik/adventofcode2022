static int GetPriority(char c) => char.IsLower(c) ? c - (97) + 1 : c - 65 + 27;
var allLines = File.ReadAllLines("input.txt");
Console.WriteLine(
    allLines.Select(str =>
    {
        var chars1 = str[..(str.Length / 2)].ToCharArray();
        var chars2 = str[(str.Length / 2)..].ToCharArray(); 
        return chars1.Intersect(chars2).Select(GetPriority).Sum();
    }).Sum()
);
Console.WriteLine(
    allLines
        .Chunk(3)
        .Sum(grp => grp[0]
            .Intersect(grp[1])
            .Intersect(grp[2])
            .Sum(GetPriority))
);