using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class settings : MonoBehaviour {
    bool Sclicked = false;
    movement m;
    GameObject settingcanvas;
    // Use this for initialization
    void Start () {
        settingcanvas = GameObject.Find("SettingMenu");
        m = GameObject.Find("Player").GetComponent<movement>();
        settingcanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SettingButton()
    {
        if (Sclicked)
        {
            Sclicked = false;
            settingcanvas.SetActive(false);
            m.paused = true;
        }
        else
        {
            Sclicked = true;
            settingcanvas.SetActive(true);
            m.paused = false;
        }
    }
    public void PhoneButton()
    {
        m.Phone = true;
        SettingButton();
        m.paused = false;
    }
    public void PCButton()
    {
        m.Phone = false;
        SettingButton();
        m.paused = false;

    }
}
