using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpForce;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask Ground;

    public float timer;
    public bool isHit;
    public float hitTime;

    public bool moving;
    public float speed;
    public float distance;
    private float startingpostion;

    public Animator anim;

    private Collider2D myCollider;

    public Color opacityColor;
    public float opacityRange = 127.5f;
    public bool forwardMoving;
    public float maxXPosition;

    public bool isHitMushroom;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        anim = transform.GetChild(0).GetComponent<Animator>();

        opacityColor = GetComponentInChildren<SpriteRenderer>().color;


	}
	
	// Update is called once per frame
	void Update () {

        if(isHit){
            timer+=Time.deltaTime;
            opacityColor.a = opacityRange;
        if(timer>=hitTime){
            isHit = false;
            timer = 0;
            }
        }
        
        grounded = Physics2D.IsTouchingLayers(myCollider, Ground);

        if(Input.GetKeyDown(KeyCode.Space)  )
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }

        if(!grounded){
           anim.Play("Jump");
        }
        else{
                anim.Play("Run");
        }

        if(moving){
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,transform.position.y);
            if(startingpostion - transform.position.x >= distance){
                transform.position = new Vector2(startingpostion - distance,transform.position.y);
            moving = false;
            }
        }

        if(forwardMoving){
            if (maxXPosition > transform.position.x){
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,transform.position.y);
            if(startingpostion + transform.position.x >= distance){
                transform.position = new Vector2(startingpostion + distance,transform.position.y);
            forwardMoving = false;
            }
            } else {
                forwardMoving = false;
            }
        }
        
       
	}


    void OnTriggerEnter2D(Collider2D obstacleHit){
        if(obstacleHit.gameObject.tag == "ObstacleTrigger" && !isHit && !isHitMushroom){
            isHit = true;
            print("hit");
            obstacleHit.enabled = false;
            moving = true;
            startingpostion = transform.position.x;
        }
        if(obstacleHit.gameObject.tag == "Mushroom"){
            forwardMoving = true;
        }


    }
}
