using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class UserAuth : MonoBehaviour {

    private string currentPlayerName;

    //mobile backendに接続してログイン
    public void LogIn(string id,string pw)
    {
        NCMBUser.LogInAsync(id,pw,(NCMBException e) => {
            //接続成功したら
            if (e == null)
            {
                currentPlayerName = id;
            }
        });
    }

    //mobile backendに接続して新規会員登録
    public void SignUp(string id, string mail, string pw)
    {
        NCMBUser user = new NCMBUser();
        user.UserName = id;
        user.Email = mail;
        user.Password = pw;
        user.SignUpAsync((NCMBException e) =>
        {
            if (e == null)
            {
                currentPlayerName = id;
            }
        });
    }

    //mobile backendに接続してログアウト
    public void LogOut()
    {
        NCMBUser.LogOutAsync((NCMBException e) =>
        {
            if(e == null)
            {
                currentPlayerName = null;
            }
        }
        );
    }

    //現在のプレイヤーネームを返す1
    public string CurrentPlayer()
    {
        return currentPlayerName;
    }

    //シングルトン化する
    private UserAuth instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            string name = gameObject.name;
            gameObject.name = name + "(Singleton)";

            GameObject duplicater = GameObject.Find(name);
            if(duplicater != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.name = name;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
