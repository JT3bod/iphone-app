using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour {
    public Animator anim;
    public bool Sclicked = false;
    public Animator enAnim;
    public questions q;
    public GameObject settingcanvas;
    public bool started = false;
    public bool attacking = false;
    public int jumps = 0;
    public bool jump = false;
    public int attacks = 0;
    public bool run = true;
    public bool idle = false;
    public bool en_death = false;
    public bool boss = false;
    public int time = 0;
    public bool complete = false;
    public float acceleration;
    public bool phone = true;

    

    // Use this for initialization
    void Start () {
        
        settingcanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (jumps >= 4)
        {
            boss = true;
        }

        if (en_death)
        {
            if (time != 0)
            {
                time--;
            }
            else
            {
                enAnim.Play("en_Death");
                transform.Translate((acceleration), 0, 0);
            }
        }
        if (complete) { if (transform.position.x >= 229f){ SceneManager.LoadScene("Level1"); } }
        else
        {
            
            //transform.Translate(acceleration, 0, -Input.acceleration.z);
            if (jump)
            {
                
                if (boss) { if (attacks == 5) { boss = false; anim.Play("attack"); en_death = true; time = 85; started = true; attacking = false; complete = true; } else if (attacking){ attacking = false; }{ if (!complete){ if (!started) { q.activate(); started = true; attacks++; } } } }
                else
                {
                    if (time <= 20) { time++; }
                    else
                    {
                        transform.Translate(0.1f, 0.25f, 0);
                    }
                    if (jumps != 4)
                    {
                        anim.Play("jump");

                    }
                    else
                    {
                        anim.Play("flip");
                        

                    }
                }
            }
            else
            {
                if (phone)
                {
                    acceleration = Input.acceleration.x;
                }
                else
                {
                    acceleration = 0.15f;
                }
                if (run)
                {
                    transform.Translate((acceleration), 0, 0);
                    anim.Play("run");
                }
                if (idle)
                {
                    anim.Play("Idle");
                }
                checkToStop();
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {

        jump = false; 
            time = 0;
        


    }
   void checkToStop()
    {
        if (transform.position.x >= 19f && transform.position.x <= 28f)
        {
            run = false;
            idle = true; if (!started) { q.activate(); started = true; }
        }
        else if (transform.position.x >= 43f && transform.position.x <= 44f)
        {
            run = false;idle = true; if (!started) { q.activate(); started = true; }
        }
        else if (transform.position.x >= 67f && transform.position.x <= 69f)
        {
            run = false; idle = true; if (!started) { q.activate(); started = true; }
        }
        else if (transform.position.x >= 107.5f && transform.position.x <= 109f)
        {
            run = false; idle = true; if (!started) { q.activate(); started = true; }
        }
        else if (transform.position.x >= 206.5f && transform.position.x <= 208f)
        {
            run = false; idle = true; if (!started) { q.activate(); started = true; }
        }
        else
        {
            run = true;
            idle = false;
            
        }
       
        
    }
    

    //settings
    public void SettingButton()
    {
        if (Sclicked)
        {
            Sclicked = false;
            settingcanvas.SetActive(false);
        }
        else
        {
            Sclicked = true;
            settingcanvas.SetActive(true);
        }
    }
    public void PhoneButton()
    {
        phone = true;
    }
    public void PCButton()
    {
        phone = false;
    }
    public void Clicked()
    {
        jump = true; jumps++; attacking = true; started = false;
    }
    
}
