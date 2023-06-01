public interface IDataBase
{
    public bool HasSaves { get; }

    public void SaveData(SaveData saveData);
    
    public SaveData LoadSaveData();
}