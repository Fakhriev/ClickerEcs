using Leopotam.Ecs;

public class BusinessParametresSetSystem : IEcsInitSystem
{
    private readonly SceneData _sceneData;
    private readonly GameStatsContainer _statsContainer;

    public void Init()
    {
        for (int i = 0; i < _sceneData.Businesses.Length; i++)
        {
            Business business = _sceneData.Businesses[i];
            SetBusinessStartParametres(business.Entity, _statsContainer.BusinessesStats[i]);
        }
    }

    private void SetBusinessStartParametres(EcsEntity businessEntity, BusinessStats businessesStats)
    {
        if(businessesStats.level > 0)
        {
            ref LevelUpComponent luComponent = ref businessEntity.Get<LevelUpComponent>();
            luComponent.increaseValue = businessesStats.level;
        }

        ref IncomeProgressComponent ipComponent = ref businessEntity.Get<IncomeProgressComponent>();
        ipComponent.incomeProgress = businessesStats.incomeProgress;

        if (businessesStats.hasUpgrade1)
            businessEntity.Get<AddUpgrade1Tag>();

        if(businessesStats.hasUpgrade2)
            businessEntity.Get<AddUpgrade2Tag>();
    }
}