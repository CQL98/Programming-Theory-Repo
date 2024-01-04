using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//Inheritance child class
public class CarCollector : Collector
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

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
    protected override void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("xInput", horizontalInput);
        transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
    }

    // POLYMORPHISM
    protected override void MoveVertical()
    { 
        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("yInput",verticalInput);
        transform.Translate(Vector3.right * speed * -verticalInput * Time.deltaTime);
    }
 
}
