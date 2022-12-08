using static System.Console;

WriteLine(SequenceOfNotRepeatingChars(
    File.ReadAllText("input.txt"), 
    4));
WriteLine(SequenceOfNotRepeatingChars(
    File.ReadAllText("input.txt"),
    14));

int SequenceOfNotRepeatingChars(string str, int nDistinctChars)
{
    for (int i = 0; i < str.Length; i++)
    {
        var set = new HashSet<char>(){ str[i] };
        for (var j = i + 1; j < str.Length; j++)
        {
            if(set.Contains(str[j]))
                break;
            set.Add(str[j]);
            if (set.Count == 4)
                return j + 1;
        }
    }

    return -1;
}
