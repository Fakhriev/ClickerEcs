using Leopotam.Ecs;

public class AddUpgradeSystem : IEcsRunSystem
{
    private readonly EcsFilter<BusinessUpgradesComponent, BusinessIncomeDataComponent, AddUpgrade1Tag> _filter1;
    private readonly EcsFilter<BusinessUpgradesComponent, BusinessIncomeDataComponent, AddUpgrade2Tag> _filter2;

    public void Run()
    {
        AddUpgrade();
    }

    private void AddUpgrade()
    {
        foreach (var i in _filter1)
        {
            ref BusinessUpgradesComponent buComponent = ref _filter1.Get1(i);
            ref BusinessIncomeDataComponent icdComponent = ref _filter1.Get2(i);

            buComponent.hasUpgrade1 = true;
            icdComponent.incomeMultiplyier1 = buComponent.upgrade1Multiply;

            SetUpgradeChanceComponents(_filter1.GetEntity(i));
        }

        foreach (var i in _filter2)
        {
            ref BusinessUpgradesComponent buComponent = ref _filter2.Get1(i);
            ref BusinessIncomeDataComponent icdComponent = ref _filter2.Get2(i);

            buComponent.hasUpgrade2 = true;
            icdComponent.incomeMultiplyier2 = buComponent.upgrade2Multiply;

            SetUpgradeChanceComponents(_filter2.GetEntity(i));
        }
    }

    private void SetUpgradeChanceComponents(EcsEntity entity)
    {
        entity.Get<UpdateUpgradesCostTag>();
        entity.Get<IncomeValueRecalculateTag>();
    }
}