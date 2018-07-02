using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public bool intrigger = false;
    private int attackPoint = 20;
    private float timeAttackWorks = 0.5f; // how long sword can hit the enemy after key pressed
    private float time; // time attack should work
    public bool activeAttackArea = false; // use to specify whitch attackArea should by active

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D other) // attack enemy
    {
        if (other.tag == "Enemy" && activeAttackArea == true)
        {
            other.gameObject.GetComponent<Enemy>().TakeHealthPoint(attackPoint);
        }
        activeAttackArea = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (activeAttackArea)
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
