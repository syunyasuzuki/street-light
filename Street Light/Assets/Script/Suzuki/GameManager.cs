using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Button_ctr
{
    [SerializeField] GameObject menu;

	// Use this for initialization
	void Start ()
    {
        menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
	}
}
