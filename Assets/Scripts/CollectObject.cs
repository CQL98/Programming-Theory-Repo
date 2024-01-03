using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private TextMeshProUGUI textCollection;
    private GameManager gameManager;
    [SerializeField] private float counterTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        textCollection = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
