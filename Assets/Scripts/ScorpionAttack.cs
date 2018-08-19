using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttack : MonoBehaviour {


    public float attackPoint = 1f;
    public float tailAttackPoint = 10f;
    private GameObject player;
    public bool attackTime = true;

    public int warningAttack = 0; // true after 2x base scorpion attack - activats tail attack

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = true;
        }
        else
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
            warningAttack = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = true;
        }
        else
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
            warningAttack = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
        warningAttack = 0;
    }

    public void NowYouCanAttack()
    {
        attackTime = true;
    }

    public void NowTakeHealthPoint()//take health point currently tail attack
    {
        player.gameObject.GetComponent<Player>().TakeHealthPoint(tailAttackPoint/2);
        if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
        {
            player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(-30, 60);
        }
        else
        {
            player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(30, 60);
        }
    }

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea != true)
        {
            warningAttack = 0;
        }
        if (base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea && attackTime)
        {
            if (warningAttack < 2) // 2x warning attacks
            {
                player.gameObject.GetComponent<Player>().TakeHealthPoint(attackPoint/2);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftAttack");
                    attackTime = false;
                    Invoke("NowYouCanAttack", 0.6f);
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightAttack");
                    attackTime = false;
                    Invoke("NowYouCanAttack", 0.6f);
                }
                warningAttack++;
            }
            else //after 2 warning attacks succeed tail attack
            {
                Invoke("NowTakeHealthPoint", 0.5f);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftTailAttack");
                    attackTime = false;
                    Invoke("NowYouCanAttack", 1.4f);
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightTailAttack");
                    attackTime = false;
                    Invoke("NowYouCanAttack", 1.4f);
                }
                warningAttack = 0;
            }
        }
    }
}
