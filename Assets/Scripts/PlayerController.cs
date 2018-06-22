using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb2d.AddForce(movement);*/
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 movement = new Vector2(0,80000);
            rb2d.AddForce(movement);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 movement = new Vector2(0, -10000);
            rb2d.AddForce(movement);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 movement = new Vector2(10000, 0);
            rb2d.AddForce(movement);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 movement = new Vector2(-10000, 0);
            rb2d.AddForce(movement);
        }
       
    }
}