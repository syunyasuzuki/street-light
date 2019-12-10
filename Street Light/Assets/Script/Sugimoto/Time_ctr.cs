using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_ctr : MonoBehaviour
{
    public static int minute;         //分
    public static float seconds;   //秒
    public float beforeSeconds;
    public Text timetext;

    // Use this for initialization
    void Start()
    {
        minute = 0;
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

        //分になったら秒を0にする
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //値が変わった時テキストを更新
        if ((int)seconds != (int)beforeSeconds)
        {
            //時間表示
            timetext.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        beforeSeconds = seconds;

    }
    ////テスト
    ////　スタートボタンを押したら実行
    //public void OnClickGameStart()
    //{
    //    SceneManager.LoadScene("Stage2");
    //}
    
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
}