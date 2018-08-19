﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject player;

    //private bool canJump = true;
    private bool followHero = false;


    public float moveSpeed = 15;
    public float jumpHeight = 60;
    public float sight = 50;
    public bool OnLeft = true; // postac zwrucona w lewo
    public bool Stop = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 enemyPosition = GetComponent<Rigidbody2D>().position;
        Vector2 dist = playerPosition - enemyPosition;
        Vector2 vel = new Vector2(0, 0);
        vel.y = rb2d.velocity.y;

        if(rb2d.velocity.x < 0.01f)
        {
            anim.SetTrigger("EnemyStanding");
            Stop = true;
        }
        else
        {
            Stop = false;
        }

        if (dist.magnitude > 2*sight)
        {
            followHero = false;
            vel = new Vector2(0, 0);
        }
        if (base.gameObject.GetComponent<Enemy>().onAttack == false) // block movement during attack to let enemy /odskoczyć/ after hit
        {
            if ((dist.magnitude < sight || followHero) && base.gameObject.GetComponent<Enemy>().heroInAttackArea == false)
            {
                followHero = true;

                if (enemyPosition.x > playerPosition.x + 5f)
                {
                    vel.x = -moveSpeed;
                    OnLeft = true;
                    anim.SetTrigger("EnemyLeftWalk");
                }
                if (enemyPosition.x < playerPosition.x - 5f)
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
