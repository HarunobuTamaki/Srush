using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpSpeed = 20.0f;
    public float gravity = 5.0f;
    private Vector3 moveDirection = Vector3.zero;

    public static int hitPoint;
    int maxHitPoint = 3;

    // Use this for initialization
    void Start () {

        hitPoint = maxHitPoint;
    }
	
	// Update is called once per frame
	void Update () {


        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        hitPoint = Mathf.Clamp(hitPoint, 0, maxHitPoint);
        Debug.Log(hitPoint);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
            hitPoint -= 1;
    }


}
