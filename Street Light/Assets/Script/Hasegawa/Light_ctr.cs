using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Light_ctr : Mapchip {

    //ライト用スクリプト

    //---------------インスペクター上で変化させれるもの--------

    [SerializeField] [Header("ライトの大きさ")] [Range(1,10)]int L_scale_x = 2;//ライトの大きさX
    [SerializeField] [Range(1,10)]int L_scale_y = 1;//ライトの大きさY

    [SerializeField] [Header("初期位置（基点位置）")] int L_def_px = 0;//初期位置X（基点）
    [SerializeField] int L_def_py = 0;//初期位置Y（基点）

    [SerializeField] [Header("ライトの動く量（動く場合）")] [Range(-10, 10)] int Move_drct_x = 0;//基点から動く幅X
    [SerializeField] [Range(-10,10)]int Move_drct_y = 0;//基点から動く幅Y

    [SerializeField] [Header("点滅の有無、点滅の間隔")] bool Flashing = false;//点滅の有無
    [SerializeField] [Range(0.0f,10.0f)]float F_weight = 1.0f;//点滅の間隔

    [SerializeField] [Header("電源が必要かどうか")] bool Need_power = false;//電源が必要か
    [SerializeField] bool Def_power = true;//最初の電源の状態
    [SerializeField] int P_def_px = 0;//電源の位置X
    [SerializeField] int P_def_py = 0;//電源の位置Y

    //--------------------------------------------------------

    //---------------外から取り込むやつ-----------------------

    [SerializeField] [Header("その他（触らないで）")]GameObject Light_single;//光１マス分
    [SerializeField] GameObject Power;//電源

    //--------------------------------------------------------

    //---------------中で動くやつ-----------------------------

    //ライトのマップでの固定番号（完全に光に当たってるところ）
    private const int Lk_number = 1;
    private int count = 0;//一時的な入れ物
    private int move_vec = 0;//現在の移動方向
    private int move_x = 0;//動く量X
    private int move_y = 0;//動く量Y
    private int move_point_x = 0;//移動先X
    private int move_point_y = 0;//移動先Y
    private bool witch_move;//XかY
    private bool light_status = true;//最初から光ってるか
    //現在ライトがついているか（点滅時）
    private bool light_flash = true;
    float flash_count = 0;//点滅時のカウント
    float position_x = 0;//マップでの位置X
    float position_y = 0;//マップでの位置Y
    //ライトの状態を保存する配列
    int[,] light_mode;
    float[] Template = new float[11] { 1.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };

    //--------------------------------------------------------

    //------------------他からアクセスできるもの--------------

    //電源をオンオフする
    public void Power_onoff(){
        if (light_status == true){
            light_status = false;
            for(int y = (int)position_y; y < position_y + L_scale_y + move_y; y++){
                for(int x = (int)position_x; x < position_x + L_scale_x + move_x; x++){
                    Map.GetComponent<Map>().Rewrite_map(x, y, 0);
                }
            }
        }
        else{
            light_status = true;
            for (int y = (int)position_y; y < position_y + L_scale_y + move_y; y++){
                for (int x = (int)position_x; x < position_x + L_scale_x + move_x; x++){
                    Map.GetComponent<Map>().Rewrite_map(x, y, light_mode[y,x]);
                }
            }
        }
    }
    
    //--------------------------------------------------------

    //書き変えの短縮
    private void light_change(ref int num){
        switch (num){
            case 1:
                break;
        }
    }

    // Use this for initialization
    void Start () {
        //各内部パラメータの設定
        position_x = L_def_px;
        position_y = L_def_py;
        if (Move_drct_x != 0) { move_x = 1; }
        if (Move_drct_y != 0 && move_x != 1) { move_y = 1; }
        light_mode = new int[L_scale_y + move_y, L_scale_x + move_x];
        //電源が必要な場合配置する
        if (Need_power == true){
            GameObject subgo = Instantiate(Power, new Vector3(P_def_px, P_def_py, 0), Quaternion.identity);
            subgo.name = this.gameObject.name + "-power";
            subgo.GetComponent<Power_ctr>().What_parent(this.gameObject.name, Def_power);
            subgo.transform.parent = this.gameObject.transform;
            if (Def_power == true){
                light_status = false;
            }
        }
        //ライトを配置、名前を変更、子オブジェクトにする
        count = 0;
        for(int y = L_def_py; y < L_def_py + L_scale_y; y++){
            for(int x = L_def_px; x < L_def_px + L_scale_x; x++){
                count++;
                GameObject subgo = Instantiate(Light_single, new Vector3(x, y, 0), Quaternion.identity);
                subgo.name = this.gameObject.name + count;
                subgo.transform.parent = this.gameObject.transform;
            }
        }
        //進ませる方向に応じてライトの位置を配列の中でずらすX
        move_point_x = L_def_px + Move_drct_x;
        count = 0;
        move_vec = 0;
        witch_move = true;
        if (move_point_x < L_def_px){
            count = 1;
            move_vec = -1;
        }
        if (move_point_x > L_def_px){
            count = 1;
            move_vec = 1;
        }
        for (int y = 0; y < L_scale_y; y++){
            for (int x = 0; x < L_scale_x; x++){
                light_mode[y, x + count] = 1;
            }
        }
        //進ませる方向に応じてライトの位置を配列の中でずらすY（Xが動く場合Yは動かなくする）
        if(move_vec == 0){
            move_point_y = L_def_py + Move_drct_y;
            count = 0;
            move_vec = 0;
            witch_move = false;
            if(move_point_y > L_def_py){
                count = 1;
                move_vec = 1;
                witch_move = false;
            }
            if (move_point_y < L_def_py){
                count = 1;
                move_vec = -1;
                witch_move = true;
            }
            for(int y = 0; y < L_scale_y; y++){
                for(int x = 0; x < L_scale_x; x++){
                    light_mode[y + count, x] = 1;
                }
            }
        }
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        flash_count += Time.deltaTime;
        //電源が入っている時だけ処理する
        if (light_status == true){
            //点滅がオンになってる場合点滅させる
            if (Flashing == true){
                if (light_flash == true && flash_count > F_weight){
                    light_flash = false;
                    flash_count = 0;
                    for(int y = (int)position_y; y < position_y + L_scale_y + move_y; y++){
                        for(int x = (int)position_x; x < position_x + L_scale_x + move_x; x++){
                            Map.GetComponent<Map>().Rewrite_map(x, y, 0);
                        }
                    }
                }
                if(light_flash==false && flash_count > F_weight){
                    light_flash = true;
                    flash_count = 0;
                    for (int y = 0; y < L_scale_y + move_y; y++){
                        for (int x = 0; x < L_scale_x + move_x; x++){
                            Map.GetComponent<Map>().Rewrite_map((int)position_x + x,(int)position_y + y, light_mode[y,x]);
                        }
                    }
                }
            }
            //光の移動
            if (move_vec != 0){
                //X
                if(witch_move == true){
                    if (move_vec == 1 && light_mode[0, L_scale_x] == 1){
                        for (int y = 0; y < L_scale_y; y++){
                            for (int x = 1; x <= L_scale_x; x++){
                                light_mode[y, x - 1] = light_mode[y, x];
                            }
                            light_mode[y, L_scale_x] = 0;
                        }
                    }
                    if (witch_move == true && move_vec == -1 && light_mode[0, 0] == 1){
                        for (int y = 0; y < L_scale_y; y++){
                            for (int x = L_scale_x; x > 0; x--){
                                light_mode[y, x] = light_mode[y, x - 1];
                            }
                            light_mode[0, 0] = 0;
                        }
                    }
                    for (int y = 0; y < L_scale_y; y++){
                        light_change(ref light_mode[y, 0]);
                        light_change(ref light_mode[y, L_scale_x]);
                    }
                    //光本体（見える部分）の移動
                    position_x += 0.1f;
                    position_x = (float)Math.Round(position_x, 1);
                    transform.position = new Vector3(position_x, position_y, 0);
                    //移動先と現在地が重なった場合、または初期位置と現在地が重なった場合方向転換する
                    if (position_x == move_point_x || position_x == L_def_px){
                        move_vec *= -1;
                    }
                }
                //Y
                if (witch_move == false){

                }
            }
        }
	}
}
