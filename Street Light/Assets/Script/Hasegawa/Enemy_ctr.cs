using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ctr : Mapchip {

    //障害物用スクリプト（障害物は動かない）

    //障害物のマップでの固定番号
    private int Lk_number = 38;

    [SerializeField] int E_scale_x = 1;//障害物の大きさX
    [SerializeField] int E_scale_y = 1;//障害物の大きさY

    [SerializeField] int E_def_px = 0;//障害物の初期位置X
    [SerializeField] int E_def_py = 0;//障害物の初期位置Y

    [SerializeField] GameObject Enemy_single;

    private int count = 0;
	// Use this for initialization
	void Start () {

        //生成、子オブジェクトにする、マップ書き換え
        count = 0;
        for(int y = E_def_py; y < E_def_py + E_scale_y; y++){
            for(int x = E_def_px; x < E_def_px + E_scale_x; x++){
                count++;
                GameObject subgo = Instantiate(Enemy_single, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                subgo.name = this.gameObject.name + "-" + count;
                subgo.transform.parent = this.gameObject.transform;
                Map.GetComponent<Map>().Rewrite_map(x, y, Lk_number);
            }
        }
	}
	
}
