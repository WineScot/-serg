using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject player;

    //private bool canJump = true;
    private bool followHero = false;

    public float moveSpeed = 5;
    public float jumpHeight = 60;
    public float sight = 10;

    void Start()
    {
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

        if (dist.magnitude > 2*sight)
        {
            followHero = false;
            vel = new Vector2(0, 0);
        }
        if (base.gameObject.GetComponent<Enemy>().onAttack == false) // block movement during attack to let enemy /odskoczyć/ after hit
        {
            if (dist.magnitude < sight || followHero)
            {
                followHero = true;

                if (enemyPosition.x > playerPosition.x) vel.x = -moveSpeed;
                else vel.x = moveSpeed;
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
