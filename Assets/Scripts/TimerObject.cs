using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerObject : MonoBehaviour
{
    private TextMeshProUGUI textTimer;
    private GameManager gameManager;
    [SerializeField] private float counterTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        textTimer = GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            UpdateTimer();
        } 
    }

    private void UpdateTimer()
    {
        counterTime -= Time.deltaTime;
        int secondsTimer = Mathf.RoundToInt(counterTime);
        textTimer.text = "Timer  :"+ secondsTimer;
        if (secondsTimer <= 0)
        {
            gameManager.GameOver();
        }
    }

}
