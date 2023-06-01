using UnityEngine;

public interface IIncomeCalculator 
{
    public int Calculate(BusinessIncomeDataComponent bidComponent);
}

public class DefaultIncomeCalculator : IIncomeCalculator
{
    private const bool _showLogs = false;

    public int Calculate(BusinessIncomeDataComponent bidComponent)
    {
        int level = Mathf.Max(1, bidComponent.level);

        if (_showLogs)
        {
            Debug.Log($"{level} * {bidComponent.baseIncome} * (1f + {bidComponent.incomeMultiplyier1 * 0.01f} + {bidComponent.incomeMultiplyier2 * 0.01f})" +
                $" = {Mathf.RoundToInt(level * bidComponent.baseIncome * (1f + bidComponent.incomeMultiplyier1 * 0.01f + bidComponent.incomeMultiplyier2 * 0.01f))}");
        }

        return Mathf.RoundToInt(level * bidComponent.baseIncome * (1f + bidComponent.incomeMultiplyier1 * 0.01f + bidComponent.incomeMultiplyier2 * 0.01f));
    }
}