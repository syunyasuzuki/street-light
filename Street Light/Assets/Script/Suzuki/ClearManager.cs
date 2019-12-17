using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : Button_ctr
{
    public static bool Clear_check;

    public GameObject panel;
    public Image Clear_Logo;
    public Image Next;
    public Image Select;
    public Image Retry;

    float alpha;
    float Y = 2.0f;

	// Use this for initialization
	void Start ()
    {
        alpha = 0.0f;
        Next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        Select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        Retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        panel.SetActive(false);
        Clear_check = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Clear_check == true)
        {
            GameClear();
        }
    }

    public void GameClear()
    {
        panel.SetActive(true);
        Invoke("GameClear2", 1.0f);
    }

    public void GameClear2()
    {
        if (Clear_Logo.rectTransform.localPosition.y <= 130)
        {
            Clear_Logo.rectTransform.localPosition += new Vector3(0.0f, Y, 0.0f);
        }
        else
        {
            alpha += 0.05f;
            Next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            if (alpha >= 1.0f)
            {
                Clear_check = false;
            }
        }
    }
}
