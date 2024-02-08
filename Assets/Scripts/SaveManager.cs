using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public TMP_InputField inputField;

    public string PlayerName;
    public int HighScore;

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

    [System.Serializable]
    class SaveInfo
    {
        public string name;
        public int highScore;
    }

    public void SaveNameScore()
    {
        SaveInfo info = new SaveInfo();
        info.name = PlayerName;
        info.highScore = HighScore;

        string json = JsonUtility.ToJson(info);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadNameScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo info = JsonUtility.FromJson<SaveInfo>(json);

            PlayerName = info.name;
            HighScore = info.highScore;
        }
    }
}
