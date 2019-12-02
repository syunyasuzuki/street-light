using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
}
