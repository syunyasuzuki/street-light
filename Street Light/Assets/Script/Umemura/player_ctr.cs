using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ctr : MonoBehaviour {
    
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);  // プレイヤーの速度調整

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();  // 移動処理
		
	}

    void Move()
    {

        // 現在位置をpositionに代入
        Vector2 Position = transform.position;

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
}
