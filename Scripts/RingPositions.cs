using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPositions : MonoBehaviour
{
    // Start is called before the first frame update

    List<int> stack=new List<int>();
    
    [SerializeField] GameObject gameManager;
    [SerializeField] int index = 0;
  
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Movement(float start, float end)
    {
        Debug.Log("reached Movement");
       
    }
    public void OnMouseDown()
    {
        int i = -1;
        if (gameObject.name == "Stick1")
        {
            i = 0;

        }
        else if(gameObject.name == "Stick2")
        {
            i = 1;
        }
        else if(gameObject.name == "Stick3")
        {
            i = 2;
        }
        Debug.Log("chosen on click: " + i);
        if (gameManager.GetComponent<Manager>().GetGo() == true)
        {
            gameManager.GetComponent<Manager>().Clicked(i);
        }

        
    }
}
