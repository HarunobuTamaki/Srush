using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    float timer;
    public static int score;
    public Text scoreText;
    public Text countText;

	// Use this for initialization
	void Start () {
        score = 0;
        StartCoroutine("CountDown");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (PlayerController.hitPoint != 0)
            timer += Time.deltaTime;
        score = Mathf.FloorToInt(timer);

        if (PlayerController.hitPoint == 0)
            StartCoroutine("OverScene");

        scoreText.GetComponent<Text>().text =
            string.Format("Score:"+"{0:0000}",score);

        
	}

    IEnumerator OverScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("OverScene");

    }

    IEnumerator CountDown()
    {
        for(int i = 3; i >= 0; i--)
        {
            switch (i)
            {
                case 3:
                    countText.GetComponent<Text>().text =
                        "3";
                    break;
                case 2:
                    countText.GetComponent<Text>().text =
                        "2";
                    break;
                case 1:
                    countText.GetComponent<Text>().text =
                        "1";
                    break;
                case 0:
                    countText.GetComponent<Text>().text =
                        "Start!";
                        break;
            }
            yield return new WaitForSeconds(1.0f);
            
        }
        countText.enabled = false;
    }
    
}
