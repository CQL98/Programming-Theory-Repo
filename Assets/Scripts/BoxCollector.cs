using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Inheritance child class
public class BoxCollector : Collector
{

    // POLYMORPHISM
    protected override void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
    }

    // POLYMORPHISM
    protected override void MoveVertical()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }
}
