using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    Animator anim;
    Animator bossAnim;
    GameObject boss;
    Generation g;
    bool stop;
    bool bdeath = false;
    public bool paused = false;
    bool started = false;
    bool clicked;
    bool flipped = false;
    public bool Phone = false;
    public bool jump;
    public bool bossEvent;
    int attacktime = 0;
    int jtime;
    int time;
    float acceleration;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        g = GameObject.Find("event").GetComponent<Generation>();
        Phone = false;
        clicked = false;
        boss = GameObject.Find("Enemy");
        bossAnim = GameObject.Find("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {

            if (!bdeath) {
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
                    if (!bossEvent)
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
                                jtime = 0; time = 0; started = false;
                            }

                        }
                        if (flipped)
                        {
                            anim.Play("flip");
                        }
                        else
                        {
                            anim.Play("jump");
                        }
                    }
                    else
                    {
                        if (attacktime == 4)
                        {
                            attacktime = 3;
                            started = false;
                        }
                        else if (attacktime == 3)
                        {
                            attacktime = 2;
                            started = false;
                        }
                        else if (attacktime == 2)
                        {
                            attacktime = 1;
                            started = false;
                        }
                        else if (attacktime == 1)
                        {
                            attacktime = 0;
                            started = false;
                        }
                        else
                        {
                            anim.Play("attack");
                            
                            bdeath = true;
                            started = true;
                            time = 0;

                        }
                        if (!started)
                        {
                            started = true;
                            g.GenerateQuestion();
                        }
                    }
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
            else
            {
                if (time <= 170) { time++;  }
                else
                {
                    boss.gameObject.SetActive(false);
                }
                if (time >= 115)
                {
                    bossAnim.Play("en_Death");
                }
                if (time >= 170)
                {
                    transform.Translate(acceleration, 0, 0);
                    anim.Play("run");
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
    public void BossLevel()
    {
        bossEvent = true;
    }
    public void flip()
    {
        flipped = true;
    }
}
