using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private GameObject sword1;
    private GameObject sword2;

    bool GetDirectionRight() // dircetionRight from PlayerController script
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().directionRight;
    }

    // Use this for initialization
    void Start ()
    {
        sword1 = GameObject.FindGameObjectWithTag("Sword1");
        sword2 = GameObject.FindGameObjectWithTag("Sword2");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A)) // attack in one direction
        {
            if (GetDirectionRight())
            {
                sword2.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
            }
            else
            {
                sword1.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.S)) // attack around hero
        {
            sword1.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
            sword2.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
        }
    }
}
