using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    
    public static float speed = -3.0f; //飛んでくるスピード

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //xの移動量にspeedを代入
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //スコアが10になるごとにスピードを足していく
        if (GameManager.score % 10 == 0 && GameManager.score != 0)
        {
            StartCoroutine("SpeedPlus");
            Debug.Log("speed" + speed);
        }

        //画面外に消えた時とPlayerの体力が0の時に破棄する
        if (transform.position.x < -15 || PlayerController.hitPoint ==0)
        {
            Destroy(gameObject);
        }
        
	}
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            //Playerに当たったら当たったら破棄
            Destroy(gameObject);
        }
    }

    IEnumerator SpeedPlus()
    {
        //念のため1秒待つ
        yield return new WaitForSeconds(1.0f);
        speed -= 0.01f;
    }
}
