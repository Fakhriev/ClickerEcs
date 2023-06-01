using Leopotam.Ecs;

public class BusinessCreateSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly SceneData _sceneData;
    private readonly ProjectData _projectData;

    public void Init()
    {
        for (int i = 0; i < _sceneData.Businesses.Length; i++)
        {
            Business business = _sceneData.Businesses[i];
            CreateEntityForBusiness(business, 
                _projectData.BusinessNamesConfig.BusinessNames[i], 
                _projectData.BusinessesIncomeConfig.BusinessesIncomeParametres[i]);
        }
    }

    private void CreateEntityForBusiness(Business business, BusinessNames names, BusinessIncomeParametres incomeParametres)
    {
        EcsEntity businessEntity = _world.NewEntity();
        business.Init(businessEntity, names, incomeParametres);

        SetBusinessName(businessEntity, business);
        SetBusinessUpgradesComponent(businessEntity, business);
        SetBusinessCostsComponent(businessEntity, business);
        SetBusinessTMPComponent(businessEntity, business);
        SetIncomeCalculateDataComponent(businessEntity, business);
        SetIncomeProgressComponent(businessEntity, business);
        SetTagComponents(businessEntity);
    }

    private void SetBusinessName(EcsEntity businessEntity, Business business)
    {
        ref UpdateBusinessTMPComponent ubtmpComponent = ref businessEntity.Get<UpdateBusinessTMPComponent>();
        ubtmpComponent.businessName = business.BusinessNames.Name;
    }

    private void SetBusinessUpgradesComponent(EcsEntity businessEntity, Business business)
    {
        ref BusinessUpgradesComponent buComponent = ref businessEntity.Get<BusinessUpgradesComponent>();
        buComponent.upgrade1Name = business.BusinessNames.Upgrade1Name;
        buComponent.upgrade2Name = business.BusinessNames.Upgrade2Name;
        buComponent.hasUpgrade1 = false;
        buComponent.hasUpgrade2 = false;
        buComponent.upgrade1Multiply = business.BusinessIncomeParametres.upgrade1.incomeMultiplyier;
        buComponent.upgrade2Multiply = business.BusinessIncomeParametres.upgrade2.incomeMultiplyier;
    }

    private void SetBusinessCostsComponent(EcsEntity businessEntity, Business business)
    {
        ref BusinessCostsComponent bcComponent = ref businessEntity.Get<BusinessCostsComponent>();
        bcComponent.baseCost = business.BusinessIncomeParametres.baseCost;
        bcComponent.upgrade1Cost = business.BusinessIncomeParametres.upgrade1.cost;
        bcComponent.upgrade2Cost = business.BusinessIncomeParametres.upgrade2.cost;
    }

    private void SetBusinessTMPComponent(EcsEntity businessEntity, Business business)
    {
        ref BusinessTMPComponent btmpComponent = ref businessEntity.Get<BusinessTMPComponent>();
        btmpComponent.tmpName = business.BusinessMonoComponents.tmpName;
        btmpComponent.tmpLevel = business.BusinessMonoComponents.tmpLevel;
        btmpComponent.tmpIncome = business.BusinessMonoComponents.tmpIncome;
        btmpComponent.tmpLevelUpButton = business.BusinessMonoComponents.btnLevelUp.tmp;
        btmpComponent.tmpUpgrade1Button = business.BusinessMonoComponents.btnUpgrade1.tmp;
        btmpComponent.tmpUpgrade2Button = business.BusinessMonoComponents.btnUpgrade2.tmp;
    }

    private void SetIncomeCalculateDataComponent(EcsEntity businessEntity, Business business)
    {
        ref BusinessIncomeDataComponent icdComponent = ref businessEntity.Get<BusinessIncomeDataComponent>();
        icdComponent.baseIncome = business.BusinessIncomeParametres.baseIncome;
        icdComponent.incomeMultiplyier1 = 0;
        icdComponent.incomeMultiplyier2 = 0;
    }

    private void SetIncomeProgressComponent(EcsEntity businessEntity, Business business)
    {
        ref IncomeProgressComponent ipComponent = ref businessEntity.Get<IncomeProgressComponent>();
        ipComponent.incomeProgress = 0f;
        ipComponent.incomeProgressIncreaseSpeed = 1f / business.BusinessIncomeParametres.incomeDelay;
        ipComponent.progressFill = business.BusinessMonoComponents.barFillImage;
    }

    private void SetTagComponents(EcsEntity businessEntity)
    {
        businessEntity.Get<DisabledBusinessTag>();
        businessEntity.Get<IncomeValueRecalculateTag>();
        businessEntity.Get<UpdateUpgradesCostTag>();
        businessEntity.Get<UpdateLevelUpCostTag>();
    }
}