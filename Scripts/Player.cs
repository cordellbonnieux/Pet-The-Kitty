using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 5;
    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * x * Time.deltaTime * speed);

        // Check if player is on ground
        // set onGround

        if (onGround)
        {
            transform.Translate(Vector2.up * z * Time.deltaTime * speed);
        }
        else
        {
            // crouch?
        }
    }
}
