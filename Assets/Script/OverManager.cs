using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverManager : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.GetComponent<Text>().text =
            string.Format("Score:" + "{0:0000}", GameManager.score);
	}
}
