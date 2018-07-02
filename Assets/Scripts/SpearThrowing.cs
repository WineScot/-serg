using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowing : MonoBehaviour
{

    private Rigidbody2D rb2d; // Rigidbody of Spear
    private Collider2D collider; // Collider of Spear
    private bool isThrowing = false; // true when player is targetting
    private bool isFlying = false;
    private bool isLying = false;
    private float gravityScale; // variable for on and off the gravity for spear
    private int attackPoint = 40;

    public float scale = 1; // scaling velocity

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        gravityScale = rb2d.gravityScale;
        rb2d.gravityScale = 0; // when the spear appear, it's in player's hand, so gravity have to be off for spear
        collider.enabled = false;
        transform.position = transform.parent.position;
    }

    void Update()
    {
        if (isThrowing)
        {
            Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition); //getting mouse position
            Vector2 spearPosition = rb2d.gameObject.transform.position;
            Vector2 vel = spearPosition - mousePosition;

            float angle = Mathf.Atan2(vel.y, vel.x) - Mathf.PI / 4;
            angle *= Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle); // targetting

            if (Input.GetMouseButtonDown(0)) // when the player throw the spear
            {
                transform.parent = null;
                collider.enabled = true;
                rb2d.gravityScale = gravityScale; // gravity should be on
                rb2d.velocity = vel;
                rb2d.velocity *= scale;
                isThrowing = false;
                isFlying = true;
            }
        }
        else if (isFlying)
        {
            float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) - Mathf.PI / 4;
            angle *= Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle); // physics of flying spear
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            isThrowing = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFlying && collision.gameObject.tag != "Player")
        {
            isFlying = false;
            isLying = true;
            collision.transform.Translate(0.05f * -Vector2.right);
            transform.parent = collision.transform;
            Destroy(rb2d); //sticking to hitting object
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().TakeHealthPoint(attackPoint);
            }
        }
        if (isLying)
        {
            if (collision.gameObject.tag == "Player")
            { 
               Destroy(gameObject);
            }
        }
    }
}
