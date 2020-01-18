using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    float time;
    float zaxis;
    protected Animator animator;
    private ParticleSystem particle;
    bool isOn;
    Button right;
    Button left;
    Button jump;
    CharacterController controller;
    // Start is called before the first frame update
    public virtual void Move(string direction)
    {
        if (!isOn)
            return;
    }
    public virtual void Jump()
    {
        if (!isOn)
            return;
    }
    protected void Start()
    {
        particle = GameObject.FindGameObjectWithTag("particle").GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        Application.targetFrameRate = 60;
        /*right = GameObject.Find("Right").GetComponent<Button>();
        left = GameObject.Find("Left").GetComponent<Button>();
        jump = GameObject.Find("Jump").GetComponent<Button>();*/
        time = Time.time;
        controller = GetComponent<CharacterController>();
        zaxis = gameObject.transform.position.z;

    }
    protected virtual void Idle()
    {

    }
    protected void Update()
    {

        
        isOn = gameObject.GetComponent<Animator>().GetBool("isOn");
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zaxis);

        if (isOn)
        {
            MovInit();
        }

    }
    
    float jumpDet = 0f;
    private void MovInit()
    {
        var mouse = Input.GetMouseButton(0);
        var mouseDown = Input.GetMouseButtonDown(0);
        
        if (mouse)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.tag != "Player" && !particle.isPlaying)
                {
                    
                    if (mouseDown)
                    {
                        jumpDet = Input.mousePosition.y;
                    }
                    else if(time < Time.time-1f && jumpDet != 0f && Input.mousePosition.y > jumpDet+Camera.main.pixelHeight/6)
                    {
                        time = Time.time;
                        Jump();
                        jumpDet = 0;
                    }
                    

                    Vector3 point = Camera.main.WorldToScreenPoint(hitInfo.point);
                    if(point.x > Camera.main.pixelWidth / 2)
                    {
                        Move("right");
                    }
                    else if(point.x < Camera.main.pixelWidth / 2)
                    {
                        Move("left");
                    }
                    
                }
            }

        }
        else
        {
            Idle();
        }
    }
}



