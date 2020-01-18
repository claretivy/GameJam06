using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Player
{
    public int jumpMag = 20;
    public int moveFrc = 1;
    // Start is called before the first frame update
    public override void Jump()
    {
        base.Jump();
        gameObject.GetComponent<Rigidbody>().AddForce(0, jumpMag, 0);
    }
    public  override void Move(string direction)
    {
        base.Move(direction);
        if (direction == "right")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(moveFrc *Time.deltaTime, 0, 0);
        }
        if (direction == "left")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-moveFrc *Time.deltaTime, 0, 0);
        }
    }
}
