using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public bool intrigger = false;
    public int attackPoint = 20;
    private float timeAttackWorks = 0.2f; // how long sword can hit the enemy after key pressed
    private float time; // time attack should work
    public bool activeAttackArea = false; // use to specify whitch attackArea should by active
    public bool enemyInAttackArea = false; // true if Enemy is in attack Area
    private Collider2D enemy = null; //wsk whith enemy is in attack area

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D other) // enemy in attac area
    {
        if (other.tag == "Enemy")
        {
            enemyInAttackArea = true;
            enemy = other; // 
        }
        else
        {
            enemyInAttackArea = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) // enemy exit attack area
    {
       
        enemyInAttackArea = false;
       
    }

     // Update is called once per frame
    void Update()
    {
        if(activeAttackArea && enemyInAttackArea) // deals damage to enemy
        {
            enemy.gameObject.GetComponent<Enemy>().TakeHealthPoint(attackPoint);
            activeAttackArea = false;
        }
        if (activeAttackArea) // attack area is active for 0.2s
        {
            if (time == 0) time = timeAttackWorks;
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                activeAttackArea = false;
            }
        }
    }
}
