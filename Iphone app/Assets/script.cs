using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour {
    public Animator anim;
    public Text question;
    public Button option1;
    public Button option2;
    public Button option3;
    public Button option4;
    public Text option1text;
    public Text option2text;
    public Text option3text;
    public Text option4text;
    public GameObject canvas;
    bool started = false;
    bool attacking = false;
    public int jumps = 0;
    int ans = 0;
    bool jump = false;
    int attacks = 0;
    bool run = true;
    public bool idle = false;
    bool boss = false;
    int time = 0;
   public bool complete = false;
    
    // Use this for initialization
    void Start () {
        canvas.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (complete) { }
        else
        {
            
            //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
            if (jump)
            {
                
                if (boss) { if (attacks == 4) { boss = false; complete = true; } else if (attacking){anim.Play("attack"); attacking = false; }{ if (!started) { activate(); started = true; attacks++; } } }
                else
                {
                    if (time <= 20) { time++; }
                    else
                    {
                        transform.Translate(0.1f, 0.2f, 0);
                    }
                    if (jumps != 4)
                    {
                        anim.Play("jump");

                    }
                    else
                    {
                        anim.Play("flip");

                    }
                }
            }
            else
            {
                if (run)
                {
                    transform.Translate(0.1f, 0, 0);
                    anim.Play("run");
                }
                if (idle)
                {
                    anim.Play("Idle");
                }
                checkToStop();
            }
        }
    }
    public void activate()
    {
       if (jumps >= 4)
        {
            boss = true;
        }
        canvas.SetActive(true);
        int num1 = Random.Range(1, 12);
        int num2 = Random.Range(1, 12);
        ans = num1 + num2;
        question.text = "What is " + num1 + " + " + num2;
        int ans2 = Random.Range(1, 20);
        int ans3 = Random.Range(1, 20);
        int ans4 = Random.Range(1, 20);
        int choice = Random.Range(1, 4);
        if (choice == 1)
        {
            option1text.text = "" + ans;
            option2text.text = "" + ans2;
            option3text.text = "" + ans3;
            option4text.text = "" + ans4;
        }
        if (choice == 2)
        {
            option1text.text = "" + ans2;
            option2text.text = "" + ans;
            option3text.text = "" + ans3;
            option4text.text = "" + ans4;
        }
        if (choice == 3)
        {
            option1text.text = "" + ans2;
            option2text.text = "" + ans3;
            option3text.text = "" + ans;
            option4text.text = "" + ans4;
        }
        if (choice == 4)
        {
            option1text.text = "" + ans2;
            option2text.text = "" + ans3;
            option3text.text = "" + ans4;
            option4text.text = "" + ans;
        }
    }
    public void button1Clicked()
    {
        if (option1text.text == ""+ ans)
        {
          
            jump = true;
            canvas.SetActive(false);
            jumps++; attacking = true;

        }
        else
        {
            
        }started = false;
    }
    public void button2Clicked()
    {
        if (option2text.text == "" + ans)
        {
                             
            jump = true;
            canvas.SetActive(false);
            jumps++; attacking = true;

        }
        else
        {
           
        }started = false;
    }
    public void button3Clicked()
    {
        if (option3text.text == "" + ans)
        {
           
            jump = true; canvas.SetActive(false); jumps++; attacking = true;
        }
        else
        {
            
        }
        started = false;
    }
    public void button4Clicked()
    {
        Debug.Log("clicked");
        if (option4text.text == "" + ans)
        {
           
            Debug.Log("correct");
            jump = true; canvas.SetActive(false); attacking = true;
            idle = false; jumps++;
        }
        else
        {
            
            Debug.Log("incorrect");
        }
        started = false;
    }
    public void clicked()
    {
        Debug.Log("clicked");
    }
    private void OnCollisionEnter(Collision other)
    {

        jump = false; 
            time = 0;
        


    }
   void checkToStop()
    {
        if (transform.position.x >= 19f && transform.position.x <= 28f)
        {
            run = false;
            idle = true; if (!started) { activate(); started = true; }
        }
        else if (transform.position.x >= 43f && transform.position.x <= 44f)
        {
            run = false;idle = true; if (!started) { activate(); started = true; }
        }
        else if (transform.position.x >= 67f && transform.position.x <= 69f)
        {
            run = false; idle = true; if (!started) { activate(); started = true; }
        }
        else if (transform.position.x >= 107.5f && transform.position.x <= 109f)
        {
            run = false; idle = true; if (!started) { activate(); started = true; }
        }
        else if (transform.position.x >= 206.5f && transform.position.x <= 208f)
        {
            run = false; idle = true; if (!started) { activate(); started = true; }
        }
        else
        {
            run = true;
            idle = false;
            
        }
        
    }
}
