using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance;

    public int HighScore;
    public string BestPlayer;
    public string CurruntPlayer;

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


    public void SetBest(int score, string playerName)
    {
        if (HighScore < score)
        {
            HighScore = score;
            BestPlayer = playerName;
            SavePlayer(score, playerName);
        }
    }

    // save in local storage
    public void SavePlayer(int score, string name)
    {
        SaveData saveData = new SaveData();
        saveData.name = BestPlayer;
        saveData.score = HighScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(json);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.name;
            HighScore = data.score;
        }
    }
}

[System.Serializable]
class SaveData
{
    public string name;
    public int score;
}

