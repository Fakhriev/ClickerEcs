using System.Text;

[System.Serializable]
public class BusinessStats
{
    public int level;
    public float incomeProgress;

    public bool hasUpgrade1;
    public bool hasUpgrade2;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Level: [{level}], ");
        sb.Append($"Income Progress: [{incomeProgress}], ");
        sb.Append($"Has Upgrade 1: [{hasUpgrade1}], ");
        sb.Append($"Has Upgrade 2: [{hasUpgrade2}]. ");
        return sb.ToString();
    }
}