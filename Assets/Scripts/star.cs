using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().fillAmount += 0.5f * Time.deltaTime;
    }
}
