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

    public void Game1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Game2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Game3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
