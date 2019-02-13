using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerlevel1 : MonoBehaviour {
    TimerLevel2 t;
	// Use this for initialization
	void Start () {
        t = GameObject.Find("Level2Time").GetComponent<TimerLevel2>();
    }
	
	// Update is called once per frame
	void Update () {
        t.timerEnd();
	}
}
