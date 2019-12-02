using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //ボタンを押したら呼び出すメソッド
    public void Go_Title_C()
    {
        //タイトルシーンに移動
        SceneManager.LoadScene("TitleScene");
    }

    //ボタンを押したら呼び出すメソッド
    public void Next()
    {
        //セレクトシーンに移動
        SceneManager.LoadScene("SelectScene");
    }
}
