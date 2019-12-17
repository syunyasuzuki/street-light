using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSE : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip SE;

    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //再生
    public void PushButton()
    {
        audioSource.PlayOneShot(SE);
    }
}
