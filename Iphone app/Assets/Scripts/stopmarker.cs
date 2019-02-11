using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmarker : MonoBehaviour {
    movement m;
	// Use this for initialization
	void Start () {
        m = GameObject.Find("Player").GetComponent<movement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        m.stopped();
    }
}
