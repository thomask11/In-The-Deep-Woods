using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpForce;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask Ground;

    private Collider2D myCollider;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, Ground);

        if(Input.GetKeyDown(KeyCode.Space)  )
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }
       
	}
}
