using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_ctr : MonoBehaviour
{
    public Image FadeImage;

    public static bool isFade;
    public static bool isFadeIn;
    public static bool isFadeOut;

    public static float alpha;

	// Use this for initialization
	void Start ()
    {
        alpha = 0.0f;
        isFade = true;
        isFadeIn = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isFade)
        {
            if (isFadeIn)
            {
                FadeIn();
            }
            if (isFadeOut)
            {
                FadeOut();
            }
        }
	}

    void FadeIn()
    {
        alpha -= 0.05f;
        FadeImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha <= 0.0f)
        {
            isFade = false;
            isFadeIn = false;
        }
    }
    void FadeOut()
    {
        alpha += 0.05f;
        FadeImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha >= 1.0f)
        {
            isFade = false;
            isFadeOut = false;
        }
    }
}
