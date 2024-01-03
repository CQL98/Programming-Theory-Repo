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

    List<PlayerCollector> listCollector = new List<PlayerCollector>();
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
    public void SavePlayerCollector()
    {
        PlayerCollector collector = this.listCollector.First(item => item.idCollector == actualIndex);
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
            auxList.Add(auxItem);
        }
        list.listCollector = listCollector = auxList;

        string json = JsonUtility.ToJson(list);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}

[System.Serializable]
public class PlayerCollector
{
    public int idCollector;
    public int capacity;
}

[System.Serializable]
public class ListCollectors
{
    public List<PlayerCollector> listCollector;
}
