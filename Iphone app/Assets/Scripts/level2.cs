using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class level2 : MonoBehaviour {
    teleporterScript t;
    Generation g;
    string path = "Assets/Scripts/score.txt";
    string[] lines;
    // Use this for initialization
    void Start()
    {
        lines = File.ReadAllLines(path);
        g = GameObject.Find("event").GetComponent<Generation>();
        t = GameObject.Find("event").GetComponent<teleporterScript>();
      
        int num = Convert.ToInt32(lines[0]);
      //  g.updatescore();
       
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
