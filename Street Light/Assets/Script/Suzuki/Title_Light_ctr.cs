﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Light_ctr : MonoBehaviour
{
    Animator animator;

    int animator_count;

    float scale_x;
    float scale_y;
    float scale_ctr;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        scale_x = transform.localScale.x;
        scale_y = transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        animator_count++;

        if (animator_count == 180)
        {
            animator.SetTrigger("FlashTrigger");
            animator_count = 0;
        }

        //scale_ctr += 0.0002f;

        //transform.localScale = new Vector3(scale_x += scale_ctr, scale_y += scale_ctr, 1);
    }
}
