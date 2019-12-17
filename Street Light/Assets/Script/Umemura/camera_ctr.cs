using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ctr : MonoBehaviour {

    [SerializeField]GameObject player;　// プレイヤーオブジェクトを取得

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        // プレイヤーの座標を取得
        Vector3 playerPos = this.player.transform.position;

        // y座標だけプレイヤーを追従
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
		
	}
}
