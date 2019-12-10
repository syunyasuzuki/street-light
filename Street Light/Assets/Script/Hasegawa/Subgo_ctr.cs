using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subgo_ctr : MonoBehaviour {

    GameObject map;
    private bool state = false;
    private int px;
    private int py;

    public void State_set(int x,int y){
        state = false;
        px = x;
        py = y;
    }

    void Start(){
        map = GameObject.Find("MapManager");
    }

    void Update(){
        if (state == false && map.GetComponent<Map>().Map_state(px,py)!=0){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            state = true;
        }
        if (state == true && map.GetComponent<Map>().Map_state((int)transform.position.x,(int)transform.position.y) == 0){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            state = false;
        }
    }
}
