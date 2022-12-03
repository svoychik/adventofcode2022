// See https://aka.ms/new-console-template for more informati
Console.WriteLine((int)'A' - 65 + 26 + 1);
Console.WriteLine((int)'a' - (97) + 1);

static int GetPriority(char c) => char.IsLower(c) ? c - (97) + 1 : c - 65 + 26 + 1;
Console.WriteLine(
    File.ReadAllLines("input.txt").Select(str =>
    {
        var str1 = str.Substring(0, str.Length / 2).ToCharArray();
        var str2 = str.Substring(str.Length / 2).ToCharArray(); return str1.Intersect(str2).Select(GetPriority).Sum();

    }).Sum()
);