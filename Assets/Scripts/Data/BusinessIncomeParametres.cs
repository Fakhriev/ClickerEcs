using UnityEngine;

[System.Serializable]
public class BusinessIncomeParametres
{
    [Header("Business Income Parametres")]
    public float incomeDelay;

    public int baseCost;
    public int baseIncome;

    public UpgradeIncomeData upgrade1;
    public UpgradeIncomeData upgrade2;
}