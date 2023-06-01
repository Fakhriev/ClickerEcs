using Leopotam.Ecs;

public class TryLevelUpSystem : IEcsRunSystem
{
    private readonly EcsFilter<BusinessCostsComponent, TryLevelUpTag> _filter;
    private readonly EcsFilter<BalanceComponent> _balanceFilter;

    public void Run()
    {
        TryIncreaseLevel();
    }

    private void TryIncreaseLevel()
    {
        foreach(var i in _filter)
        {
            ref BalanceComponent bComponent = ref _balanceFilter.Get1(0);
            ref BusinessCostsComponent businessCostsComponent = ref _filter.Get1(i);

            if(bComponent.value >= businessCostsComponent.levelCost)
            {
                bComponent.value -= businessCostsComponent.levelCost;
                SetLevelChangeComponents(_filter.GetEntity(i));
                _balanceFilter.GetEntity(0).Get<BalanceChangeComponent>();
            }
        }
    }

    private void SetLevelChangeComponents(EcsEntity entity)
    {
        ref LevelUpComponent luComponent = ref entity.Get<LevelUpComponent>();
        luComponent.increaseValue = 1;
    }
}
