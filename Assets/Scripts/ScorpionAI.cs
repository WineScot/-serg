using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAI : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject player;

    //private bool canJump = true;
    private bool followHero = false;


    private float moveSpeed = 15;
    private float jumpHeight = 60;
    private float sight = 50;
    private float attackPoint = 1f;
    private float tailAttackPoint = 10f;
    private bool attackTime = true;
    private bool heroInAttackArea = false; // true when hero is close to us
    public bool OnLeft = true; // postac zwrucona w lewo
    public bool onAttack = false; // true - when Enemy is attacking
    public int warningAttack = 0; // true after 2x base scorpion attack - activats tail attack

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void NowYouCanAttack()
    {
        attackTime = true;
    }

    public void TailAttack()
    {
        if (onAttack)
        {
            player.gameObject.GetComponent<Player>().TakeHealthPoint(tailAttackPoint);
            if (OnLeft)
            {
                player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(-30, 60);
            }
            else
            {
                player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(30, 60);
            }
        }

    }

    private void FixedUpdate()
    {
        /*THIS BLOCK OF CODE PREPAR VERIABLES*/

        Vector2 playerPosition = player.transform.position;
        Vector2 enemyPosition = GetComponent<Rigidbody2D>().position;
        Vector2 dist = playerPosition - enemyPosition;
        Vector2 vel = new Vector2(0, 0);
        vel.y = rb2d.velocity.y;

        /*THIS BLOCK OF CODE CHECK: IS HERO IN ATACK AREA*/

        if (enemyPosition.x > playerPosition.x) //enemy po prawej stronie bohatera
        {
            OnLeft = true;
            if (enemyPosition.x < playerPosition.x + 7.3f) //hero is in attack area
            {
                heroInAttackArea = true;
                onAttack = true;
                anim.SetTrigger("EnemyStanding");
            }
            else // hero is out of attack area
            {
                heroInAttackArea = false;
                warningAttack = 0;
                onAttack = false;
            }
        }
        else //enemy po lewej stronie bohatera
        {
            OnLeft = false;
            if (enemyPosition.x > playerPosition.x - 7.3f) //hero is in attack area
            {
                heroInAttackArea = true;
                onAttack = true;
                anim.SetTrigger("EnemyStanding");
            }
            else // hero is out of attack area
            {
               heroInAttackArea = false;
                warningAttack = 0;
                onAttack = false;
            }
        }
        if (enemyPosition.y < playerPosition.y - 11f)
        {
            heroInAttackArea = false;
            warningAttack = 0;
            onAttack = false;
        }


        /*THIS BLOC OF CODE DIRECTS US TO THE HERO*/

        if (dist.magnitude > 2 * sight)
        {
            followHero = false;
            vel = new Vector2(0, 0);
        }
        if (onAttack == false)
        {
            if ((dist.magnitude < sight || followHero) && heroInAttackArea == false)
            {
                followHero = true;

                if (enemyPosition.x > playerPosition.x)
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

        /*THIS BLOC OF CODE CONTROLE ENEMY ATTACK*/
        
        if (heroInAttackArea && attackTime)
        {
            attackTime = false;
            if (warningAttack < 2) // 2x warning attacks
            {
                player.gameObject.GetComponent<Player>().TakeHealthPoint(attackPoint);
                if (OnLeft)
                {
                    anim.SetTrigger("ScorpionLeftAttack");
                }
                else
                {
                    anim.SetTrigger("ScorpionRightAttack");
                }
                Invoke("NowYouCanAttack", 0.6f);
                warningAttack++;

            }
            else //after 2 warning attacks succeed tail attack
            {
                Invoke("TailAttack", 0.6f);
                if (OnLeft)
                {
                    anim.SetTrigger("ScorpionLeftTailAttack");
                }
                else
                {
                    anim.SetTrigger("ScorpionRightTailAttack");
                }
                warningAttack = 0;
                Invoke("NowYouCanAttack", 1.4f);

            }
        }

    }


    public void ChangeVelocity(Vector2 tmp)
    {
        rb2d.velocity += tmp;
    }

}
