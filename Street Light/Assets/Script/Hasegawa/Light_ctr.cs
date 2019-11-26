using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_ctr : Mapchip {

    //ライト用スクリプト

    //---------------インスペクター上で変化させれるもの--------

    [SerializeField] [Header("ライトの大きさ")] [Range(1,10)]int L_scale_x = 2;//ライトの大きさX
    [SerializeField] [Range(1,10)]int L_scale_y = 1;//ライトの大きさY

    [SerializeField] [Header("初期位置（基点位置）")] int L_def_px = 0;//初期位置X（基点）
    [SerializeField] int L_def_py = 0;//初期位置Y（基点）

    [SerializeField] [Header("ライトの動く幅（動く場合）")] [Range(0, 10)] int Move_weight = 0;//動く幅
    //動く方向X（左 -1 < x > 1 右）
    [SerializeField] int Move_drct_x = 0;
    //動く方向Y（上 1 < y > -1 下）
    [SerializeField] int Move_drct_y = 0;

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
    private int subcount = 0;//一時的な入れ物2
    private bool Light_status = true;//最初から光ってるか
    //現在ライトがついているか（点滅時）
    private bool light_flash = true;
    float flash_count = 0;//点滅時のカウント
    int position_x = 0;//マップでの位置番号X
    int position_y = 0;//マップでの位置番号Y
    //ライトの状態を保存する配列
    int[,] light_mode;
    float[] Template_x = new float[11] { 1.0f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 1.0f };
    float[] Template_y = new float[11] { 1.0f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 1.0f };

    //--------------------------------------------------------

    //------------------他からアクセスできるもの--------------

    //電源をオンオフする
    public void Power_onoff(){
        if (Light_status == true){
            Light_status = false;
            for(int y = position_y; y < position_y + L_scale_y; y++){
                for(int x = position_x; x < position_x + L_scale_x; x++){
                    Map.GetComponent<Map>().Rewrite_map(x, y, 0);
                }
            }
        }
        else{
            Light_status = true;
            for (int y = position_y; y < position_y + L_scale_y; y++){
                for (int x = position_x; x < position_x + L_scale_x; x++){
                    Map.GetComponent<Map>().Rewrite_map(x, y, light_mode[y,x]);
                }
            }
        }
    }
    
    //--------------------------------------------------------

    // Use this for initialization
    void Start () {
        count = 0;
        subcount = 0;
        if(Move_drct_x < 0 || Move_drct_x > 0){
            count = 1;
            subcount = 0;
        }
        if (Move_drct_y < 0 || Move_drct_y > 0){
            count = 0;
            subcount = 1;
        }
        light_mode = new int[L_scale_y + subcount, L_scale_x + count];
        //電源が必要な場合配置する
        if (Need_power == true){
            GameObject subgo = Instantiate(Power, new Vector3(P_def_px, P_def_py, 0), Quaternion.identity);
            subgo.name = this.gameObject.name + "-power";
            subgo.GetComponent<Power_ctr>().What_parent(this.gameObject.name, Def_power);
            subgo.transform.parent = this.gameObject.transform;
            if (Def_power == true){
                Light_status = false;
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
        //進ませる方向に応じてライトの位置を配列の中でずらす
        if (Move_drct_x != 0){
            count = 0;
            if(Move_drct_x < 0){
                count = 1;
            }
            for (int y = 0; y < L_scale_y; y++){
                for (int x = 0; x < L_scale_x; x++){
                    light_mode[y, x + count] = 1;
                }
            }
        }
        if(Move_drct_y!=0 && Move_drct_x == 0){
            count = 0;
            if(Move_drct_y > 0){
                count = 1;
            }
            for(int y = 0; y < L_scale_y; y++){
                for(int x = 0; x < L_scale_x; x++){
                    light_mode[y + count, x] = 1;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        flash_count += Time.deltaTime;
        //電源が入っている時だけ処理する
        if (Light_status == true){
            //点滅がオンになってる場合
            if (Flashing == true){
                if (light_flash == true && flash_count > F_weight){

                }
                if(light_flash==false && flash_count > F_weight){

                }
            }
        }
	}
}
