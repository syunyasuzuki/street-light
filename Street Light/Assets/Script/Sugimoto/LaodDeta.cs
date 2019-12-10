using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaodDeta : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log(Time_ctr.minute);
        Debug.Log(Time_ctr.seconds);
        Time_ctr loadScene = FindObjectOfType<Time_ctr>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
