using Leopotam.Ecs;

public class IncreaseLevelSystem : IEcsRunSystem
{
    private readonly EcsFilter<BusinessIncomeDataComponent, LevelUpComponent> _filter;

    public void Run()
    {
        IncreaseLevel();
    }

    private void IncreaseLevel()
    {
        foreach (var i in _filter)
        {
            ref BusinessIncomeDataComponent icdComponent = ref _filter.Get1(i);
            ref LevelUpComponent luComponent = ref _filter.Get2(i);
            icdComponent.level += luComponent.increaseValue;
            SetLevelChangeComponents(_filter.GetEntity(i), icdComponent.level);

            if (_filter.GetEntity(i).Has<DisabledBusinessTag>())
                _filter.GetEntity(i).Del<DisabledBusinessTag>();
        }
    }

    private void SetLevelChangeComponents(EcsEntity entity, int level)
    {
        ref UpdateBusinessTMPComponent ubtmp = ref entity.Get<UpdateBusinessTMPComponent>();
        ubtmp.level = level;

        entity.Get<UpdateLevelUpCostTag>();
        entity.Get<IncomeValueRecalculateTag>();
    }
}