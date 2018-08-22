using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotion : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        // animator.SetBool("Jump", Input.GetButton("Jump"));

        //AnimatorStateInfo state = this.animator.GetCurrentAnimatorStateInfo(0);
        //if (state.IsName("Jump"))
        //{
        //    animator.SetBool("Jump", false);
        //    Debug.Log("False");
        //}

        //アニメーションの状態を取得
        AnimatorStateInfo state = this.animator.GetCurrentAnimatorStateInfo(0);
        //もし状態がDamageだったらfalseにする
        if (state.IsName("Damage"))
        {
            animator.SetBool("Damage", false);
            Debug.Log("False");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Cubeに当たりPlayerの体力がある場合はDamage状態
        if (collision.gameObject.tag == "Cube" && PlayerController.hitPoint >0)
        {
            animator.SetBool("Damage", true);
            Debug.Log("true");
        }
        //Cubeに当たり体力がない場合はEnd状態
        else if(collision.gameObject.tag == "Cube" && PlayerController.hitPoint == 0)
        {
            animator.SetBool("End", true);
            Debug.Log("true");
        }

    }


}
