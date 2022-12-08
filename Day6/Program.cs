using static System.Console;

WriteLine(NumberOfProcessedCharsToFindUniqueSeq(
    File.ReadAllText("input.txt"), 
    4));
WriteLine(NumberOfProcessedCharsToFindUniqueSeq(
    File.ReadAllText("input.txt"),
    14));

int NumberOfProcessedCharsToFindUniqueSeq(string str, int nDistinctChars)
{
    for (var i = 0; i < str.Length; i++)
    {
        if (str.Substring(i, nDistinctChars).ToCharArray().Distinct().Count().Equals(nDistinctChars))
            return i + nDistinctChars;
    }
    return -1;
}
