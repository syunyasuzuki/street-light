using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Light_ctr : MonoBehaviour
{
    Animator animator;

    int anime_count;

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
        anime_count++;
        
        if (anime_count == 180)
        {
            animator.SetTrigger("FlashTrigger");
            anime_count = 0;
        }

        if (scale_ctr <= 0)
        {
            scale_ctr += 0.002f;
            if (scale_ctr >= 0.12)
            {
                scale_ctr -= 0.002f;
            }
        }
        
        transform.localScale = new Vector3(scale_x += scale_ctr, scale_y += scale_ctr, 1);
    }
}
