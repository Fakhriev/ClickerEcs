
public interface ILevelUpCostCalculator
{
    public int Calculate(int level, int baseCost);
}

public class DefaultLevelUpCostCalculator : ILevelUpCostCalculator
{
    public int Calculate(int level, int baseCost)
    {
        return (level + 1) * baseCost;
    }
}
