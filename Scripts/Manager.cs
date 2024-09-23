using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] GameObject Stick1;
    [SerializeField] GameObject Stick2;
    [SerializeField] GameObject Stick3;


    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
   [SerializeField] GameObject three;
    [SerializeField] GameObject four;
    [SerializeField] GameObject five;
    [SerializeField] Text win;
   
   
 
    [SerializeField] Text score;

    [SerializeField] List<GameObject>[] pole=new List<GameObject>[3];
    int selected = -1;



    private bool go = true;
    int points = 0;
   
    void Start()
    {
        pole[0]= new List<GameObject>() ; pole[1]= new List<GameObject>() ; pole[2]= new List<GameObject>() ;
        pole[0].Add(five); pole[0].Add(four); pole[0].Add(three); pole[0].Add(two);pole[0].Add(one);
        StartPos();
        points = 0;
        Stick1.GetComponent<SpriteRenderer>().color = new Color(0.509804f, 0.3960785f, 0.3960785f);
        Stick2.GetComponent<SpriteRenderer>().color = new Color(0.509804f, 0.3960785f, 0.3960785f);
        Stick3.GetComponent<SpriteRenderer>().color = new Color(0.509804f, 0.3960785f, 0.3960785f);
        score.text = " Moves: ";
        win.GetComponent<Text>().enabled = false;
        go = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&go==false)
        {
            resetGame();
        }
        
    }
    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Addpoints(bool move)
    {
        if (move) { points+=1; }
        score.text = " Moves: " + points;
    }
    public void Change(List<int> stack, float start, float end)
    {
        Debug.Log("Reached Change");
    }
    public void StartPos()
    {
        float x = -5.6f;
        float y = -2.09f;
        one.transform.position = new Vector3(x,y+.75f*4.0f,0);
        two.transform.position= new Vector3(x, y + .75f * 3.0f, 0);
        three.transform.position = new Vector3(x, y + .75f * 2.0f, 0);
        four.transform.position = new Vector3(x, y + .75f * 1.0f, 0);
        five.transform.position = new Vector3(x,y,0);
    }
    public void Clicked(int index)
    {
        Debug.Log("clicked");
        if (selected == -1)
        {
            selected= index;
            if(selected == 0)
            {
                Stick1.GetComponent<SpriteRenderer>().color = new Color(1.0f,0.0f,0.0f);
            }
            if (selected == 1)
            {
                Stick2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.08f, 0.00f);
            }
            if (selected == 2)
            {
                Stick3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
            }
        }
        else
        {
            if (selected != index && pole[selected].Count>0) {
               
                if (pole[index].Count <= 0 || GetValue(index, pole[index].Count-1) > GetValue(selected, pole[selected].Count - 1))
                {
                    Debug.Log(" Got to Move");
                    Move(index, selected);
                    selected = -1;
                }
            }
            selected = -1;
            Stick1.GetComponent<SpriteRenderer>().color = new Color(0.509804f, 0.3960785f, 0.3960785f);
            Stick2.GetComponent<SpriteRenderer>().color = new Color(0.509804f, 0.3960785f, 0.3960785f);
            Stick3.GetComponent<SpriteRenderer>().color = new Color(0.509804f, 0.3960785f, 0.3960785f);
        }
    }
     public int GetValue(int i,int num)
    {
        if (pole[i][num].name == "One")
        {
            return 1;
        }
        else if (pole[i][num].name == "Two")
        {
            return 2;
        }
        else if (pole[i][num].name == "Three")
        {
            return 3;
        }
        else if (pole[i][num].name == "Four")
        {
            return 4;
        }
        else if(pole[i][num].name == "Five")
        {
            return 5;
        }
        return -1;
    }
    public void Move(int index, int selected)
    {
        float x = -1;
        float y = -2.09f;
        pole[index].Add(pole[selected][pole[selected].Count - 1]);
        pole[selected].RemoveAt(pole[selected].Count-1);
        if(index == 0)
        {
            x = -5.6f;
          
        }
        if(index == 1)
        {
            x = -.08f;
        }
        if(index == 2)
        {
            x = 5.6f;
        }
        pole[index][pole[index].Count - 1].transform.position = new Vector3(x, y + .75f * (pole[index].Count-1), 0);
        Addpoints(true);
        WinGame(index);
    }
    public bool GetGo()
    {
        return go;
    }
    public void WinGame(int index)
    { int x = 5;
        int winalicious = 0;
        if (index!=0)
        {
            for( int i = 0; i < pole[index].Count; i++)
            {
               
                if (GetValue(index, i) == x)
                {
                    winalicious += 1;
                }
                x -= 1;
            }
        }
        if (winalicious == 5) {
            go = false;
            win.GetComponent<Text>().enabled = true;
        }
    }
    
}
