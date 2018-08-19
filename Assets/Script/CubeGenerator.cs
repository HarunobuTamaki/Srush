using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    float timer = 3; //生成間隔

    public GameObject cube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 3;
            Instantiate(cube, new Vector3(10, Random.Range(-1.2f, 0), 6),Quaternion.identity);
        }

        
	}
}
