using Leopotam.Ecs;

public class TryAddUpgradeSystem : IEcsRunSystem
{
    private readonly EcsFilter<BusinessUpgradesComponent, BusinessCostsComponent, TryUpgrade1Tag> _filter1;
    private readonly EcsFilter<BusinessUpgradesComponent, BusinessCostsComponent, TryUpgrade2Tag> _filter2;

    private readonly EcsFilter<BalanceComponent> _balanceFilter;

    public void Run()
    {
        TryIncreaseUpgrade();
    }

    private void TryIncreaseUpgrade()
    {
        ref BalanceComponent bComponent = ref _balanceFilter.Get1(0);

        #region TryBuyUpgrade1

        foreach (var i in _filter1)
        {
            ref BusinessUpgradesComponent buComponent = ref _filter1.Get1(i);

            if (buComponent.hasUpgrade1)
                continue;

            ref BusinessCostsComponent bcComponent = ref _filter1.Get2(i);

            if (bComponent.value >= bcComponent.upgrade1Cost)
            {
                bComponent.value -= bcComponent.levelCost;
                _filter1.GetEntity(i).Get<AddUpgrade1Tag>();
                _balanceFilter.GetEntity(0).Get<BalanceChangeComponent>();
            }
        }

        #endregion

        #region TryBuyUpgrade2

        foreach (var i in _filter2)
        {
            ref BusinessUpgradesComponent buComponent = ref _filter2.Get1(i);

            if (buComponent.hasUpgrade2)
                continue;

            ref BusinessCostsComponent bcComponent = ref _filter2.Get2(i);

            if (bComponent.value >= bcComponent.upgrade2Cost)
            {
                bComponent.value -= bcComponent.levelCost;
                _filter2.GetEntity(i).Get<AddUpgrade2Tag>();
                _balanceFilter.GetEntity(0).Get<BalanceChangeComponent>();
            }
        }

        #endregion
    }
}