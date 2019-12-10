using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeA : MonoBehaviour {
    float seconds;
    [SerializeField] Text text;

    // Use this for initialization
    void Start () {
        seconds = Time_ctr.seconds;
        text.text = ((int)(seconds / 60)).ToString("00") + ":" + ((int)(seconds % 60)).ToString("00");

    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
