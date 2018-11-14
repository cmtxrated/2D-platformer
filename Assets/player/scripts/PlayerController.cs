using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isJumping = false;
    public Transform groundCheck;

    private bool facingRight = true;
    public bool grounded;


    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        grounded = false;
        isJumping = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();

        }
       
    }


  
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }
}
