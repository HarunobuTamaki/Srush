using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    float timer = 3; //生成間隔

    public GameObject cube; //生成オブジェクト

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;

        //タイマーが0以下の時に生成する
        if (timer < 0 && GameManager.score>0 && PlayerController.hitPoint!=0)
        {
            timer = 3;
            Instantiate(cube, new Vector3(10, Random.Range(-1.2f, 0), 6),Quaternion.identity);
        }

        
	}
}
