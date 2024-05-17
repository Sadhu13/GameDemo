using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 15f;
    bool isFacingRight = false;
    float jumpPower = 16f;
    bool isGrounded = false;
    public GameObject winPanel;

    Rigidbody2D rb;
    Animator animator;
    public string horizontalAxis;
    public string jumpButton;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Use the defined input axis for horizontal movement
        horizontalInput = Input.GetAxis(horizontalAxis);

        FlipSprite();

        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);

        if(collision.tag == "Win")
        {
            winPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            winPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}