using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
    public class teleporterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 1f);
	}
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Level2"); 
    }
}
