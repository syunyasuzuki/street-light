using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Light_ctr : MonoBehaviour
{
    Animator animator;

    int anime_count;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        anime_count++;
        if (anime_count == 180)
        {
            animator.SetTrigger("FlashTrigger");
            anime_count = 0;
        }
    }
}
