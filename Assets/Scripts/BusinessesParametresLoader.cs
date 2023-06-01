using UnityEngine;

public class BusinessesParametresLoader : MonoBehaviour
{
    [SerializeField] private GameStartStatsConfig config;

    private IDataBase _dataBase;

    public GameStatsContainer StatsContainer { get; private set; }

    public void Init(IDataBase dataBase)
    {
        _dataBase = dataBase;
        SetGameStartData();
    }

    private void SetGameStartData()
    {
        if (_dataBase.HasSaves)
            LoadStartDataFromSaves();
        else
            SetStartDataFromConfig();
    }

    private void LoadStartDataFromSaves()
    {
        SaveData saveData = _dataBase.LoadSaveData();
        StatsContainer = saveData as GameStatsContainer;
    }

    private void SetStartDataFromConfig()
    {
        StatsContainer = new GameStatsContainer(config.Balance, config.BusinessesStartStats);
    }
}