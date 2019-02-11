using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    Animator anim;
    Generation g;
    bool stop;
    public bool paused = false;
    bool started = false;
    bool clicked;
    public bool Phone = true;
    public bool jump;
    int jtime;
    int time;
    float acceleration;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        g = GameObject.Find("event").GetComponent<Generation>();
        Phone = true;
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (Phone) { acceleration = Input.acceleration.x; }
            else if (!Phone) { acceleration = 0.1f; }

            if (!stop)
            {
                //run script
                transform.Translate(acceleration, 0, 0);
                anim.Play("run");
            }
            else if (jump)
            {
                if (time <= 20) { time++; }
                else
                {
                    if (jtime <= 120)
                    {
                        transform.Translate(0.1f, 0.2f, 0); jtime++;
                    }
                    else
                    {
                        jump = false;
                        stop = false;
                        jtime = 0; started = false;
                    }
                    
                }
                anim.Play("jump");
            }
            else
            {
                anim.Play("Idle");
                if (!started)
                {
                    started = true;
                    g.GenerateQuestion();
                }
            }
        }
    }
    public void stopped()
    {
        if (jump)
        {
            jump = false;
        }
        else
        {
            stop = true;
        }
    }
    public void ChangeInput()
    {
        if (!clicked)
        {
            Phone = false;
            clicked = true;
        }
        else
        {
            Phone = true; clicked = false;
        }
    }
}
