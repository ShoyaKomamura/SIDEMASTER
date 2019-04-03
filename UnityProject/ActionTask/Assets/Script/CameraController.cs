using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset; //プレイヤーとカメラ間のオフセット距離を格納する。

	// Use this for initialization
	void Start () {
       
        //プレイヤーとカメラ間の距離を取得してオフセット距離値を計算し格納する。
        offset = transform.position - player.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        //カメラのtransformの位置をプレイヤーのものと同じ設定にする。
        transform.position = player.transform.position + offset;
	}
}
