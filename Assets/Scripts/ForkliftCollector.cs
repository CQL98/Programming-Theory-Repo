using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftCollector : Collector
{

    public Transform plataformFork;

    // ABSTRACTION
    protected override void LimitBoundVertical()
    {
        if (plataformFork.transform.localPosition.y < 0)
        {
            plataformFork.transform.localPosition = new Vector3(plataformFork.transform.localPosition.x, 0, plataformFork.transform.localPosition.z);
        }
        if (plataformFork.transform.localPosition.y > limitBoundY)
        {
            plataformFork.transform.localPosition = new Vector3(plataformFork.transform.localPosition.x, limitBoundY, plataformFork.transform.localPosition.z);
        }
    }

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
        // transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        if (verticalInput > 0.5 || verticalInput < -0.5)
        {
            plataformFork.transform.localPosition = Vector3.MoveTowards(plataformFork.transform.localPosition, Vector3.up * limitBoundY * verticalInput, speed * Time.deltaTime);
        }
        else 
        if (verticalInput == 0)
        {
            plataformFork.transform.localPosition = Vector3.MoveTowards(plataformFork.transform.localPosition, Vector3.up , speed * Time.deltaTime);
        }
        //else
        //{
        //    plataformFork.transform.localPosition = Vector3.MoveTowards(plataformFork.transform.localPosition, Vector3.up * limitBoundY * verticalInput, speed * Time.deltaTime);

        //}
    }



}
