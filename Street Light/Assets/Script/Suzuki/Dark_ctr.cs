using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark_ctr : MonoBehaviour
{
    Animator animator;

    int dark_count;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        dark_count++;
        if (dark_count == 180)
        {
            animator.SetTrigger("DarkTrigger");
            dark_count = 0;
        }
    }
}
