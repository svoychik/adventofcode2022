namespace DayTwo;

public enum RoundResult { Draw = 3, Lost = 0, Won = 6}
public enum Weapon { Rock = 1, Paper = 2, Scissors = 3}

public static class F
{
    public static int CalculateRoundResult(Weapon weapon, RoundResult roundResult) =>
        ((int)weapon + (int)roundResult);
}
public static class Extensions
{
    public static Weapon ParseWeapon(this string str)
    {
        var lowerStr = str.ToLowerInvariant();
        return lowerStr switch
        {
            "x" or "a" => Weapon.Rock,
            "y" or "b" => Weapon.Paper,
            "z" or "c" => Weapon.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static RoundResult ParseRoundResult(this string str)
    {
        var lowerStr = str.ToLowerInvariant();
        return lowerStr switch
        {
            "x" => RoundResult.Lost,
            "y" => RoundResult.Draw,
            "z" => RoundResult.Won,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static RoundResult GetRoundResult(this Weapon l, Weapon r)
    {
        return (l, r) switch
        {
            (_, _) when l == r => RoundResult.Draw,  
            (Weapon.Paper, Weapon.Rock) => RoundResult.Won,
            (Weapon.Paper, Weapon.Scissors) => RoundResult.Lost,
            (Weapon.Rock, Weapon.Paper) => RoundResult.Lost,
            (Weapon.Rock, Weapon.Scissors) => RoundResult.Won,
            (Weapon.Scissors, Weapon.Paper) => RoundResult.Won,
            (Weapon.Scissors, Weapon.Rock) => RoundResult.Lost,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}