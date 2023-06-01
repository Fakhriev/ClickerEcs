using Leopotam.Ecs;

public class UpdateLevelUpCostSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<BusinessCostsComponent, BusinessIncomeDataComponent, UpdateLevelUpCostTag> _filter;
    private readonly ILevelUpCostCalculator _levelUpCostCalculator;

    public void Init()
    {
        UpdateLevelUpCost();
    }

    public void Run()
    {
        UpdateLevelUpCost();
    }

    private void UpdateLevelUpCost()
    {
        foreach(var i in _filter)
        {
            ref BusinessCostsComponent bcComponent = ref _filter.Get1(i);
            ref BusinessIncomeDataComponent icdComponent = ref _filter.Get2(i);
            bcComponent.levelCost = _levelUpCostCalculator.Calculate(icdComponent.level, bcComponent.baseCost);
            SetUpdateTMPComponent(_filter.GetEntity(i), bcComponent.levelCost);
        }
    }

    private void SetUpdateTMPComponent(EcsEntity entity, int value)
    {
        ref UpdateBusinessTMPComponent ubtmp = ref entity.Get<UpdateBusinessTMPComponent>();
        ubtmp.levelUpCost = value;
    }
}
