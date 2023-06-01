using Leopotam.Ecs;

public class BalanceChangeSystem : IEcsRunSystem
{
    private readonly EcsFilter<BalanceComponent, BalanceChangeComponent> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref BalanceComponent bComponent = ref _filter.Get1(i);
            ref BalanceChangeComponent bcComponent = ref _filter.Get2(i);

            bComponent.value += bcComponent.value;
            bComponent.tmpBalance.text = $"Balance: {bComponent.value}$";
        }
    }
}
