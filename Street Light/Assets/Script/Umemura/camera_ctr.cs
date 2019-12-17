using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ctr : MonoBehaviour {

    GameObject player;　// プレイヤーオブジェクトを取得

	// Use this for initialization
	void Start () {

        this.player = GameObject.Find("Player");  // Hierarchy上の"Player"GameObjectを取得
		
	}
	
	// Update is called once per frame
	void Update () {

        // プレイヤーの座標を取得
        Vector2 playerPos = this.player.transform.position;

        // y座標だけプレイヤーを追従
        transform.position = new Vector2(transform.position.x, playerPos.y);
		
	}
}
