using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Odpowiada za poruszanie się Graczem
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool directionRight = false; // true if hero is turned in right direction

    private bool canJump = true;
    public float moveSpeed = 10;
    public float jumpHeight = 60;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

	// Jeśli gracz jest w powietrzu (nie koliduje z niczym) nie może skakać
    void OnTriggerExit2D(Collider2D other)
    {
        canJump = false;
    }
	    
	void OnTriggerStay2D(Collider2D other)
    {
        canJump = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            Vector2 movement = new Vector2(rb2d.velocity.x, jumpHeight);
            rb2d.velocity = movement;// powinniśmy użyć rb2d.AddForce(Vector2 force);(chyba)
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionRight = true;
            Vector2 movement = new Vector2(moveSpeed, rb2d.velocity.y);
            rb2d.velocity = movement;
            anim.SetTrigger("playerRightWalk");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionRight = false;
            Vector2 movement = new Vector2(-moveSpeed, rb2d.velocity.y);
            rb2d.velocity = movement;
            anim.SetTrigger("playerLeftWalk");
        }
		else
		{
			anim.SetTrigger("playerIdle");
			Debug.Log("playerIdle");
		}
    }
}