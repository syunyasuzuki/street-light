using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_ctr : MonoBehaviour
{
    public static float seconds = 0;   //秒
    public float beforeSeconds;
    public Text timetext;

    // Use this for initialization
    void Start()
    {
        seconds = 0f;
        beforeSeconds = 0f;
        //Text取得
        timetext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //時間加算
        seconds += Time.deltaTime;

        //値が変わった時テキストを更新
        if ((int)seconds != (int)beforeSeconds)
        {
            //時間表示
            timetext.text = ((int)(seconds / 60)).ToString("00") + ":" + ((int)(seconds % 60)).ToString("00");
        }
        beforeSeconds = seconds;
        PlayerPrefs.SetFloat("seconds", seconds);

    }
        //SceneManager.LoadScene("ResultScene");
}