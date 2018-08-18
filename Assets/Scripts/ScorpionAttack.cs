using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttack : MonoBehaviour {


    public float attackPoint = 0.5f;
    public float tailAttackPoint = 1f;
    private GameObject player;
    public bool attackTime = true;

    public int warningAttack = 0; // true after 2x base scorpion attack - activats tail attack

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

    public void NowTakeHealthPoint()
    {
        player.gameObject.GetComponent<Player>().TakeHealthPoint(1);
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
            if (warningAttack < 2)
            {
                player.gameObject.GetComponent<Player>().TakeHealthPoint(attackPoint);
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
            else
            {
                Invoke("NowTakeHealthPoint", 0.5f);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftTailAttack");
                    attackTime = false;
                    Invoke("NowYouCanAttack", 1.4f);
                    //player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(0, 0);
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightTailAttack");
                    attackTime = false;
                    Invoke("NowYouCanAttack", 1.4f);
                    //player.gameObject.GetComponent<PlayerController>().WhileStrongAttack(0, 0);
                }
                warningAttack = 0;
            }
        }
    }
}
