using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;


public class topscoreScript : MonoBehaviour {
    Text lastScore;
    Text TopScore;
    string path = "Assets/Scripts/Data.txt";
    string[] lines;
    // Use this for initialization
    void Start () {
        lines = File.ReadAllLines(path);
        lastScore = GameObject.Find("LastScore").GetComponent<Text>();
        TopScore = GameObject.Find("TopScore").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        lastScore.text = ("Last Score: " + lines[0]);
        TopScore.text = ("Top Score: " + lines[1]);
	}
}
