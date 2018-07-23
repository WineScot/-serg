using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttack : MonoBehaviour {


    public int attackPoint = 100;
    public int tailAttackPoint = 300;

    public bool warningAttack = false; // true after base scorpion attack - activats tail attack

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = true; // odwołanie do zmiennej skryptu rodica obiektu do którego przypisany jest ten skrypt
            if (warningAttack && base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea)
            {
                other.gameObject.GetComponent<Player>().TakeHealthPoint(tailAttackPoint);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftTailAttack");
                    other.gameObject.GetComponent<PlayerController>().WhileStrongAttack(500,30);
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightTailAttack");
                    other.gameObject.GetComponent<PlayerController>().WhileStrongAttack(-500,30);
                }
            }
            else
            {
                other.gameObject.GetComponent<Player>().TakeHealthPoint(attackPoint);
                if (base.transform.parent.gameObject.GetComponent<EnemyDetection>().OnLeft)
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionLeftAttack");
                }
                else
                {
                    base.transform.parent.gameObject.GetComponent<Enemy>().PlayAnim("ScorpionRightAttack");
                }
                Invoke("SetWarningAttack", 0.4f);
            }
            
        }
        else
        {
            base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
            warningAttack = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        base.transform.parent.gameObject.GetComponent<Enemy>().heroInAttackArea = false;
        warningAttack = false;
    }

    public void SetWarningAttack()
    {
        warningAttack = true;
    }

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
