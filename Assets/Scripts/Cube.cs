using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Player
{
    // Start is called before the first frame update
    public int jumpMag = 20;
    public int moveFrc = 1;
    public override void Jump()
    {
        base.Jump();
        gameObject.GetComponent<Rigidbody>().AddForce(0, jumpMag, 0);
    }

    public override void Move(string direction)
    {
        base.Move(direction);
        if(direction == "right")
        {
            gameObject.transform.position += new Vector3(moveFrc * Time.deltaTime, 0, 0);
        }
        if (direction == "left")
        {
            gameObject.transform.position -= new Vector3(moveFrc * Time.deltaTime, 0, 0);
        }
    }
    
}
