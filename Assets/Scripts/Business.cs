using Leopotam.Ecs;
using UnityEngine;

public class Business: MonoBehaviour
{
    public BusinessMonoComponents BusinessMonoComponents;

    public BusinessNames BusinessNames;
    public BusinessIncomeParametres BusinessIncomeParametres;

    public EcsEntity Entity { get; private set; }

    public void Init(EcsEntity entity, BusinessNames names, BusinessIncomeParametres incomeParametres)
    {
        Entity = entity;
        BusinessNames = names;
        BusinessIncomeParametres = incomeParametres;
    }

    #region Invoke from UI

    public void OnLevelUpClicked()
    {
        Entity.Get<TryLevelUpTag>();
    }

    public void OnUpgrade1Clicked()
    {
        Entity.Get<TryUpgrade1Tag>();
    }

    public void OnUpgrade2Clicked()
    {
        Entity.Get<TryUpgrade2Tag>();
    }

    #endregion
}