using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class level3teleport : MonoBehaviour {
    public bool loaded2 = true;
    public bool loaded3 = true;
    Generation g;
    string path = "Assets/Scripts/score.txt";


    // Use this for initialization
    void Start()
    {
        g = GameObject.Find("event").GetComponent<Generation>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        g.Save();
        
    }
    public void Level2()
    {
        loaded2 = true;
    }
    public void level3()
    {
        loaded3 = true;
        loaded2 = true;
    }
    public void saveScore()
    {
        string[] lines = File.ReadAllLines(path);
        lines[0] = g.scoreNum.ToString();
        LineChanger(lines[0], path, 0);
        changescene();
    }
    static void LineChanger(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit] = newText;
        File.WriteAllLines(fileName, arrLine);
    }
    void changescene()
    {
        if (!loaded2)
        {
            SceneManager.LoadScene("Level2");
            loaded2 = true;
        }
        else if (!loaded3 && loaded2)
        {
            SceneManager.LoadScene("Level3");
            loaded3 = true;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
