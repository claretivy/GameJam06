using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : IntreactibleObj
{
    Vector3 initPos;
    void Start()
    {
        initPos = gameObject.transform.position;
    }
    // Start is called before the first frame update
    public override void Intreacted()
    {
        gameObject.transform.position = initPos + new Vector3(0, 3, 0);
    }
    public override void IntreactedExit()
    {
        gameObject.transform.position = initPos;
    }
}
