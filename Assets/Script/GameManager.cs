using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    float timer=-6; //カウントダウン用にマイナスからスタート
    public static int score; //スコア(別シーンで表示するためstaticで宣言)
    public Text scoreText; //スコア表示用テキスト
    public Text countText; //カウントダウン用テキスト
    public Camera startCamera; //カウントダウン時カメラ
    public Camera startCamera2;//   〃    
    public Camera startCamera3;//   〃
    public Camera effectCamera;//場面転換用カメラ
    public GameObject effect;//マスクアニメーション
    public GameObject convert;//場面転換用マスク

    // Use this for initialization
    void Start () {
        score = 0; //スコアの初期値
        StartCoroutine("CountDown"); //カウントダウン演出
    }
	
	// Update is called once per frame
	void Update () {
        //体力がなくなるとスコアの加算を止める
        if (PlayerController.hitPoint != 0)
            timer += Time.deltaTime;

        //整数値で受け取りたいので切り捨てでタイマーの値を受け取る
        if(timer>0)
            score = Mathf.FloorToInt(timer);

        //体力がが0になった場合に画面遷移コルーチンを呼び出す
        if (PlayerController.hitPoint == 0)
            StartCoroutine("OverScene");

        //スコアを4桁で表示する
        scoreText.GetComponent<Text>().text =
            string.Format("Score:"+"{0:0000}",score);
        
	}

    IEnumerator OverScene()
    {
        //2秒待った後にシーン遷移(倒れるアニメーションが2秒の為)
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("OverScene");

    }

    IEnumerator CountDown()
    {
        for(int i = 6; i >= 0; i--)
        {
            //1秒ごとに処理する
            switch (i)
            {
                case 6:
                    //空白文字を代入
                    countText.GetComponent<Text>().text =
                        " ";
                    break;
                case 3:
                    countText.GetComponent<Text>().text =
                        "3";
                    //カメラ切替と転換用オブジェクト破棄
                    startCamera.enabled = true;
                    effectCamera.enabled = false;
                    Destroy(convert);
                    Destroy(effect);
                    Destroy(effectCamera);
                    break;
                case 2:
                    countText.GetComponent<Text>().text =
                        "2";
                    //カメラ切替
                    startCamera.enabled = false;
                    startCamera2.enabled = true;
                    break;
                case 1:
                    countText.GetComponent<Text>().text =
                        "1";
                    //カメラ切替
                    startCamera2.enabled = false;
                    startCamera3.enabled = true;
                    break;
                case 0:
                    countText.GetComponent<Text>().text =
                        "Start!";
                    startCamera3.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(1.0f);
            
        }
        //テキスト非表示
        countText.enabled = false;
    }
    
}
