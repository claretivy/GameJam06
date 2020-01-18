using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Player
{
    public float moveFrc = 1f;
    public int jumpMag = 20;
    // Start is called before the first frame update
    [SerializeField] GameObject enivici;
    private PadScript pPad;
    
    float zRot;
    protected void Start()
    {
        zRot = transform.localEulerAngles.z;

        base.Start();
        pPad = GameObject.Find("pressurePad").GetComponent<PadScript>();
        
        GetComponent<Rigidbody>().centerOfMass -= new Vector3(0, 1.5f, 0);
    }
    protected void Update()
    {
        base.Update();
        if (pPad.Lerp)
        {
            animator.SetTrigger("Dance");
        }
        Quaternion temp = transform.rotation;
        temp = Quaternion.Euler(temp.eulerAngles.x, 90, 0);
        transform.rotation = temp;
    }
    
    public override void Move(string direction)
    {
        base.Move(direction);
        if (direction == "right")
        {
            gameObject.transform.position += new Vector3(moveFrc * Time.deltaTime, 0, 0);
            animator.SetBool("walking", true);
            enivici.SetActive(false);
        }
        else if (direction == "left")
        {
            gameObject.transform.position -= new Vector3(moveFrc * Time.deltaTime, 0, 0);
            animator.SetBool("walking", true);
            enivici.SetActive(true);
        }
    }
    public override void Jump()
    {
        base.Jump();
        animator.SetTrigger("jumped");
        //Invoke("DoSomething", 0.5f);
        gameObject.GetComponent<Rigidbody>().AddForce(0, jumpMag, 0);
    }
    protected override void Idle()
    {
        animator.SetBool("walking", false);
        enivici.SetActive(false);
    }
}
