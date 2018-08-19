using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static float score = 0;
    int timer;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer = Mathf.FloorToInt(score);

        if (timer % 10 == 0)
            CubeController.speed -= 0.1f;
        if(PlayerController.hitPoint!=0)
        score += Time.deltaTime;

        scoreText.GetComponent<Text>().text =
            string.Format("Score:"+"{0:0000}",score);

        
	}
}
