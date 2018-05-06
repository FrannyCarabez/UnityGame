using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // declaring the power of the jump
    public float jumpPower = 10.0f;

    // new rigidbody 
    Rigidbody2D myrigidbody;

    // isgrounded is false from the start, bool = false or true
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
        myrigidbody = transform.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // adding upward force which is multiplied with the jumpPower (10.f), mass of rigidbody and the gravityscale, 
            //(jumpPower, mass and gravityscale can be edited when you click the player and look in the rigidbody section) 
            myrigidbody.AddForce(Vector3.up * (jumpPower * myrigidbody.mass * myrigidbody.gravityScale * 20.0f));
        }
	}

    // when the player touches the ground, isGrounded is true
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    // when the player stays on the ground, isGrounded is true
    void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    // when the player jumps, isGrounded is false and he can't jump until he isGrounded
    void OnCollisionExit2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }

    }
}
