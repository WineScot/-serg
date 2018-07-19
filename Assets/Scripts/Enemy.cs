using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rb2d;
    private GameObject player;

    public int healthLevel = 100;
    public bool onAttack = false; // true - when Enemy is attacking

    //private int maxhealthLevel = 1000;
    //private int magicLevel = 1000;
    //private int baseAttack = 40;
    private int armorLevel = 0;
    //private int cureQuick = 10;
    
    

    // Use this for initialization
	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    public void TakeHealthPoint(int attackPoints) // this function take hero health point
    {
        
        attackPoints -= armorLevel;
        if (attackPoints > 0)
        {
            healthLevel -= attackPoints;
        }
        if (healthLevel <= 0)
        {
            Destroy(gameObject);
        }
        onAttack = true; // onAttack block motion in EnemyDetection
        Vector2 movement;
        Vector2 playerPosition = player.transform.position;
        Vector2 enemyPosition = GetComponent<Rigidbody2D>().position;
        if (enemyPosition.x > playerPosition.x)
        {
            movement = new Vector2(50, 30);
        }
        else
        {
            movement = new Vector2(-50, 30);
        }
        rb2d.velocity = movement;
        Invoke("OnAttackFalse", 1); // evokes function after 2 seconds
    }

    public void OnAttackFalse() // unlock motion in EnemyDetection
    {
        onAttack = false;
    }


	
	
	// Update is called once per frame
	void Update () {
		
	}
}
