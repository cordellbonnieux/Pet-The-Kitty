using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 5;
    public float jumpForce = 2;
    private bool onGround = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    void Run()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (onGround && Input.GetAxis("Jump") > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
