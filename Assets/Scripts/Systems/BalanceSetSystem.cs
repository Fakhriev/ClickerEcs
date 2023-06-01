using Leopotam.Ecs;

public class BalanceSetSystem : IEcsInitSystem
{
    private readonly EcsFilter<BalanceComponent> _filter;
    private readonly GameStatsContainer _statsContainer;

    public void Init()
    {
        SetBalance(_statsContainer.Balance);
    }

    private void SetBalance(int value)
    {
        ref BalanceChangeComponent bcComponent = ref _filter.GetEntity(0).Get<BalanceChangeComponent>();
        bcComponent.value = value;
    }
}