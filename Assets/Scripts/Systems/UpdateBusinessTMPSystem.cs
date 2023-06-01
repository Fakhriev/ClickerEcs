using Leopotam.Ecs;

public class UpdateBusinessTMPSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<BusinessTMPComponent, UpdateBusinessTMPComponent> _filter;

    public void Init()
    {
        UpdateTMP();
    }

    public void Run()
    {
        UpdateTMP();
    }

    private void UpdateTMP()
    {
        foreach(var i in _filter)
        {
            ref BusinessTMPComponent btmpComponent = ref _filter.Get1(i);
            ref UpdateBusinessTMPComponent ubtmpComponent = ref _filter.Get2(i);

            btmpComponent.tmpName.text = ubtmpComponent.businessName != null ? ubtmpComponent.businessName : btmpComponent.tmpName.text;

            btmpComponent.tmpLevel.text = ubtmpComponent.level.HasValue ? GetLevelText(ubtmpComponent.level.Value) : btmpComponent.tmpLevel.text;
            btmpComponent.tmpIncome.text = ubtmpComponent.income.HasValue ? GetIncomeText(ubtmpComponent.income.Value) : btmpComponent.tmpIncome.text;

            btmpComponent.tmpLevelUpButton.text = ubtmpComponent.levelUpCost.HasValue ? GetLevelUpButtonText(ubtmpComponent.levelUpCost.Value) : btmpComponent.tmpLevelUpButton.text;

            btmpComponent.tmpUpgrade1Button.text = ubtmpComponent.upgrade1Multiply.HasValue
                ? GetUpgradeButtonText(ubtmpComponent.upgrade1Name, ubtmpComponent.upgrade1Multiply.Value, ubtmpComponent.upgrade1Cost)
                : btmpComponent.tmpUpgrade1Button.text;

            btmpComponent.tmpUpgrade2Button.text = ubtmpComponent.upgrade2Multiply.HasValue
                ? GetUpgradeButtonText(ubtmpComponent.upgrade2Name, ubtmpComponent.upgrade2Multiply.Value, ubtmpComponent.upgrade2Cost)
                : btmpComponent.tmpUpgrade2Button.text;
        }

    }

    private string GetLevelText(int value)
    {
        return $"LVL {System.Environment.NewLine} {value}";
    }

    private string GetIncomeText(int value)
    {
        return $"Income {System.Environment.NewLine} {value}$";
    }

    private string GetLevelUpButtonText(int value)
    {
        return $"LVL UP {System.Environment.NewLine} Cost: {value}$";
    }

    private string GetUpgradeButtonText(string name, float multyply, int? cost)
    {
        return $"{name} {System.Environment.NewLine} Income: +{multyply}% {System.Environment.NewLine} {GetUpgradeCostText(cost)}";
    }

    private string GetUpgradeCostText(int? cost)
    {
        return cost.HasValue ? $"Cost: {cost.Value}$" : "Bought";
    }
}