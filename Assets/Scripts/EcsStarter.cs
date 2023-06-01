using Leopotam.Ecs;
using UnityEngine;

public class EcsStarter : MonoBehaviour
{
    [SerializeField] private SceneData sceneData;
    [SerializeField] private ProjectData projectData;

    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init(IIncomeCalculator incomeCalculator, ILevelUpCostCalculator levelUpCostCalculator, 
        GameStatsContainer statsContainer, IDataBase dataBase, IBalanceProvider balanceProvider)
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        Inject(incomeCalculator, levelUpCostCalculator, statsContainer, dataBase, balanceProvider);
        CreateSystems();
        SetOneFrameComponents();

        _systems.Init();
    }

    private void Inject(IIncomeCalculator incomeCalculator, ILevelUpCostCalculator levelUpCostCalculator, GameStatsContainer statsContainer, 
        IDataBase dataBase, IBalanceProvider balanceProvider)
    {
        _systems
            .Inject(sceneData)
            .Inject(projectData)
            .Inject(incomeCalculator)
            .Inject(levelUpCostCalculator)
            .Inject(statsContainer)
            .Inject(dataBase)
            .Inject(balanceProvider)
            ;
    }

    private void CreateSystems()
    {
        _systems
            .Add(new BusinessCreateSystem())
            .Add(new BusinessParametresSetSystem())

            .Add(new TryLevelUpSystem())
            .Add(new IncreaseLevelSystem())
            .Add(new UpdateLevelUpCostSystem())

            .Add(new TryAddUpgradeSystem())
            .Add(new AddUpgradeSystem())
            .Add(new UpdateUpgradesCostSystem())

            .Add(new IncomeRecalculateSystem())
            .Add(new IncomeProgressSystem())
            .Add(new IncomeInvokeSystem())

            .Add(new BalanceCreateSystem())
            .Add(new BalanceSetSystem())
            .Add(new BalanceChangeSystem())

            .Add(new UpdateBusinessTMPSystem())
            ;
    }

    private void SetOneFrameComponents()
    {
        _systems
            .OneFrame<IncomeValueChangeTag>()
            .OneFrame<IncomeValueRecalculateTag>()
            .OneFrame<BalanceChangeComponent>()
            .OneFrame<TryLevelUpTag>()
            .OneFrame<TryUpgrade1Tag>()
            .OneFrame<TryUpgrade2Tag>()
            .OneFrame<AddUpgrade1Tag>()
            .OneFrame<AddUpgrade2Tag>()
            .OneFrame<LevelUpComponent>()
            .OneFrame<UpdateLevelUpCostTag>()
            .OneFrame<UpdateBusinessTMPComponent>()
            .OneFrame<UpdateUpgradesCostTag>()
            .OneFrame<SaveTag>()
            ;
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}