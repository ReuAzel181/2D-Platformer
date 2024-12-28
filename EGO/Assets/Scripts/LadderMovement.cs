using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 5f; // Adjust the speed for climbing
    private bool isLadder;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            animator.SetBool("isClimbing", true); // Set the isClimbing parameter in the Animator to true
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            rb.gravityScale = 0f; // Disable gravity while climbing
        }
        else
        {
            animator.SetBool("isClimbing", false); // Set the isClimbing parameter in the Animator to false
            rb.gravityScale = 1f; // Enable gravity when not climbing
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            animator.SetBool("isClimbing", false); // Set the isClimbing parameter in the Animator to false
            rb.gravityScale = 1f; // Ensure gravity is enabled when leaving the ladder
        }
    }
}
