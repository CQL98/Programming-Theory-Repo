using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    public bool isGameActive { get; private set; }
    public bool isWinGame;

    public float startDelay = 1;
    public float repeatRate = 1.5f;

    private float spawnYPosition = 23;
    [SerializeField] private float boundZLimit = 18;

    [SerializeField] private int count = 0;
    [SerializeField] private int capacityCollector = 20;
    [SerializeField] private TextMeshProUGUI textCollection;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI winLoseText;
    private const string winText = "You WIN!!!, but the next time you need more apples.";
    private const string loseText = "Game Over, try it again!!!";

    void Start()
    {
        isGameActive = true;
        count = 0;
        isWinGame = false;
        DataManager.Instance.LoadPlayerCollector();
        capacityCollector = DataManager.Instance.GetCapacityByCollector();
        spawnCollector();
        showCounter(count);
        gameOverPanel.gameObject.SetActive(false);
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameActive = !isGameActive;
        }
    }
    private void spawnCollector()
    {
        Vector3 position = new Vector3(0,0.5f,0);
        DataManager.Instance.SpawnCollector(position);
    }
    IEnumerator SpawnObject()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(repeatRate);
            int index = Random.Range(0, objects.Length);
            Vector3 spawnPos = new Vector3(0, spawnYPosition, Random.Range(-boundZLimit, boundZLimit));
            Instantiate(objects[index], spawnPos, objects[index].transform.rotation);
        }
    }

    public void GameOver()
    {
        isGameActive = false;

        if (capacityCollector <= count)
        {
            DataManager.Instance.SavePlayerCollector();
            isWinGame = true;
        }

        if (isWinGame)
        {
            winLoseText.text = winText;
        }
        else
        {
            winLoseText.text = loseText;
        }
        gameOverPanel.gameObject.SetActive(true);
    }

    public void AddCounter()
    {
        if (isGameActive)
        {
            count++;
            showCounter(count); 
        }
    }

    private void showCounter(int value)
    {
        textCollection.text = "Collect:	" + value + "/" + capacityCollector;
    }

}
