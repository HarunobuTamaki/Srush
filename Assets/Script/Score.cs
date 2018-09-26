using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    
    //ハイスコアを表示するText
    public Text highScoreText;
    
    //ハイスコア
    private NCMB.HighScore highScore;
    private bool isNewRecord;

	// Use this for initialization
	void Start () {
        Initialize();

        //ハイスコアを取得する。保存されてなければ0点。
        string name = FindObjectOfType<UserAuth>().CurrentPlayer();
        highScore = new NCMB.HighScore(0, name);
        highScore.Fetch();
	}
	
	// Update is called once per frame
	void Update () {
		//スコアがハイスコアより大きければ
        if(highScore.score < GameManager.score)
        {
            isNewRecord = true; //フラグを立てる
            highScore.score = GameManager.score;
        }
        
        highScoreText.GetComponent<Text>().text =
            "HighScore:" + highScore.score.ToString();
	}

    //ゲーム開始前の状態に戻す
    private void Initialize()
    {
        //フラグを初期化する
        isNewRecord = false;
    }

    //ハイスコアの保存
    public void Save()
    {
        //ハイスコアを保存する(ただし記録の更新があったときだけ)
        if (isNewRecord)
            highScore.Save();

        //ゲーム開始前の状態に戻す
        Initialize();
    }
}
