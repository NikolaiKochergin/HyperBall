using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private string _filePath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        _filePath = Application.persistentDataPath + "/GameSave.save";

        if (!File.Exists(_filePath))
            File.Create(_filePath).Close();
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            if (saveDataByDefault != null)
                Save(saveDataByDefault);
            return saveDataByDefault;
        }

        var file = File.Open(_filePath, FileMode.Open);
        var saveData = _formatter.Deserialize(file);
        file.Close();
        return saveData;
    }


    public void Save(object saveData)
    {
        var file = File.Open(_filePath, FileMode.Open);
        _formatter.Serialize(file, saveData);
        file.Close();
    }
}
