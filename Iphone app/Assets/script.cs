using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour {
    public Animator anim;
    public Slider health;
    bool Sclicked = false;
    public Animator enAnim;
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
    public GameObject settingcanvas;
    bool started = false;
    bool attacking = false;
    int jumps = 0;
    System.Random r = new System.Random();
    float ans = 0;
    int ans2 = 0;
    int ans3 = 0;
    int ans4 = 0;
    int choice = 0;
    bool jump = false;
    int attacks = 0;
    bool run = true;
    bool idle = false;
    bool en_death = false;
    bool boss = false;
    int time = 0;
    int num1;
    int num2;
    int sym;
    bool complete = false;
    public float acceleration;
    string sign = "";
    public bool phone = true;

    

    // Use this for initialization
    void Start () {
        canvas.SetActive(false);
        settingcanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
        if (en_death)
        {
            if (time != 0)
            {
                time--;
            }
            else
            {
                enAnim.Play("en_Death");
                transform.Translate((acceleration), 0, 0);
            }
        }
        if (complete) { if (transform.position.x >= 229f){ SceneManager.LoadScene("Level1"); } }
        else
        {
            
            //transform.Translate(acceleration, 0, -Input.acceleration.z);
            if (jump)
            {
                
                if (boss) { if (attacks == 5) { boss = false; anim.Play("attack"); en_death = true; time = 85; started = true; attacking = false; complete = true; } else if (attacking){ attacking = false; }{ if (!complete){ if (!started) { activate(); started = true; attacks++; } } } }
                else
                {
                    if (time <= 20) { time++; }
                    else
                    {
                        transform.Translate(0.1f, 0.25f, 0);
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
                if (phone)
                {
                    acceleration = Input.acceleration.x;
                }
                else
                {
                    acceleration = 0.15f;
                }
                if (run)
                {
                    transform.Translate((acceleration), 0, 0);
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
        generateNum();
       
      
        
        
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
            WrongAnswer();
        }
        started = false;
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
            WrongAnswer();
        }
        started = false;
    }
    public void button3Clicked()
    {
        if (option3text.text == "" + ans)
        {
           
            jump = true; canvas.SetActive(false); jumps++; attacking = true;
        }
        else
        {
            WrongAnswer();
        }
        started = false;
    }
    public void button4Clicked()
    {
        
        if (option4text.text == "" + ans)
        {
           
            jump = true; canvas.SetActive(false); attacking = true;
            idle = false; jumps++;
        }
        else
        {

            WrongAnswer();
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
    void generateNum() {
        num1 = r.Next(1, 12);
        num2 = r.Next(1, 12);
        sym = r.Next(1, 5);
        if (sym == 1)
        {
            sign = "+";
            ans = num1 + num2;

        }
        else if (sym == 2)
        {
            sign = "-";
            ans = num1 - num2;
            while (ans <= 0)
            {
                int temp = num1;
                num2 = num1;
                num1 = temp;
                ans = num1 - num2;
            }

        }
        else if (sym == 3)

        {
            sign = "/";
            int temp= num1;
            ans = num1;
            num1 = temp * num2;

        }
        else if (sym == 4)
        {
            sign = "x";
            ans = num1 * num2;

        }
        question.text = ("What is : " + num1 + " " + sign + " " + num2);
        ans2 = r.Next(1, 50);
        ans3 = r.Next(1, 50);
        ans4 = r.Next(1, 50);
        if (ans2 == ans || ans2 == ans3 || ans2 == ans4)
        {
            ans2 = r.Next(1, 50);
        }
        if (ans2 == ans || ans3 == ans2 || ans3 == ans4)
        {
            ans3 = r.Next(1, 50);
        }
        if (ans4 == ans || ans4 == ans2 || ans4 == ans3)
        {
            ans4 = r.Next(1,50);
        }

        choice = r.Next(1, 4);
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

    //settings
    public void SettingButton()
    {
        if (Sclicked)
        {
            Sclicked = false;
            settingcanvas.SetActive(false);
        }
        else
        {
            Sclicked = true;
            settingcanvas.SetActive(true);
        }
    }
    public void PhoneButton()
    {
        phone = true;
    }
    public void PCButton()
    {
        phone = false;
    }
    void WrongAnswer()
    {
        health.value--;
    }
}
