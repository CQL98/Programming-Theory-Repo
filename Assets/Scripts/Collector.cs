using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Inheritance parent class
public class Collector : MonoBehaviour
{

    public string Name; 
    public int Capacity;
    public int idCollector;
    //ENCAPSULATION
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float limitBoundX = 12;
    [SerializeField] protected float limitBoundY = 18; 
    public void SetCollector(int capacity, string name)
    {
        Capacity = capacity;
        Name = name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        LimitBound();
    }
    // ABSTRACTION
    protected virtual void Move()
    {
        MoveHorizontal();
        MoveVertical();
    }

    protected virtual void MoveHorizontal()
    {
    }

    protected virtual void MoveVertical()
    {
    }

    // ABSTRACTION
    protected virtual void LimitBound()
    {
        LimitBoundHorizontal();
        LimitBoundVertical();
    }
     
    protected virtual void LimitBoundHorizontal()
    {
        if (transform.position.z < -limitBoundX)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limitBoundX);
        }
        if (transform.position.z > limitBoundX)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limitBoundX);
        }
    }
     
    protected virtual void LimitBoundVertical()
    {
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (transform.position.y > limitBoundY)
        {
            transform.position = new Vector3(transform.position.x, limitBoundY, transform.position.z);
        }
    }

}
