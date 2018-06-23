using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;

    public float moveSpeed=10;
    public float jumpHeight=60;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 movement = new Vector2(rb2d.velocity.x, jumpHeight);
            rb2d.velocity = movement;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 movement = new Vector2(moveSpeed, rb2d.velocity.y);
            rb2d.velocity = movement;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 movement = new Vector2(-moveSpeed, rb2d.velocity.y);
            rb2d.velocity = movement;
        }
        
    }
}