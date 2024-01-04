using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Worm"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject, Random.Range(1f, 4f));

        }
    }
}
