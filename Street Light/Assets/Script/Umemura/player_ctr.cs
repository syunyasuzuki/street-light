using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ctr : MonoBehaviour {
    // 速度
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();  // 移動処理
		
	}

    void Move()
    {
        Vector2 Position = transform.position;  // 現在位置をpositionに代入
        if (Input.GetKey("w"))
        {
            Position.y += SPEED.y;              // 代入したPositionに対して加算減算を行う

            float z = 0;
            this.transform.rotation = Quaternion.Euler(0, 0, z);

        }
        else if (Input.GetKey("s"))
        {
            Position.y -= SPEED.y;              // 代入したPositionに対して加算減算を行う
            float z = 180;
            this.transform.rotation = Quaternion.Euler(0, 0, z);
        }else if (Input.GetKey("a"))
        {
            Position.x -= SPEED.x;

            float z = 90;
            this.transform.rotation = Quaternion.Euler(0, 0, z);
        }else if (Input.GetKey("d"))
        {
            Position.x += SPEED.x;

            float z = -90;
            this.transform.rotation = Quaternion.Euler(0, 0, z);
        }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }
}
