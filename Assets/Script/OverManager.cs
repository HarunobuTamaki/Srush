using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverManager : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //スコア表示
        scoreText.GetComponent<Text>().text =
            string.Format("Score:" + "{0:0000}", GameManager.score);

        //ボタンが押されたらタイトル画面に遷移
        if (Input.GetButtonDown("Jump"))
            SceneManager.LoadScene("TitleScene");

	}
}
