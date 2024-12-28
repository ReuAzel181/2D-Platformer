using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{

    // MOVE JUMP
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    
    private SpriteRenderer sprite;
    private float dirX = 0f;

    // DASH

    private bool canDash = true;
    private bool isDashing;

    bool isRight;
    bool isLeft;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private TrailRenderer tr;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = .2f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private AudioSource jumpSoundeffect;
    

    private enum movementState {idle, run, jump, falling, dash}
  
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }




    // Update is called once per frame
    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed , rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded() ){
            jumpSoundeffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.D) && canDash)
        {
            StartCoroutine(Dash());
            isDashing = true;
        }
        

        UpdateAnimation();
    }


    private void UpdateAnimation()
    {
        movementState state;

        if (isDashing)
        {
            state = movementState.dash;
        }
        else if (rb.velocity.y > .1f)
        {
            state = movementState.jump;
        }
        else if (dirX > 0f)
        {
            state = movementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = movementState.run;
            sprite.flipX = true;
        }
        else if (rb.velocity.y > .1f)
        {
            state = movementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }
        else
        {
            state = movementState.idle;
        }
        

        anim.SetInteger("state", (int)state);

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Temporarily enable continuous collision detection
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        // Dash logic
        float dashDirection = sprite.flipX ? -1f : 1f;
        rb.velocity = new Vector2(dashDirection * dashingPower, 0f);
        tr.emitting = true;

        yield return new WaitForSeconds(dashingTime);

        tr.emitting = false;
        rb.velocity = Vector2.zero;
        isDashing = false;

        rb.gravityScale = originalGravity;

        // Revert collision detection to discrete
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }



}