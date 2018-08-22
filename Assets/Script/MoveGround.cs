using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour {

    public float speed=-0.1f; //地面を動かすスピード
    float size = 12f; //地面のサイズ

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //地面をx方向に動かす
        transform.Translate(speed*Time.deltaTime, 0, 0);
        //もし地面が画面外に全部出た場合は反対側に設置する
        if (this.transform.position.x + size < 0)
        {
            this.transform.Translate(size * 2, 0, 0);
        }
	}
}
