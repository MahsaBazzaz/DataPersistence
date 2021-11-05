using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public int health;

    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }
    public void Save()
    {
        // Save data into external file
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            // Don't save a MonoBehaviour class
            // make a clean Serializable class instead
            PlayerData data = new PlayerData();
            data.health = health;

            bf.Serialize(file, data);
            file.Close();
        }
        else
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
            PlayerData data = new PlayerData();
            data.health = health;

            bf.Serialize(file, data);
            file.Close();
        }

    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
        }
    }
}

[Serializable]
class PlayerData
{
    public int health;
}