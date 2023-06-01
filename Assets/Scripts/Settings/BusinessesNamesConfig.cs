using UnityEngine;

[CreateAssetMenu(fileName = "Businesses Names Config", menuName = "Settings/New Businesses Names Config", order = 51)]
public class BusinessesNamesConfig : ScriptableObject
{
    public BusinessNames[] BusinessNames;
}