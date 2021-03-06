﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//THIS CLASS IS HEAVILY MODIFIED CODE FROM https://sharpcoderblog.com/blog/2d-platformer-character-controller
//I DIDN'T MAKE ALL OF THIS, BUT I DID MAKE MOST OF IT.
public class playerMovement : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Animator playerAnimator;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Rigidbody2D r2d;
    public BoxCollider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;
    }

    // Update is called once per frame

    void Update()
    {
        //check for weapon
        if (Input.GetKey(KeyCode.Alpha1))
        {
            playerAnimator.SetInteger("activeState", 0);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            playerAnimator.SetInteger("activeState", 1);
        }

        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveDirection = Input.GetAxis("Horizontal");
            if (!isGrounded)
            {
                if (moveDirection >= 0)
                {
                    moveDirection -= .2f;
                }
                else
                {
                    moveDirection += .2f;
                }
            }
           
            
        }
        else //skid - a moment of slow movement made to make movement feel more natural
        {
            if (moveDirection <= .1 && moveDirection >= -.1)
            {
                moveDirection = 0;
            }

            else if (isGrounded)
            {
                if(moveDirection >= 0)
                {
                    moveDirection -= .02f;
                }
                else
                {
                    moveDirection += .02f;
                }
                
            }
            
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight && isGrounded)
            {
                facingRight = true;
                transform.Rotate(0f, 180f, 0f);
                //t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight && isGrounded)
            {
                facingRight = false;
                transform.Rotate(0f, 180f, 0f);
                //t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 1f, 0.1f, 0);

        Vector3 groundCheckPos2 = colliderBounds.min + new Vector3(0, 0, 0);

        if (Physics2D.Raycast(groundCheckPos2, Vector2.down, .23f, layerMask) || Physics2D.Raycast(groundCheckPos, Vector2.down, 0.23f, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //output infor to animator
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(moveDirection));
        playerAnimator.SetBool("isOnGround", isGrounded);
        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);
    }
}