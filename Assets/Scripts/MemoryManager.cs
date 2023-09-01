using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MemoryManager : MonoBehaviour
{
    public static MemoryManager Instance;

    public int highScore;
    public string playerName;
    public string highScorePlayerName;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
        public string highScorePlayerName;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;
        data.highScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSavedData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
}
