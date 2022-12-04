var lines = File.ReadAllLines("input.txt").ParsePairs().ToList();
Console.WriteLine(
    lines
        .Count(pairs =>
        {
            var (p1, p2) = (pairs[0], pairs[1]);
            return p1.FullyContains(p2)
                   || p2.FullyContains(p1);
        })
);
Console.WriteLine(
    lines
        .Count(pairs =>
        {
            var (p1, p2) = (pairs[0], pairs[1]);
            return p1.Overlaps(p2);
        })
);

public static class Ext
{
    public static IEnumerable<(int start, int end)[]> ParsePairs(this string[] lines)
    {
        return lines
            .Select(l =>
            {
                var strings = l.Split(',');
                var slot1 = strings[0].Split('-');
                var slot2 = strings[1].Split('-');
                return new[]
                {
                    (start: int.Parse(slot1[0]), end: int.Parse(slot1[1])),
                    (start: int.Parse(slot2[0]), end: int.Parse(slot2[1]))
                };
            });
    }

    //(2-6), (4-8); (4-8), (2-6)
    public static bool Overlaps(this (int start, int end) pair1, (int start, int end) pair2) =>
        pair1.start <= pair2.end && pair1.end >= pair2.start;
        
    //curr: 4-9
    //pair: 5-9
    public static bool FullyContains(this (int start, int end) curr, (int start, int end) pair) =>
        curr.start <= pair.start && curr.end >= pair.end;
}