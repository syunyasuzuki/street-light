using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapchip : MonoBehaviour {

    //_ctrに継承させるスクリプト

    protected GameObject Map;

	// Use this for initialization
	void Start () {
        Map = GameObject.Find("MapManager");
	}
	
}
