using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecontroller : MonoBehaviour {

    float time = 0.0f;
    Text text;
    public Text timeLabel;

	// Use this for initialization
	void Start () {

        //Text取得
        text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //時間加算
        time += Time.deltaTime;
        //時間表示
        timeLabel.text=string.Format("00:00",(int)time);
		
	}
}
