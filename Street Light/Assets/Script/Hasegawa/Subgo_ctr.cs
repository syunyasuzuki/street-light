using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subgo_ctr : MonoBehaviour {

    GameObject map;
    bool state = false;
    int px;
    int py;

    public void State_set(int x,int y){
        px = x;
        py = y;
    }

    void Start(){
        map = GameObject.Find("MapManager");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    void Update(){
        if (state == false && map.GetComponent<Map>().Map_state(px,py)!=0){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            state = true;
            Debug.Log("ついた");
        }
        if (state == true && map.GetComponent<Map>().Map_state(px,py) == 0){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            state = false;
            Debug.Log("きえた");
        }
    }
}
