using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart1 : MonoBehaviour {

    //スタートのSE
    public AudioSource StartSE;

	// Use this for initialization
	void Start () {
        //SE取得
        StartSE = gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //音鳴らす
    public void PlaySE()
    {
        StartSE.Play();
    }
}
