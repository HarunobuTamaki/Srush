using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public static float speed = -3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (GameManager.score % 10 == 0 && GameManager.score != 0)
        {
            StartCoroutine("SpeedPlus");
            Debug.Log("speed" + speed);
        }

        if (transform.position.x < -15 || PlayerController.hitPoint ==0)
        {
            Destroy(gameObject);
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpeedPlus()
    {
        yield return new WaitForSeconds(1.0f);
        speed -= 0.01f;
    }
}
