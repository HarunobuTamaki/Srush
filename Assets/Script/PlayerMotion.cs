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

        AnimatorStateInfo state = this.animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Damage"))
        {
            animator.SetBool("Hit", false);
            Debug.Log("False");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            animator.SetBool("Hit", true);
            Debug.Log("true");
        }
        
    }
}
