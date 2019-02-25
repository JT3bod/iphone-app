using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3 : MonoBehaviour {
    teleporterScript t;
	// Use this for initialization
	void Start () {
        t = GameObject.Find("event").GetComponent<teleporterScript>();
        t.level3();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
