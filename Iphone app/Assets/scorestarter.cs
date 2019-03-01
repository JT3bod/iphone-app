using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class scorestarter : MonoBehaviour {
    string path = "Assets/Scripts/score.txt";
    // Use this for initialization
    void Start () {
        
        string[] lines = File.ReadAllLines(path);
        lines[0] = 0.ToString();
        LineChanger(lines[0], path, 0);
        ;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    static void LineChanger(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit] = newText;
        File.WriteAllLines(fileName, arrLine);
    }
}
