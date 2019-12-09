using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_ctr : MonoBehaviour
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
    public void Go_select()
    {
        //セレクトシーンに移動
        SceneManager.LoadScene("SelectScene");
    }

    //ボタンを押したら呼び出すメソッド
    public void Go_Title()
    {
        //タイトルシーンに移動
        SceneManager.LoadScene("TitleScene");
    }

    //-----------------------GameScene---------------------------//
    //ボタンを押したら呼び出すメソッド
    public void Game1()
    {
        //ステージ1-1に移動
        SceneManager.LoadScene("Stage1");
    }

    //ボタンを押したら呼び出すメソッド
    public void Game2()
    {
        //ステージ1-2に移動
        SceneManager.LoadScene("Stage2");
    }

    //ボタンを押したら呼び出すメソッド
    public void Game3()
    {
        //ステージ1-3に移動
        SceneManager.LoadScene("Stage3");
    }
    //--------------------------------------------------------------//
}
