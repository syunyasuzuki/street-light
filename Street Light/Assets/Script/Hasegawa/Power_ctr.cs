using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_ctr : MonoBehaviour {

    //電源用スクリプト

    string parent_name = "Noname";//親の名前

    //スイッチの状態（false = オフ）
    private bool switch_con = false;
    private GameObject Parent_Light;

    //プレイヤーが電源をつけたり消したりするとき用
    public void Switch_onoff(){
        if (switch_con == true) { switch_con = false; }
        else { switch_con = true; }
        Parent_Light.GetComponent<Light_ctr>().Power_onoff();
    }

    //親の名前と電源の状態を教える
    public void  What_parent(string name,bool status){
        parent_name = name;
        switch_con = status;
    }
    
	// Use this for initialization
	void Start () {
        Parent_Light = GameObject.Find(parent_name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
