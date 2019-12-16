using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_set : MonoBehaviour {

    [SerializeField] bool Home_or_Key = true;
    private GameObject Home;

	// Use this for initialization
	void Start () {
        if (Home_or_Key == false){
            Home = GameObject.Find("House");
        }
	}

    void OnTriggerEnter2D(Collider2D col){

    }

}
