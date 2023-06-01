using Leopotam.Ecs;
using UnityEngine;

public class BusinessesParametresSaver : MonoBehaviour, IBalanceProvider
{
    [SerializeField] private SceneData sceneData;

    private EcsEntity _balanceEntity;
    private IDataBase _dataBase;

    public void Init(IDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    public void Provide(EcsEntity balanceEntity)
    {
        _balanceEntity = balanceEntity;
    }

    [ContextMenu("Save")]
    private void Save()
    {
        BusinessStats[] stats = new BusinessStats[sceneData.Businesses.Length];

        for (int i = 0; i < sceneData.Businesses.Length; i++)
        {
            EcsEntity businessEntity = sceneData.Businesses[i].Entity;
            BusinessStats bStats = new BusinessStats();

            bStats.level = businessEntity.Get<BusinessIncomeDataComponent>().level;
            bStats.incomeProgress = businessEntity.Get<IncomeProgressComponent>().incomeProgress;

            bStats.hasUpgrade1 = businessEntity.Get<BusinessUpgradesComponent>().hasUpgrade1;
            bStats.hasUpgrade2 = businessEntity.Get<BusinessUpgradesComponent>().hasUpgrade2;

            stats[i] = bStats;
        }

        int balance = _balanceEntity.Get<BalanceComponent>().value;
        GameStatsContainer statsContainer = new GameStatsContainer(balance, stats);
        _dataBase.SaveData(statsContainer);

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
            Save();
    }

#if UNITY_EDITOR

    private void OnApplicationQuit()
    {
        Save();
    }

#endif
}