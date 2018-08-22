using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpSpeed = 20.0f; //ジャンプ速度
    public float gravity = 5.0f; //重力
    private Vector3 moveDirection = Vector3.zero;　//移動量ベクトル

    public static int hitPoint; //Playerの体力
    int maxHitPoint = 3; //体力の上限

    // Use this for initialization
    void Start () {
        //体力の初期値を設定
        hitPoint = maxHitPoint;
    }
	
	// Update is called once per frame
	void Update () {


        CharacterController controller = GetComponent<CharacterController>();
        //地面に足が着いていたら
        if (controller.isGrounded)
        {
            //ジャンプボタンを押した時にy方向に代入
            if (Input.GetButtonDown("Jump") && GameManager.score>0 &&hitPoint!=0)
            {
                moveDirection.y = jumpSpeed;
            }
        }
        //重力をかける
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //体力の上限、下限を設定する
        hitPoint = Mathf.Clamp(hitPoint, 0, maxHitPoint);
        Debug.Log(hitPoint);
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Cubeに当たった場合体力から1引く
        if (collision.gameObject.tag == "Cube")
            hitPoint -= 1;
    }


}
