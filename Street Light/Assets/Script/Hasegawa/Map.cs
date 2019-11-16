using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//●＝未完成部分あり

public class Map : MonoBehaviour {

    //------------------このスクリプトのみで使うもの--------------

    private const int Mapsize_x = 11;//マップの大きさX
    private const int Mapsize_y = 17;//マップの大きさY

    //●マップ（0 = 暗闇）
    int[,] mainmap = new int[Mapsize_y, Mapsize_x];

    //マップ番号の探索
    private int Map_number(){
        return 0;
    }

    //------------------------------------------------------------

    //------------------他から取り込むもの------------------------

    //各ゲームオブジェクトのプレハブを取り込む
    [SerializeField] GameObject Light_01;
    [SerializeField] GameObject Light_02;
    [SerializeField] GameObject Light_03;
    [SerializeField] GameObject Light_04;
    [SerializeField] GameObject Light_05;
    [SerializeField] GameObject Power_01;
    [SerializeField] GameObject Power_02;
    [SerializeField] GameObject Enemy_01;
    [SerializeField] GameObject Enemy_02;

    //------------------------------------------------------------

    //------------------他からアクセスできるもの------------------

    //マップの書き変えとマップ番号の再割り当て（座標番号X、座標番号Y、マップ番号）
    public int Rewrite_map(int px,int py,int num){
        return 0;
    }

    //●プレイヤーから座標をもらって光に当たってない場合1を返す
    public int P_checker(float x,float y){

        return 0;
    }

    //-----------------------------------------------------------

	// Use this for initialization
	void Start () {
		//mainmapを0クリアする（すべて暗闇にする）
        for(int y = 0; y < Mapsize_y; y++){
            for(int x = 0; x < Mapsize_x; x++){
                mainmap[y, x] = 0;
            }
        }

		//mainmapを元にマップを作成する
        for(int y = 0; y < Mapsize_y; y++){
            for(int x = 0; x < Mapsize_x; x++){

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
