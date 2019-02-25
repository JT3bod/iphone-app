using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TimerLevel3 : MonoBehaviour
{
    TimerLevel2 t;

    void Start()
    {
        t = GameObject.Find("Level2Time").GetComponent<TimerLevel2>();
    }
    private void Update()
    {
        t.level3();
    }
    
        
    
}