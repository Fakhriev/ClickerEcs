using Leopotam.Ecs;

public class IncomeRecalculateSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<BusinessIncomeDataComponent, IncomeValueRecalculateTag> _filter;
    private readonly IIncomeCalculator _incomeCalculator;

    public void Init()
    {
        RecalculateIncome();
    }

    public void Run()
    {
        RecalculateIncome();
    }

    private void RecalculateIncome()
    {
        foreach(var i in _filter)
        {
            ref BusinessIncomeDataComponent bidComponent = ref _filter.Get1(i);
            bidComponent.finalIncome = _incomeCalculator.Calculate(bidComponent);
            SetUpdateTMPComponent(_filter.GetEntity(i), bidComponent.finalIncome);
        }
    }
    private void SetUpdateTMPComponent(EcsEntity entity, int income)
    {
        ref UpdateBusinessTMPComponent ubtmp = ref entity.Get<UpdateBusinessTMPComponent>();
        ubtmp.income = income;
    }
}
