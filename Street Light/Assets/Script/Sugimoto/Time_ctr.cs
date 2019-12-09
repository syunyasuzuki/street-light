using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_ctr : MonoBehaviour
{

    public int minute = 0;         //分
    public float seconds = 0.0f;   //秒

    public Text timetext;

    // Use this for initialization
    void Start()
    {

        //Text取得
        timetext = GetComponent<Text>();

    }


    // Update is called once per frame
    void Update()
    {

        //時間加算
        seconds += Time.deltaTime;

        //時間表示
        timetext.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
    }
}