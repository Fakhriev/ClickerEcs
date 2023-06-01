using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class BinaryDataBase : IDataBase
{
    private readonly string _filePath;

    private const bool _showLogs = false;

    public bool HasSaves => File.Exists(_filePath);

    public BinaryDataBase()
    {
        _filePath = Application.persistentDataPath + "/Save.dat";
    }

    public void SaveData(SaveData saveData)
    {
        if(_showLogs)
            Debug.Log($"Save: [{saveData}]");

        using (FileStream fs = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(fs, saveData);
        }
    }

    public SaveData LoadSaveData()
    {
        SaveData data;

        using (FileStream fs = File.Open(_filePath, FileMode.Open))
        {
            object loadData = new BinaryFormatter().Deserialize(fs);
            data = (SaveData)loadData;
        }

        if (_showLogs)
            Debug.Log($"Load: [{data}]");

        return data;
    }

#if UNITY_EDITOR

    [MenuItem("DataBase/Delete", false, 71)]
    private static void DataBaseDelete()
    {
        string _filePath = Application.persistentDataPath + "/Save.dat";

        if (File.Exists(_filePath))
            File.Delete(_filePath);
    }

#endif
}