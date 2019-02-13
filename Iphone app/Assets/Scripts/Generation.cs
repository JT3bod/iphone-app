using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class Generation : MonoBehaviour {
    movement m;
    audioScript a;
    TimerLevel2 t;
    GameObject canvas;
    Text question;
    Text option1;
    Text option2;
    Text option3;
    Text option4;
    Text score;
    string path = "Assets/Scripts/Data.txt";
    public int scoreNum;
    int choice;
    int num1;
    int num2;
    int ans;
    int ans2;
    int ans3;
    int ans4;
    int sym;
    string sign = "";
    public bool starttimer = false;
    System.Random r = new System.Random();
    // Use this for initialization
    void Start() {

        t = GameObject.Find("Level2Time").GetComponent<TimerLevel2>();
        a = GameObject.Find("event").GetComponent<audioScript>();
        m = GameObject.Find("Player").GetComponent<movement>();

        canvas = GameObject.Find("QuestionCanvas");
        option1 = GameObject.Find("Option1text").GetComponent<Text>();
        option2 = GameObject.Find("Option2text").GetComponent<Text>();
        option3 = GameObject.Find("Option3text").GetComponent<Text>();
        option4 = GameObject.Find("Option4text").GetComponent<Text>();
        question = GameObject.Find("Question").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        canvas.SetActive(false);
        scoreNum = 0;
        score.text = ("Score: " + scoreNum);
    }

    // Update is called once per frame
    void Update() {

    }
    public void GenerateQuestion() {
        t.timerStart();
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
        OutputQuestion(); Debug.Log("Generated");
    }
    public void OutputQuestion()
    {
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
        Debug.Log("Answers created");
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
        Debug.Log("created question");
        canvas.SetActive(true);
    }

    //scoring system and modification of health.
    
    void CorrectAnswer()
    {
        scoreNum++; score.text = ("Score: " + scoreNum); t.timerEnd();
    }


    public void Button1Clicked()
    {
        if (option1.text == "" + ans)
        {
            a.correctAudio(); CorrectAnswer();
            m.jump = true;
            canvas.SetActive(false);


        }
        else
        {
             a.incorrectAudio();
        }

    }
    public void Button2Clicked()
    {
        if (option2.text == "" + ans)
        {
            a.correctAudio(); CorrectAnswer();
            m.jump = true;
            canvas.SetActive(false);


        }
        else
        {
             a.incorrectAudio();
        }

    }
    public void Button3Clicked()
    {
        if (option3.text == "" + ans)
        {
            m.jump = true; a.correctAudio(); CorrectAnswer();
            canvas.SetActive(false);
        }
        else
        {
             a.incorrectAudio();
        }

    }
    public void Button4Clicked()
    {

        if (option4.text == "" + ans)
        {
            m.jump = true; a.correctAudio(); CorrectAnswer();
            canvas.SetActive(false);
        }
        else
        {
            a.incorrectAudio();
            

        }

    }
    public void death()
    { 
        a.destructionAudio();
        Save();
        SceneManager.LoadScene("Menu");
    }
    public void Save()
    {
        
        string[] lines = File.ReadAllLines(path);
        lines[0] = scoreNum.ToString();
        if (Convert.ToInt32(lines[1]) < Convert.ToInt32(lines[0]))
        {
            lines[1] = lines[0];
        }
        LineChanger(lines[0], path, 0);
        LineChanger(lines[1], path, 1);
        
    }
    static void LineChanger(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit] = newText;
        File.WriteAllLines(fileName, arrLine);
    }
}
