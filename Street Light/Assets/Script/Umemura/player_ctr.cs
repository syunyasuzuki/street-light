using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_ctr : MonoBehaviour {
    
    [SerializeField] Vector3 SPEED = new Vector3(0.05f, 0.05f);  // プレイヤーの速度調整

    Vector3 pos;
    GameObject Map;

	// Use this for initialization
	void Start () {

        Map = GameObject.Find("MapManager");
        //transform.position = Vector3.zero;

    }
	
	// Update is called once per frame
	void Update () {
        // ゲームオーバー処理
        if (Map.GetComponent<Map>().P_checker(transform.position.x, transform.position.y) == 1)
        {
            SceneManager.LoadScene("GameOverScene");
        }


        Move();  // 移動処理
		
	}

    void Move()
    {

        // 現在位置をpositionに代入
        Vector3 Position = transform.position;

        if (Input.GetKey("w"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.y += SPEED.y;

            float z = 0;                                           // wを押すと前を向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);   // 進む向きを変える

        }
        else if (Input.GetKey("s"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.y -= SPEED.y;

            float z = 180;                                         // sを押すと後ろを向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);   // 進む向きを変える

        }else if (Input.GetKey("a"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.x -= SPEED.x;

            float z = 90;                                          // aを押すと左を向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);   // 進む向きを変える

        }
        else if (Input.GetKey("d"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.x += SPEED.x;

            float z = -90;                                        // dを押したら右を向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);  // 進む向きを変える
        }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "House")
        {
            SceneManager.LoadScene("GameClearScene");
        }
        if (col.gameObject.tag == ("switch"))
        {
            col.GetComponent<Power_ctr>().Switch_onoff();
        }
    }
}
