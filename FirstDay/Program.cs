using var client = new HttpClient();
var lines = File.ReadAllLines("input.txt");
var caloriesForEachElf = GetListOfCaloriesForEveryElf(lines);
var totalList = caloriesForEachElf.Select(x => x.Sum()).OrderDescending().ToList();
Console.WriteLine(totalList[0] + totalList[1] + totalList[2]);
List<List<long>> GetListOfCaloriesForEveryElf(string[] list)
{
    var caloriesForElves = new List<List<long>>();
    var currList = new List<long>();
    foreach (var item in list)
    {
        if (item == "")
        {
            currList = new List<long>();
            caloriesForElves.Add(currList);
        }
            
        else
            currList.Add(long.Parse(item));
    }

    return caloriesForElves;
}

