using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private BusinessesParametresLoader BusinessesParametresLoader;
    [SerializeField] private BusinessesParametresSaver BusinessesParametresSaver;
    [SerializeField] private EcsStarter EcsStarter;

    private void Start()
    {
        IDataBase dataBase = CreateDataBase();
        BusinessesParametresLoader.Init(dataBase);
        BusinessesParametresSaver.Init(dataBase);
        EcsStarter.Init(CreateIncomeCalculator(), CreateLevelUpCostCalculator(), BusinessesParametresLoader.StatsContainer, 
            dataBase, BusinessesParametresSaver);
    }

    private IDataBase CreateDataBase()
    {
        return new BinaryDataBase();
    }

    private IIncomeCalculator CreateIncomeCalculator()
    {
        return new DefaultIncomeCalculator();
    }

    private ILevelUpCostCalculator CreateLevelUpCostCalculator()
    {
        return new DefaultLevelUpCostCalculator();
    }
}