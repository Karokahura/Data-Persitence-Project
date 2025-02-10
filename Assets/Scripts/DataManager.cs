using System.IO;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string newPlayerName;
    public float playerScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDataFromJson();
    }



    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public float playerScore;
        public string newPlayerName;
    }

    public void SaveDataToJson()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.newPlayerName = newPlayerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFromJson()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            newPlayerName = data.newPlayerName;
            playerScore = data.playerScore;
        }
    }
}
