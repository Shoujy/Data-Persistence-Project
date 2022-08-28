using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger Instance;

    public string inputName;
    public string bestScoreName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    class SaveData
    {
        public string inputName;
        public string bestScoreName;
        public int bestScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.inputName = inputName;
        data.bestScoreName = bestScoreName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            inputName = data.inputName;
            bestScoreName = data.bestScoreName;
            bestScore = data.bestScore;
        }
    }
}
