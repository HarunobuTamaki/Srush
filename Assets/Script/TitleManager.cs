using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    bool leaderBoardButton;
    bool commentButton;
    bool logOutButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
            SceneManager.LoadScene("MainScene");
            
	}

    private void OnGUI()
    {
        DrawButton();
        //ログアウトボタンが押されたら
        if (logOutButton)
            FindObjectOfType<UserAuth>().LogOut();
        //ランキングボタンが押されたら
        if (leaderBoardButton)
            SceneManager.LoadScene("LeaderBoard");

        //ログアウト完了してたらログインメニューに戻る
        if (FindObjectOfType<UserAuth>().CurrentPlayer() == null)
        {
            SceneManager.LoadScene("LogIn");
        }
    }

    private void DrawButton()
    {
        //ボタンの設置
        int btnW = 140, btnH = 50;
        GUI.skin.button.fontSize = 18;
        leaderBoardButton = GUI.Button(new Rect(0 * btnW, 0, btnW, btnH), "LeaderBoard");
        commentButton = GUI.Button(new Rect(1* btnW, 0, btnW, btnH), "Comment");
        logOutButton = GUI.Button(new Rect(2 * btnW, 0, btnW, btnH), "LogOut");
    }
}
