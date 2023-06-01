using UnityEngine;

[CreateAssetMenu(fileName = "Businesses Income Config", menuName = "Settings/New Businesses Income Config", order = 51)]
public class BusinessesIncomeConfig: ScriptableObject
{
    public BusinessIncomeParametres[] BusinessesIncomeParametres;
}