using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SaveData(int health, int maxHealth)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/health.f";
        FileStream stream = new FileStream(path, FileMode.Create);

        Init data = new Init(health, maxHealth);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Init LoadHealth()
    {
        string path = Application.persistentDataPath + "/health.f";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Init data = formatter.Deserialize(stream) as Init;
            stream.Close();

            return data;

        } else 
        {
            Debug.Log("save not found in" + path);
            return null;
        }
    }

}
