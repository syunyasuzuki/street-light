using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
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
    public void Go_Title()
    {
        //タイトルシーンに移動
        SceneManager.LoadScene("TitleScene");
    }

    //ボタンを押したら呼び出すメソッド
    public void Go_Select()
    {
        //セレクトシーンに移動
        SceneManager.LoadScene("SelectScene");
    }
}
