using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_ctr : MonoBehaviour {

    //電源用スクリプト

    string parent_name = "Noname";//親の名前
    
    private GameObject Parent_Light;

    //プレイヤーが電源をつけたり消したりするとき用
    public void Switch_onoff(){
        Parent_Light.GetComponent<Light_ctr>().Power_onoff();
    }

    //親の名前と電源の状態を教える
    public void  What_parent(string name){
        parent_name = name;
    }
    
	// Use this for initialization
	void Start () {
        Parent_Light = GameObject.Find(parent_name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
