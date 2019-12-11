using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ctr : MonoBehaviour {

    //障害物用スクリプト（障害物は動かない）

    [SerializeField] int E_scale_x = 1;//障害物の大きさX
    [SerializeField] int E_scale_y = 1;//障害物の大きさY

    [SerializeField] int E_def_px = 0;//障害物の初期位置X
    [SerializeField] int E_def_py = 0;//障害物の初期位置Y

    [SerializeField] GameObject Enemy_single;

    private int count = 0;
	// Use this for initialization
	void Start () {
        //生成、子オブジェクトにする
        transform.position = new Vector3(E_def_px, E_def_py, 0);
        count = 0;
        for(int y = 0; y < E_scale_y; y++){
            for(int x = 0; x < E_scale_x; x++){
                count++;
                GameObject subgo = Instantiate(Enemy_single) as GameObject;
                subgo.name = this.gameObject.name + "-" + count;
                subgo.GetComponent<Subgo_ctr>().State_set(E_def_px + x, E_def_py + y);
                subgo.transform.parent = this.gameObject.transform;
                subgo.transform.localPosition = new Vector3(x, y, 0);
                subgo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }
	}
}
