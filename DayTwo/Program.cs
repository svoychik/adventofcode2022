/*
X - lose, A - Rock
Y - draw, B - Paper 
Z - win, C - Scissors 
*/

using DayTwo;
using static DayTwo.F;
var rounds = File.ReadAllLines("input.txt").ToList();
Console.WriteLine("Result for task 1");
Console.WriteLine(
    rounds.Select(str =>
    {
        var splitList = str.Split(' ');
        var (myWeapon, opponentWeapon) = (splitList[1].ParseWeapon(), splitList[0].ParseWeapon());
        var roundResult = myWeapon.GetRoundResult(opponentWeapon);
        return CalculateRoundResult(myWeapon, roundResult);
    }).Sum()
);
Console.WriteLine("Result for task 2");
Console.WriteLine(
    rounds.Select(str =>
    {
        var splitList = str.Split(' ');
        var (roundResult, opponentWeapon) = (splitList[1].ParseRoundResult(), splitList[0].ParseWeapon());
        var myWeapon = GetWeaponFor(roundResult, opponentWeapon);
        return CalculateRoundResult(myWeapon, roundResult);
    }).Sum()
);

static Weapon GetWeaponFor(RoundResult roundResult, Weapon weapon)
{
    return (weapon, roundResult) switch
    {
        (_, _) when roundResult == RoundResult.Draw => (Weapon)((int)weapon),
        (Weapon.Paper, RoundResult.Won) => Weapon.Scissors,
        (Weapon.Paper, RoundResult.Lost) => Weapon.Rock,
        (Weapon.Rock, RoundResult.Lost) => Weapon.Scissors,
        (Weapon.Rock, RoundResult.Won) => Weapon.Paper,
        (Weapon.Scissors, RoundResult.Won) => Weapon.Rock,
        (Weapon.Scissors, RoundResult.Lost) => Weapon.Paper,
        _ => throw new ArgumentOutOfRangeException()
    };
}