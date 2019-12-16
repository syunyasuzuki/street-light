using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Light_ctr : MonoBehaviour
{

    //ライト用スクリプト

    //---------------インスペクター上で変化させれるもの--------

    [SerializeField] [Header("ライトの大きさ")] [Range(1, 10)] int L_scale_x = 2;//ライトの大きさX
    [SerializeField] [Range(1, 10)] int L_scale_y = 1;//ライトの大きさY

    [SerializeField] [Header("初期位置（基点位置）")] int L_def_px = 0;//初期位置X（基点）
    [SerializeField] int L_def_py = 0;//初期位置Y（基点）

    [SerializeField] [Header("ライトを動かすか")] bool Need_Move = false;//動かすか
    [SerializeField] bool Move_vec = true;//動かす方向XかY
    [SerializeField] [Range(-10, 10)] int Move_drct = 0;//基点から動く幅
    [SerializeField] [Range(1, 10)] int Cut_move = 2;//カットするフレーム

    [SerializeField] [Header("点滅の有無、点滅の間隔")] bool Flashing = false;//点滅の有無
    [SerializeField] [Range(0.0f, 10.0f)] float F_weight = 1.0f;//点滅の間隔

    [SerializeField] [Header("電源が必要か")] bool Need_power = false;//電源が必要か
    [SerializeField] bool Def_power = false;//最初の街灯の状態
    [SerializeField] int P_def_px = 0;//電源の位置X
    [SerializeField] int P_def_py = 0;//電源の位置Y

    //--------------------------------------------------------

    //---------------外から取り込むやつ-----------------------

    [SerializeField] [Header("その他（触らないで）")] GameObject Light_single;//光１マス分
    [SerializeField] GameObject Power;//電源
    private GameObject Map;

    //--------------------------------------------------------

    //---------------中で動くやつ-----------------------------

    //ライトのマップでの固定番号（完全に光に当たってるところ）
    private const int Lk_number = 1;
    float Stop_time = 0.75f;//止める時間
    private int count = 0;//一時的な入れ物
    private int cut_count = 0;
    private int move_vec = 0;//現在の移動方向
    private int move_x = 0;//動く量X
    private int move_y = 0;//動く量Y
    //移動をカウントで制御する
    private int move_count = 0;
    //移動先までの合計カウント
    private int move_point = 0;
    private bool light_status = true;//最初から光ってるか
    private float move_stoper = 0;
    //現在ライトがついているか（点滅時）
    private bool light_flash = true;
    float flash_count = 0;//点滅時のカウント
    int position_x = 0;//マップでの位置X
    int position_y = 0;//マップでの位置Y
    //ライトの状態を保存する配列
    int[,] light_mode;
    float Preset = 0.1f;//一回の移動量
    //生成した街灯を管理する配列
    GameObject[] light_child;

    //--------------------------------------------------------

    //------------------他からアクセスできるもの--------------

    //電源をオンオフする
    public void Power_onoff()
    {
        if (light_status == true)
        {
            light_status = false;
            for (int y = 0; y < L_scale_y + move_y; y++)
            {
                for (int x = 0; x < L_scale_x + move_x; x++)
                {
                    gameObject.GetComponent<Map>().Rewrite_map(L_def_px + position_x + x, L_def_py + position_y + y, 0);
                }
            }
            Light_off();
        }
        else
        {
            light_status = true;
            for (int y = 0; y < L_scale_y + move_y; y++)
            {
                for (int x = 0; x < L_scale_x + move_x; x++)
                {
                    gameObject.GetComponent<Map>().Rewrite_map(L_def_px + position_x + x, L_def_py + position_y + y, light_mode[y, x]);
                }
            }
            Light_on();
        }
    }

    //--------------------------------------------------------

    //書き変えの短縮
    private void Light_change(ref int num)
    {
        switch (num)
        {
            case 0:
                if (Move_vec == true)
                {
                    if (move_vec == 1) { num = 19; }
                    else { num = 10; }
                }
                else
                {
                    if (move_vec == 1) { num = 37; }
                    else { num = 28; }
                }
                break;
            case 1:
                if (Move_vec == true)
                {
                    if (move_vec == 1) { num = 2; }
                    else { num = 11; }
                }
                else
                {
                    if (move_vec == 1) { num = 20; }
                    else { num = 29; }
                }
                break;
            case 2:
                if (move_vec == 1) { num = 3; }
                else { num = 1; }
                break;
            case 10:
                if (move_vec == 1) { num = 0; }
                else { num = 9; }
                break;
            case 11:
                if (move_vec == 1) { num = 1; }
                else { num = 12; }
                break;
            case 19:
                if (move_vec == 1) { num = 18; }
                else { num = 0; }
                break;
            case 20:
                if (move_vec == 1) { num = 21; }
                else { num = 1; }
                break;
            case 28:
                if (move_vec == 1) { num = 0; }
                else { num = 27; }
                break;
            case 29:
                if (move_vec == 1) { num = 1; }
                else { num = 30; }
                break;
            case 37:
                if (move_vec == 1) { num = 36; }
                else { num = 0; }
                break;
            default:
                if (Move_vec == true)
                {
                    if (num >= 3 && num <= 9) { num += move_vec; }
                    else { num -= move_vec; }
                }
                else
                {
                    if (num >= 21 && num <= 27) { num += move_vec; }
                    else { num -= move_vec; }
                }
                break;
        }
    }

    //α値変更
    private void Light_on()
    {
        foreach (GameObject subgo in light_child)
        {
            subgo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
    private void Light_off()
    {
        foreach (GameObject subgo in light_child)
        {
            subgo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    // Use this for initialization
    void Start()
    {
        //基点位置へ移動させる
        transform.position = new Vector3(L_def_px, L_def_py, 0);
        Map = GameObject.Find("MapManager");
        //ライトの状態を保存する配列の確定
        if (Need_Move == true)
        {
            if (Move_vec == true) { move_x = 1; move_y = 0; }
            else { move_x = 0; move_y = 1; }
            //移動量、移動しだす方向確定
            move_point = Move_drct * 10;
            if (Move_drct > 0) { move_vec = 1; }
            else { move_vec = -1; }
        }
        light_mode = new int[L_scale_y + move_y, L_scale_x + move_x];
        light_child = new GameObject[L_scale_x * L_scale_y];
        //電源が必要な場合配置する
        if (Need_power == true)
        {
            GameObject subgo = Instantiate(Power, new Vector3(P_def_px, P_def_py, 0), Quaternion.identity);
            subgo.name = gameObject.name + "-power";
            subgo.GetComponent<Subgo_ctr>().State_set(P_def_px, P_def_py);
            subgo.GetComponent<Power_ctr>().What_parent(gameObject.name, Def_power);
            subgo.transform.parent = gameObject.transform;
            light_status = Def_power;
        }
        //ライトを配置、名前を変更、子オブジェクトにする
        count = 0;
        for (int y = 0; y < L_scale_y; y++)
        {
            for (int x = 0; x < L_scale_x; x++)
            {
                GameObject subgo = Instantiate(Light_single) as GameObject;
                subgo.name = gameObject.name + "-" + count;
                subgo.transform.parent = gameObject.transform;
                subgo.transform.localPosition = new Vector3(x, y, 0);
                light_child[count] = subgo;
                count++;
            }
        }
        if (Def_power == false)
        {
            Light_off();
        }
        if (Need_Move == true)
        {
            //進ませる方向に応じてライトの位置を配列の中でずらすX
            if (Move_vec == true)
            {
                count = 0;
                if (move_vec == -1)
                {
                    count = 1;
                }
                for (int y = 0; y < L_scale_y; y++)
                {
                    for (int x = 0; x < L_scale_x; x++)
                    {
                        light_mode[y, x + count] = 1;
                    }
                }
            }
            //進ませる方向に応じてライトの位置を配列の中でずらすY
            else
            {
                count = 0;
                if (move_vec == 1)
                {
                    count = 1;
                }
                for (int y = 0; y < L_scale_y; y++)
                {
                    for (int x = 0; x < L_scale_x; x++)
                    {
                        light_mode[y + count, x] = 1;
                    }
                }
            }
        }
        //街灯が動かない場合
        else
        {
            for (int y = 0; y < L_scale_y; y++)
            {
                for (int x = 0; x < L_scale_x; x++)
                {
                    light_mode[y, x] = 1;
                }
            }
        }
        //マップに反映させる
        if (light_status != false)
        {
            for (int y = 0; y < L_scale_y + move_y; y++)
            {
                for (int x = 0; x < L_scale_x + move_x; x++)
                {
                    Map.GetComponent<Map>().Rewrite_map(L_def_px + x, L_def_py + y, light_mode[y, x]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cut_count++;
        flash_count += Time.deltaTime;
        //電源が入っている時だけ処理する
        if (light_status == true)
        {
            //点滅がオンになってる場合点滅させる
            if (Flashing == true)
            {
                if (light_flash == true && flash_count > F_weight)
                {
                    light_flash = false;
                    flash_count = 0;
                    for (int y = 0; y < L_scale_y + move_y; y++)
                    {
                        for (int x = 0; x < L_scale_x + move_x; x++)
                        {
                            Map.GetComponent<Map>().Rewrite_map(L_def_px + position_x + x, L_def_py + position_y + y, 0);
                        }
                    }
                    Light_off();
                }
                if (light_flash == false && flash_count > F_weight)
                {
                    light_flash = true;
                    flash_count = 0;
                    for (int y = 0; y < L_scale_y + move_y; y++)
                    {
                        for (int x = 0; x < L_scale_x + move_x; x++)
                        {
                            Map.GetComponent<Map>().Rewrite_map(L_def_px + position_x + x, L_def_py + position_y + y, light_mode[y, x]);
                        }
                    }
                    Light_on();
                }
            }
            if (light_flash == true)
            {
                //光の移動
                move_stoper -= Time.deltaTime;
                if (Need_Move == true && cut_count % Cut_move == 0 && move_stoper <= 0)
                {
                    move_count += move_vec;
                    //X
                    if (Move_vec == true)
                    {
                        //内部数値移動処理
                        for (int y = 0; y < L_scale_y + move_y; y++)
                        {
                            Light_change(ref light_mode[y, 0]);
                            Light_change(ref light_mode[y, L_scale_x]);
                        }
                        if (move_count % 10 == 0)
                        {
                            //反転処理
                            if (move_count == move_point || move_count == 0)
                            {
                                move_stoper = Stop_time;
                                move_vec *= -1;
                                count = 0;
                                if (move_vec == -1)
                                {
                                    count = 1;
                                }
                                for (int y = 0; y < L_scale_y + move_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x + move_x; x++)
                                    {
                                        light_mode[y, x] = 0;
                                    }
                                }
                                for (int y = 0; y < L_scale_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x; x++)
                                    {
                                        light_mode[y, x + count] = 1;
                                    }
                                }
                            }
                            //枠移動処理
                            else
                            {
                                count = 0;
                                //右向き
                                if (move_vec == 1)
                                {
                                    position_x++;
                                }
                                //左向き
                                else
                                {
                                    count = 1;
                                    position_x--;
                                }
                                //配列をクリア
                                for (int y = 0; y < L_scale_y + move_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x + move_x; x++)
                                    {
                                        light_mode[y, x] = 0;
                                    }
                                }
                                //街灯を再設定
                                for (int y = 0; y < L_scale_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x; x++)
                                    {
                                        light_mode[y, x + count] = 1;
                                    }
                                }
                            }
                        }
                        transform.position = new Vector3(L_def_px + Preset * move_count, L_def_py, 0);
                    }
                    //Y
                    else
                    {
                        //内部数値移動処理
                        for (int x = 0; x < L_scale_x + move_x; x++)
                        {
                            Light_change(ref light_mode[0, x]);
                            Light_change(ref light_mode[L_scale_y, x]);
                        }
                        if (move_count % 10 == 0)
                        {
                            //反転処理
                            if (move_count == move_point || move_count == 0)
                            {
                                move_stoper = Stop_time;
                                move_vec *= -1;
                                count = 0;
                                if (move_vec == 1)
                                {
                                    count = 1;
                                }
                                for (int y = 0; y < L_scale_y + move_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x + move_x; x++)
                                    {
                                        light_mode[y, x] = 0;
                                    }
                                }
                                for (int y = 0; y < L_scale_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x; x++)
                                    {
                                        light_mode[y + count, x] = 1;
                                    }
                                }
                            }
                            //枠移動処理
                            else
                            {
                                count = 0;
                                //上向き
                                if (move_vec == 1)
                                {
                                    for(int x = 0; x < L_scale_x + move_x; x++)
                                    {

                                    }
                                    count = 1;
                                    position_y++;
                                }
                                //下向き
                                else
                                {
                                    position_y--;
                                }
                                //配列をクリア
                                for (int y = 0; y < L_scale_y + move_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x + move_x; x++)
                                    {
                                        light_mode[y, x] = 0;
                                    }
                                }
                                //街灯を再設定
                                for (int y = 0; y < L_scale_y; y++)
                                {
                                    for (int x = 0; x < L_scale_x; x++)
                                    {
                                        light_mode[y + count, x] = 1;
                                    }
                                }
                            }
                        }
                        transform.position = new Vector3(L_def_px, L_def_py + Preset * move_count, 0);
                    }
                }
                //マップに反映させる
                for (int y = 0; y < L_scale_y + move_y; y++)
                {
                    for (int x = 0; x < L_scale_x + move_x; x++)
                    {

                        Map.GetComponent<Map>().Rewrite_map(L_def_px + position_x + x, L_def_py + position_y + y, light_mode[y, x]);
                    }
                }
                Debug.Log(Map.GetComponent<Map>().Map_state(L_def_px, L_def_py));
            }
        }
    }
}
