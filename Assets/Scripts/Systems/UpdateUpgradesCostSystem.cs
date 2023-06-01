using Leopotam.Ecs;
using System;

public class UpdateUpgradesCostSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<BusinessCostsComponent, BusinessUpgradesComponent> _filter;

    public void Init()
    {
        UpdateUpgradesCost();
    }

    public void Run()
    {
        UpdateUpgradesCost();
    }

    private void UpdateUpgradesCost()
    {
        foreach(var i in _filter)
        {
            ref BusinessCostsComponent bcComponent = ref _filter.Get1(i);
            ref BusinessUpgradesComponent buComponent = ref _filter.Get2(i);

            int? cost1 = buComponent.hasUpgrade1 ? null : bcComponent.upgrade1Cost;
            int? cost2 = buComponent.hasUpgrade2 ? null : bcComponent.upgrade2Cost;

            float multiply1 = buComponent.upgrade1Multiply;
            float multiply2 = buComponent.upgrade2Multiply;

            SetUpdateTMPComponent(_filter.GetEntity(i), buComponent.upgrade1Name, buComponent.upgrade2Name, cost1, cost2, multiply1, multiply2);
        }
    }

    private void SetUpdateTMPComponent(EcsEntity entity, string name1, string name2, int? cost1, int? cost2, float multiply1, float multiply2)
    {
        ref UpdateBusinessTMPComponent ubtmpComponent = ref entity.Get<UpdateBusinessTMPComponent>();
        ubtmpComponent.upgrade1Name = name1;
        ubtmpComponent.upgrade2Name = name2;
        ubtmpComponent.upgrade1Cost = cost1;
        ubtmpComponent.upgrade2Cost = cost2;
        ubtmpComponent.upgrade1Multiply = multiply1;
        ubtmpComponent.upgrade2Multiply = multiply2;
    }
}