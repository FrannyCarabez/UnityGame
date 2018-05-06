using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float jumpPower = 10.0f;
    Rigidbody2D myrigidbody;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
        myrigidbody = transform.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myrigidbody.AddForce(Vector3.up * (jumpPower * myrigidbody.mass * myrigidbody.gravityScale * 20.0f));
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }

    }
}
