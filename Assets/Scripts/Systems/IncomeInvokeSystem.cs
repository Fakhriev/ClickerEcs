using Leopotam.Ecs;

public class IncomeInvokeSystem : IEcsRunSystem
{
    private readonly EcsFilter<BusinessIncomeDataComponent, IncomeValueChangeTag> _filter;
    private readonly EcsFilter<BalanceComponent> _balanceFilter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref BusinessIncomeDataComponent bidComponent = ref _filter.Get1(i);
            SetBalanceChangeComponent(bidComponent.finalIncome);
        }
    }

    private void SetBalanceChangeComponent(int value)
    {
        EcsEntity balanceEntity = _balanceFilter.GetEntity(0);
        ref BalanceChangeComponent bcComponent = ref balanceEntity.Get<BalanceChangeComponent>();
        bcComponent.value += value;
    }
}