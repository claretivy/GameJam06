using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PadScript : MonoBehaviour
{
    
    public GameObject confetti;
    public GameObject zoomCamera;
    public GameObject fakeCam;
    public IntreactibleObj intreac;

    public bool Lerp = false;
    public GameObject NextLevel;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag =="MainP")
        {
            if (!Lerp)
            {
                animator.SetBool("pressTrigger",true);
                Success();
            }
        }
        else if(collision.collider.tag == "Player")
        {
            if (intreac)
                intreac.Intreacted();
            animator.SetBool("pressTrigger", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(intreac)
            intreac.IntreactedExit();
        animator.SetBool("pressTrigger", false);
    }
    int score;
    
    
    void Success()
    {
        NextLevel.SetActive(true);
        zoomCamera.SetActive(true);
        Camera.main.gameObject.SetActive(false);
        confetti.SetActive(true);
        //SuccessPanel.SetActive(true);
        score = Int32.Parse(GameObject.Find("particleText").GetComponent<Text>().text);
        //Debug.Log(stars[0].GetComponent<Image>().fillAmount);
        
        //if (stars[0].GetComponent<Image>().fillAmount < 0.98f && stars[0].GetComponent<Image>().fillAmount < score / 30)
        Lerp = true;

    }
   /* 
    void SuccessInit()
    {
        if (score < 30)
        {
            
        }
        else if (score < 60)
        {
            stars[0].SetActive(true);
        }
        else if (score < 90)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }*/
}
