using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string horizontalAxis;
    public string jumpButton;
    public float moveSpeed = 10f;
    public float jumpPower = 16f;
    public bool isFacingRight = false;
    public bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis(horizontalAxis);

        // Flip sprite if needed
        if (horizontalInput < 0f && !isFacingRight || horizontalInput > 0f && isFacingRight)
        {
            FlipSprite();
        }

        // Check for jump input
        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Move the player horizontally
        float horizontalInput = Input.GetAxis(horizontalAxis);
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Update animator parameters
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        isGrounded = false;
        animator.SetBool("isJumping", true);
    }

    void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 ls = transform.localScale;
        ls.x *= -1f;
        transform.localScale = ls;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}