using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//Inheritance child class
public class CarCollector : Collector
{
    // POLYMORPHISM
    protected override void LimitBoundVertical()
    {
        // base.LimitBoundVertical();
        if (transform.position.x < -limitBoundY)
        {
            transform.position = new Vector3(-limitBoundY, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitBoundY)
        {
            transform.position = new Vector3(limitBoundY, transform.position.y, transform.position.z);
        }
    }

    // POLYMORPHISM
    protected override void MoveVertical()
    {
        //base.MoveVertical(); 
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * -verticalInput * Time.deltaTime);
    }
 
}
