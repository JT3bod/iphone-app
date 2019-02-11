using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class questions : MonoBehaviour {
    public Slider health;
    public GameObject canvas;
    public Text question;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    script s;
    int num1;
    int num2;
    int sym;
    string sign = "";
    int ans;
    int ans2;
    int ans3;
    int ans4;
    int choice;
    System.Random r = new System.Random();

    // Use this for initialization
    void Start()
    {
        canvas.SetActive(false);
        s = GameObject.Find("Player").GetComponent<script>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void activate()
    {
        
        canvas.SetActive(true);
        generateNum();




    }
    public void Button1Clicked()
    {
        if (option1.text == "" + ans)
        {

            s.Clicked();
            canvas.SetActive(false);
            

        }
        else
        {
            WrongAnswer();
        }
        
    }
    public void Button2Clicked()
    {
        if (option2.text == "" + ans)
        {

            s.Clicked();
            canvas.SetActive(false);


        }
        else
        {
            WrongAnswer();
        }
        
    }
    public void Button3Clicked()
    {
        if (option3.text == "" + ans)
        {

            s.Clicked(); canvas.SetActive(false); 
        }
        else
        {
            WrongAnswer();
        }
        
    }
    public void Button4Clicked()
    {

        if (option4.text == "" + ans)
        {

            s.Clicked(); canvas.SetActive(false); 
        }
        else
        {

            WrongAnswer();
        }
        
    }

    void generateNum()
    {
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
            int temp = num1;
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
            ans4 = r.Next(1, 50);
        }

        choice = r.Next(1, 4);
        if (choice == 1)
        {
            option1.text = "" + ans;
            option2.text = "" + ans2;
            option3.text = "" + ans3;
            option4.text = "" + ans4;
        }
        if (choice == 2)
        {
            option1.text = "" + ans2;
            option2.text = "" + ans;
            option3.text = "" + ans3;
            option4.text = "" + ans4;
        }
        if (choice == 3)
        {
            option1.text = "" + ans2;
            option2.text = "" + ans3;
            option3.text = "" + ans;
            option4.text = "" + ans4;
        }
        if (choice == 4)
        {
            option1.text = "" + ans2;
            option2.text = "" + ans3;
            option3.text = "" + ans4;
            option4.text = "" + ans;
        }
    }
    void WrongAnswer()
    {
        health.value--;
    }
}

