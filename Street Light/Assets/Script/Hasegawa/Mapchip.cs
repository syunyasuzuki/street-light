using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapchip : MonoBehaviour {

    //各マップ素材に継承させる用のスクリプト

    //---------------インスペクター上で変化させれるもの--------
    
    [SerializeField] const int L_scale_x = 1;//ライトの大きさX
    [SerializeField] const int L_scale_y = 1;//ライトの大きさY

    [SerializeField] const int F_position_x = 0;//初期位置X
    [SerializeField] const int F_position_y = 0;//初期位置Y

    [SerializeField] const int Move_weight = 0;//動く幅
    [SerializeField] const bool Move_drct = true;//動く方向（true = 横）

    [SerializeField] const bool Flashing = false;//点滅の有無
    [SerializeField] const float F_weight = 1.0f;//点滅の間隔

    //--------------------------------------------------------

    //---------------中で動くやつ-----------------------------

    int position_x = 0;//マップでの位置番号X
    int position_y = 0;//マップでの位置番号Y
    int position_number = 0;//マップでの状態
    int[,] light_mode = new int [L_scale_y + 1,L_scale_x + 1];//ライトの状態を保存する配列

    //--------------------------------------------------------
    
    //マップの位置を書き変える
    void Map_sarch(){
        //ライトの大きさに応じて光の場所を調節する

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
