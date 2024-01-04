using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    //[SerializeField] private int count;
    private GameManager gameManager; 
    [SerializeField] private GameObject wormEffectPrefab;
    [SerializeField] private AudioClip appleCollect;
    [SerializeField] private AudioClip wormCollect;
    [SerializeField] private AudioClip removeCollect;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            gameManager.AddCounter();
            audioSource.PlayOneShot(appleCollect);
            other.gameObject.transform.parent = gameObject.transform;
        }
        else if (other.gameObject.CompareTag("Worm"))
        {
            Instantiate(wormEffectPrefab, transform.position + Vector3.up * 9, wormEffectPrefab.transform.rotation);
            gameManager.RemoveCounter();
            audioSource.PlayOneShot(wormCollect);
            Destroy(other.gameObject); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        { 
            gameManager.RemoveCounter();
            audioSource.PlayOneShot(removeCollect);
            other.gameObject.transform.parent = null;
        }else if (other.gameObject.CompareTag("Worm"))
        {
            gameManager.AddCounter();
            other.gameObject.transform.parent = null;
        }
    }
}
