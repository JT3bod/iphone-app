using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TimerLevel2 : MonoBehaviour {
    public Slider time;
    Generation g;
    bool start = false;
    int times = 0;
    public int interval = 120;
	// Use this for initialization
	void Start () {
        g = GameObject.Find("event").GetComponent<Generation>();
        time.value = 100f;
	}

    // Update is called once per frame
    void Update()
    {
        
       if (start)
        {
            if (times == interval)
            {
                times = 0;
                time.value = time.value - 10f;
            
                if (time.value == 0)
                {
                    g.death();

                }
            }
            else
            {
                times++;
            }
        }
        else
        {
            time.value = 100;
        }
    }
 
    public void timerStart()
    {
        start = true;
    }
    public void timerEnd()
    {
        start = false;
    }
    public void level3()
    {
        interval = 60;
    }
    public void reset()
    {
        times = 0;
        time.value = 100f;
    }
}
