using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Light_ctr : MonoBehaviour
{
    Animator animator;

    float anima_count;

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
        anima_count = Time.time;

        if (anima_count % 3 == 0)
        {
            animator.SetTrigger("FlashTrigger");
        }

        //scale_ctr += 0.0002f;

        //transform.localScale = new Vector3(scale_x += scale_ctr, scale_y += scale_ctr, 1);
    }
}
