using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttack : MonoBehaviour {


    private float attackPoint = 1f;
    private float tailAttackPoint = 10f;
    private GameObject player;
    private SpriteRenderer spre;
    private bool attackTime = true;

    private int warningAttack = 0; // true after 2x base scorpion attack - activats tail attack

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spre = base.transform.parent.gameObject.GetComponent<Enemy>().spre;
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = true;
            base.transform.parent.gameObject.GetComponent<Enemy>().onAttack = true;
        }
        else
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
            base.transform.parent.gameObject.GetComponent<Enemy>().onAttack = false;
            warningAttack = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = true;
            base.transform.parent.gameObject.GetComponent<Enemy>().onAttack = true;
        }
        else
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
            base.transform.parent.gameObject.GetComponent<Enemy>().onAttack = false;
            warningAttack = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
        base.transform.parent.gameObject.GetComponent<Enemy>().onAttack = false;
        warningAttack = 0;
    }*/

    public void NowYouCanAttack()
    {
        attackTime = true;
    }


    public void TailAttack()
    {
        
        player.gameObject.GetComponent<Player>().TakeHealthPoint(tailAttackPoint / 2);
        if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
        {
            player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(-30, 60);
        }
        else
        {
            player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(30, 60);
        }
        
    }

    


    // Update is called once per frame
    void FixedUpdate ()
    {
        if (base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea && attackTime)
        {
            attackTime = false;
            if (warningAttack < 2) // 2x warning attacks
            {
                player.gameObject.GetComponent<Player>().TakeHealthPoint(attackPoint / 2);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftAttack");
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightAttack");  
                }
                Invoke("NowYouCanAttack", 0.6f);
                warningAttack++;
            }
            else //after 2 warning attacks succeed tail attack
            {
                Invoke("TailAttack", 0.5f);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftTailAttack");
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightTailAttack"); 
                }
                warningAttack = 0;  
                Invoke("NowYouCanAttack", 1.4f);
                
            }
        }
    }
}
