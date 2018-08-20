using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject player;

    //private bool canJump = true;
    private bool followHero = false;


    private float moveSpeed = 15;
    private float jumpHeight = 60;
    private float sight = 50;
    public bool OnLeft = true; // postac zwrucona w lewo
    public bool onAttack = false; // true - when Enemy is attacking

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 enemyPosition = GetComponent<Rigidbody2D>().position;
        Vector2 dist = playerPosition - enemyPosition;
        Vector2 vel = new Vector2(0, 0);
        vel.y = rb2d.velocity.y;

        if (enemyPosition.x > playerPosition.x) //enemy po prawej stronie bohatera
        {
            if(enemyPosition.x < playerPosition.x + 7.3f) //hero is in attack area
            {
                base.gameObject.GetComponent<Enemy>().heroInAttackArea = true;
                onAttack = true;
                anim.SetTrigger("EnemyStanding");
            }
            else // hero is out of attack area
            {
                base.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
                onAttack = false;
            }
        }
        else //enemy po lewej stronie bohatera
        {
            if (enemyPosition.x > playerPosition.x - 7.3f) //hero is in attack area
            {
                base.gameObject.GetComponent<Enemy>().heroInAttackArea = true;
                onAttack = true;
                anim.SetTrigger("EnemyStanding");
            }
            else // hero is out of attack area
            {
                base.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
                onAttack = false;
            }
        }
        if(enemyPosition.y < playerPosition.y-11f)
        {
            base.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
            onAttack = false;
        }
        if (dist.magnitude > 2*sight)
        {
            followHero = false;
            vel = new Vector2(0, 0);
        }
        if (onAttack == false) // block movement during attack to let enemy /odskoczyć/ after hit
        {
            if ((dist.magnitude < sight || followHero) && base.gameObject.GetComponent<Enemy>().heroInAttackArea == false)
            {
                followHero = true;

                if (enemyPosition.x > playerPosition.x )
                {
                    vel.x = -moveSpeed;
                    OnLeft = true;
                    anim.SetTrigger("EnemyLeftWalk");
                }
                else
                {
                    vel.x = moveSpeed;
                    OnLeft = false;
                    anim.SetTrigger("EnemyRightWalk");
                }
            }
            else
            {
                anim.SetTrigger("EnemyStanding");
            }
            rb2d.velocity = vel;
        }
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        canJump = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canJump = false;
    }*/

    public void ChangeVelocity(Vector2 tmp)
    {
        rb2d.velocity += tmp;
    }

}
