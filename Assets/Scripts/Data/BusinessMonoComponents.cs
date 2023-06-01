using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BusinessMonoComponents
{
    [Space]
    public TextMeshProUGUI tmpName;
    public Image barFillImage;

    [Space]
    public TextMeshProUGUI tmpLevel;
    public TextMeshProUGUI tmpIncome;

    [Space]
    public TextButton btnLevelUp;
    public TextButton btnUpgrade1;
    public TextButton btnUpgrade2;
}