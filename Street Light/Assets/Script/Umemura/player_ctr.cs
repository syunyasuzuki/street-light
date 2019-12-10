using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class player_ctr : MonoBehaviour {

    [SerializeField] Vector3 SPEED = new Vector3(0.05f, 0.05f);  // プレイヤーの速度調整

    //public GameObject player;
    float alpha = 1.0f;
    int count;
    Vector3 pos;
    GameObject Map;
    bool q=true;
	// Use this for initialization
	void Start () {
        //getcolor = GetComponent<SpriteRenderer>().color;

        Map = GameObject.Find("MapManager");

    }
	
	// Update is called once per frame
	void Update () {
        // ゲームオーバー処理
        if (Map.GetComponent<Map>().P_checker(transform.position.x, transform.position.y) == 1)
        {

            Invoke("GameOver", 2.0f);
            gameObject.SetActive(false);
            q = false;
        //    alpha -= 0.05f;
        //    player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        //    if (alpha <= 0.0f)
        //    {
        //        transform.position = Vector3.zero;
        //    }
        }

        if (q)
        {
            Move();  // 移動処理
        }
    }

        void GameOver()
        {
            transform.position = Vector3.zero;
            gameObject.SetActive(true);
            q = true;
        }

        void Move()
    {
        // 現在位置をpositionに代入
        Vector3 Position = transform.position;

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey("w"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.y += SPEED.y;

            float z = 0;                                           // wを押すと前を向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);   // 進む向きを変える

        }
        else if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey("s"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.y -= SPEED.y;

            float z = 180;                                         // sを押すと後ろを向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);   // 進む向きを変える

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {

            // 代入したPositionに対して加算減算を行う
            Position.x -= SPEED.x;

            float z = 90;                                          // aを押すと左を向く
            this.transform.rotation = Quaternion.Euler(0, 0, z);   // 進む向きを変える

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
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

    public int death()
    {
        return count;
    }

    void FixedUpdate()
    {
        //Rigidbody2D rigid2D = this.GetComponent<Rigidbody2D>();
        //Vector3 force = new Vector3(0.0f, 1.0f, 0.0f);
        //rigid2D.AddForce(force);
    }
}
