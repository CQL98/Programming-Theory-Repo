using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    //[SerializeField] private int count;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.AddCounter(); 
        other.gameObject.transform.parent = gameObject.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        gameManager.RemoveCounter(); 
        other.gameObject.transform.parent = null;
    }
}
