using System;
using System.Text;

[Serializable]
public class GameStatsContainer: SaveData
{
    public int Balance;
    public BusinessStats[] BusinessesStats;

    public GameStatsContainer(int balance, BusinessStats[] businessStats)
    {
        Balance = balance;
        BusinessesStats = businessStats;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(System.Environment.NewLine);
        sb.Append($"Balance: [{Balance}], ");

        foreach (var bs in BusinessesStats)
        {
            sb.Append(System.Environment.NewLine);
            sb.Append(bs.ToString());
        }

        return sb.ToString();
    }
}