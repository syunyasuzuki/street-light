using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//●＝未完成部分あり

public class Map : MonoBehaviour {

    //------------------このスクリプトのみで使うもの--------------

    //一時的な入れ物
    int count = 0;

    //マップの大きさX（かならず3以上の奇数で！）
    private const int Mapsize_x = 11;
    //マップの大きさY（3以上ならなんでもOK）
    private const int Mapsize_y = 17;
    
    //マップ（0 = 暗闇）
    int[,] mainmap = new int[Mapsize_y, Mapsize_x];

    int map_position_x = 0; //座標から配列へ直す値X
    int[] map_position_y = new int [Mapsize_y];//座標から配列へ直す値Y

    //------------------------------------------------------------

    //------------------他から取り込むもの------------------------

    //各ゲームオブジェクトのプレハブを取り込む
    [SerializeField] [Header("使う光のプレハブ")] GameObject[] Light_Prfb = new GameObject[] { };
    [SerializeField] [Header("使う障害物のプレハブ")] GameObject[] Enemy_Prfb = new GameObject[] { };

    //------------------------------------------------------------

    //------------------他からアクセスできるもの------------------

    //マップの書き変え
    public void Rewrite_map(int px,int py,int num){
        Debug.Log("もらった値　X："+ px + "　Y："+ py + "　NUM："+ num + "　計算した値　mainmap y "+ map_position_y[py] + "　mainmap x "+ (px+map_position_x));
        if (px + map_position_x < Mapsize_x || map_position_y[py] >= Mapsize_y){
            mainmap[map_position_y[py], px + map_position_x] = num;
        }
        
    }

    //プレイヤーから座標をもらって光に当たってない場合1を返す
    public int P_checker(float x,float y){
        //マップでの位置番号を求める
        int Px = (int)Mathf.Round(x);//マップ番号X
        int Py = (int)Mathf.Round(y);//マップ番号Y

        //座標の正規化
        float sub_x = x - Px;//座標0に合わせたY
        float sub_y = y - Py;//座標0に合わせたX

        //正規化した座標から光に当たっているかどうかを求める
        switch (mainmap[map_position_y[Py], Px + map_position_x]) {
            //すべて光
            case 1:return 0;
            //右によっていく
            case 2:
                if (sub_x >= -0.4f) { return 0; }
                break;
            case 3:
                if (sub_x >= -0.3f) { return 0; }
                break;
            case 4:
                if (sub_x >= -0.2f) { return 0; }
                break;
            case 5:
                if (sub_x >= -0.1f) { return 0; }
                break;
            case 6:
                if (sub_x >= 0.0f) { return 0; }
                break;
            case 7:
                if (sub_x >= 0.1f) { return 0; }
                break;
            case 8:
                if (sub_x >= 0.2f) { return 0; }
                break;
            case 9:
                if (sub_x >= 0.3f) { return 0; }
                break;
            case 10:
                if (sub_x >= 0.4f) { return 0; }
                break;
            //左によっていく
            case 11:
                if (sub_x <= 0.4f) { return 0; }
                break;
            case 12:
                if (sub_x <= 0.3f) { return 0; }
                break;
            case 13:
                if (sub_x <= 0.2f) { return 0; }
                break;
            case 14:
                if (sub_x <= 0.1f) { return 0; }
                break;
            case 15:
                if (sub_x <= 0.0f) { return 0; }
                break;
            case 16:
                if (sub_x <= -0.1f) { return 0; }
                break;
            case 17:
                if (sub_x <= -0.2f) { return 0; }
                break;
            case 18:
                if (sub_x <= -0.3f) { return 0; }
                break;
            case 19:
                if (sub_x <= -0.4f) { return 0; }
                break;
            //上によっていく
            case 20:
                if (sub_y >= -0.4f) { return 0; }
                break;
            case 21:
                if (sub_y >= -0.3f) { return 0; }
                break;
            case 22:
                if (sub_y >= -0.2f) { return 0; }
                break;
            case 23:
                if (sub_y >= -0.1f) { return 0; }
                break;
            case 24:
                if (sub_y >= 0.0f) { return 0; }
                break;
            case 25:
                if (sub_y >= 0.1f) { return 0; }
                break;
            case 26:
                if (sub_y >= 0.2f) { return 0; }
                break;
            case 27:
                if (sub_y >= 0.3f) { return 0; }
                break;
            case 28:
                if (sub_y >= 0.4f) { return 0; }
                break;
            //下によっていく
            case 29:
                if (sub_y <= 0.4f) { return 0; }
                break;
            case 30:
                if (sub_y <= 0.3f) { return 0; }
                break;
            case 31:
                if (sub_y <= 0.2f) { return 0; }
                break;
            case 32:
                if (sub_y <= 0.1f) { return 0; }
                break;
            case 33:
                if (sub_y <= 0.0f) { return 0; }
                break;
            case 34:
                if (sub_y <= 0.1f) { return 0; }
                break;
            case 35:
                if (sub_y <= 0.2f) { return 0; }
                break;
            case 36:
                if (sub_y <= 0.3f) { return 0; }
                break;
            case 37:
                if (sub_y <= 0.4f) { return 0; }
                break;
        }
        return 1;
    }

    //-----------------------------------------------------------

	// Use this for initialization
	void Start () {

        //マップの大きさをもとに配置位置のプリセットを作る
        map_position_x = Mapsize_x / 2;
        for(int y = Mapsize_y -1 ; y >= 0; y--){
            map_position_y[y] = y;
        }

		//mainmapを0クリアする（すべて暗闇にする）
        for(int y = 0; y < Mapsize_y; y++){
            for(int x = 0; x < Mapsize_x; x++){
                mainmap[y, x] = 0;
            }
        }

        count = 0;
        //ライト、障害物を配置する
        foreach(GameObject go in Light_Prfb){
            count++;
            GameObject subgo = Instantiate(go) as GameObject;
            subgo.name = "Light" + count;
        }
        count = 0;
        foreach(GameObject go in Enemy_Prfb){
            count++;
            GameObject subgo = Instantiate(go) as GameObject;
            subgo.name = "Enemy" + count;
        }
	}
}
