using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform onGroundChecker;
    public LayerMask groundLayer;
    public float checkGroundRadius;
    public int speed = 5;
    public float jumpForce = 2;
    private bool onGround = false;
    private Rigidbody2D rb;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;
    private float rememberGroundedFor;
    private float lastTimeGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Run();
        Jump();
        BetterJump();
    }

    void GroundCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(onGroundChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            onGround = true;
        }
        else
        {
            if (onGround)
            {
                lastTimeGrounded = Time.time;
            }
            onGround = false;
        }
    }
    void Run()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (onGround && (Input.GetAxis("Jump") > 0 || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /**
    * credit for most of this method goes to:
    * https://craftgames.co/unity-2d-platformer-movement/#Testing_movement
    */
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier -1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && (Input.GetAxis("Jump") <= 0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
