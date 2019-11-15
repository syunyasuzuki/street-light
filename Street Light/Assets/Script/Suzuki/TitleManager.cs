using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Fade_ctr.isFade = true;
            Fade_ctr.isFadeOut = true;
            Invoke("Select", 2.0f);
        }
	}

    void Select()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
