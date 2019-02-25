using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {
    teleporterScript t;
	// Use this for initialization
	void Start () {
        t = GameObject.Find("event").GetComponent<teleporterScript>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
