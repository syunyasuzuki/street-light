using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class player_ctr : MonoBehaviour {

    [SerializeField] Vector3 SPEED = new Vector3(0.05f, 0.05f);  // プレイヤーの速度調整

    Animator anima;
    float alpha = 1.0f;
    int count;
    Vector3 pos;
    GameObject Map;
    bool q=true;
    bool i = false;
	// Use this for initialization
	void Start () {

        Map = GameObject.Find("MapManager");
        anima = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        // ゲームオーバー処理
        if (Map.GetComponent<Map>().P_checker(transform.position.x, transform.position.y) == 1)
        {
            if (q == true)
            {
                q = false;
            }
        }
        if (q == false)
        {
            alpha -= 0.02f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
            if (alpha <= 0.0f)
            {
                transform.position = Vector3.zero;
                alpha = 1.0f;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
                q = true;
            }
        }

        if (q)
        {
            Move();  // 移動処理
        }

    }
 
    void GameOver()
    {
        transform.position = Vector3.zero;
        q = true;
    }

    void Move()
    {
        // 現在位置をpositionに代入
        Vector3 Position = transform.position;

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey("w"))
        {
            anima.SetTrigger("front");
            // 代入したPositionに対して加算減算を行う
            Position.y += SPEED.y;

            float z = 0;                                           // wを押すと前を向く
            //this.transform.rotation = Quaternion.Euler(0, z, 0);   // 進む向きを変える

        }
        else if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey("s"))
        {
            anima.SetTrigger("back");
            // 代入したPositionに対して加算減算を行う
            Position.y -= SPEED.y;

            float z = 180;                                         // sを押すと後ろを向く
            //this.transform.rotation = Quaternion.Euler(0, z, 0);   // 進む向きを変える

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            anima.SetTrigger("right");
            // 代入したPositionに対して加算減算を行う
            Position.x -= SPEED.x;

            float z = 90;                                          // aを押すと左を向く
            //this.transform.rotation = Quaternion.Euler(z, 0, 0);   // 進む向きを変える

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            anima.SetTrigger("left");
            // 代入したPositionに対して加算減算を行う
            Position.x += SPEED.x;

            float z = -90;                                        // dを押したら右を向く
            //this.transform.rotation = Quaternion.Euler(z, 0, 0);  // 進む向きを変える
        }
        else
        { 
            anima.SetTrigger("wait");
        }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "House"&& i == true)
        {
            //Debug.Log("おうち入った");
            ClearManager.Clear_check = true;

        }
        if (col.gameObject.tag == ("switch"))
        {
            col.GetComponent<Power_ctr>().Switch_onoff();
        }
        if (col.gameObject.tag == ("key"))
        {
            i = true;
            Destroy(col.gameObject);
        }
    }

    public int death()
    {
        return count;
    }
}
