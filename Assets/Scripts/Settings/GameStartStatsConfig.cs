using UnityEngine;

[CreateAssetMenu(fileName = "Game Start Stats Config", menuName = "Settings/New Game Start Stats Config", order = 51)]
public class GameStartStatsConfig: ScriptableObject
{
    public int Balance;
    public BusinessStats[] BusinessesStartStats;
}