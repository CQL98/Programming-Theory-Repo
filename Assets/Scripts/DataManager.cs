using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string actualPlayerName;
    public int actualIndex;

    [SerializeField] private Collector[] collector;

    private List<PlayerCollector> listCollector = new List<PlayerCollector>();
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

    private void Start()
    {
        LoadPlayerCollector();
    }
    public void StartValues(int idIndex, string playerName)
    {
        actualPlayerName = playerName;
        actualIndex = idIndex;
    }
    public void SpawnCollector(Vector3 position)
    {
        Instantiate(collector[actualIndex], position, collector[actualIndex].transform.rotation);
    }
    public int GetCapacityByCollector()
    {
        return listCollector.FirstOrDefault(item => item.idCollector == actualIndex).capacity;
    }
    public int GetTopScoreByCollector()
    {
        return listCollector.FirstOrDefault(item => item.idCollector == actualIndex).topScore;
    }
    public void LoadPlayerCollector()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ListCollectors list = new ListCollectors();
            list = JsonUtility.FromJson<ListCollectors>(json);
            listCollector = list.listCollector;
        }
        else
        {
          BaseSave();
        }
    }
    public List<PlayerCollector> GetLoadPlayerCollector()
    {
        LoadPlayerCollector();
        return listCollector;
    }
    public string GetNameCollector(int index)
    {
        return FormatString(collector[index].Name,10);
    } 

    public void SavePlayerCollector()
    {
        PlayerCollector collector = this.listCollector.First(item => item.idCollector == actualIndex);
        collector.capacity++;

        ListCollectors list = new ListCollectors();
        list.listCollector = listCollector;

        string json = JsonUtility.ToJson(list);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void SavePlayerCollector(int score, bool addCapacity)
    {
        PlayerCollector collector = this.listCollector.First(item => item.idCollector == actualIndex);
        collector.namePlayer = actualPlayerName;
        collector.topScore = score;
        if (addCapacity)
            collector.capacity++;

        ListCollectors list = new ListCollectors();
        list.listCollector = listCollector;

        string json = JsonUtility.ToJson(list);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    private void BaseSave()
    {
        ListCollectors list = new ListCollectors();
        List<PlayerCollector> auxList = new List<PlayerCollector>();
        for (int i = 0; i < collector.Length; i++)
        {
            PlayerCollector auxItem = new PlayerCollector();
            auxItem.idCollector = collector[i].idCollector;
            auxItem.capacity = collector[i].Capacity;
            auxItem.namePlayer = "";
            auxItem.topScore = 0;
            auxList.Add(auxItem);
        }
        list.listCollector = listCollector = auxList;

        string json = JsonUtility.ToJson(list);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static string FormatString(string name,int lengthMax)
    {
        string textNormalized = name.PadLeft((lengthMax - name.Length) / 2 + name.Length).PadRight(lengthMax);
        return textNormalized;
    }
    public static string FormatString(int value, int lengthMax)
    {
        string textNormalized = value.ToString();
        textNormalized = textNormalized.PadLeft((lengthMax - textNormalized.Length) / 2 + textNormalized.Length).PadRight(lengthMax);
        return textNormalized;
    }
    public static string FormatScore(int score)
    {
        string scoreString = score.ToString("00000");
        return scoreString;
    }

}

[System.Serializable]
public class PlayerCollector
{
    public int idCollector;
    public int capacity;
    public string namePlayer;
    public int topScore;
}

[System.Serializable]
public class ListCollectors
{
    public List<PlayerCollector> listCollector;
}
