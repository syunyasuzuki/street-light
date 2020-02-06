using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClearManager : Button_ctr
{
    public static bool Clear_check;

    public GameObject player;
    public GameObject panel;
    public Image Clear_Logo;
    public Image Clear_menu;
    public Image Next;
    public Image Select;
    public Image Retry;

    [SerializeField] Button List1;
    [SerializeField] Button List2;
    [SerializeField] Button List3;

    float alpha;
    float Y = 4.0f;

	// Use this for initialization
	void Start ()
    {
        alpha = 0.0f;
        Clear_menu.rectTransform.localPosition = new Vector3(-30.0f, -500.0f, 0.0f);
        Next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        Select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        Retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        panel.SetActive(false);
        Clear_check = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Clear_check = true;
        }
        if (Clear_check == true)
        {
            GameClear();
        }
    }

    public void GameClear()
    {
        panel.SetActive(true);
        player.GetComponent<player_ctr>().enabled = false;
        List1.Select();
        Invoke("GameClear2", 1.0f);
    }

    public void GameClear2()
    {
        if (Clear_Logo.rectTransform.localPosition.y <= 130)
        {
            Clear_Logo.rectTransform.localPosition += new Vector3(0.0f, Y, 0.0f);
        }
        else
        {
            Clear_menu.rectTransform.localPosition = new Vector3(-30.0f, -20.0f, 0.0f);
            alpha += 0.05f;
            Next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            if (alpha >= 1.0f)
            {
                Clear_check = false;
            }
        }
    }
}
