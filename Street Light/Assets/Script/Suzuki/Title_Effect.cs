using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Effect : MonoBehaviour
{
    float scale_x;
    float scale_y;
    float alpha;


	// Use this for initialization
	void Start ()
    {
        scale_x = 0.0f;
        scale_y = 0.0f;
        alpha = 1.0f;
        transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
    }
	
	// Update is called once per frame
	void Update ()
    {
        scale_x += 0.025f;
        scale_y += 0.025f;
        alpha -= 0.02f;
        transform.localScale = new Vector2(scale_x, scale_y);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (scale_x >= 2.0f)
        {
            scale_x = 0.0f;
            scale_y = 0.0f;
            alpha = 1.0f;
            transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
        }
	}
}
