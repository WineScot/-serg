using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private GameObject swordul;
    private GameObject swordur;
    private GameObject swordml;
    private GameObject swordmr;
    private GameObject sworddl;
    private GameObject sworddr;
    private GameObject hand;
    private Animator anim;
    public bool onAttack = false;

    bool GetDirectionRight() // dircetionRight from PlayerController script
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().directionRight;
    }

    // Use this for initialization
    void Start ()
    {
        swordul = GameObject.FindGameObjectWithTag("Sword UL");
        swordur = GameObject.FindGameObjectWithTag("Sword UR");
        swordml = GameObject.FindGameObjectWithTag("Sword ML");
        swordmr = GameObject.FindGameObjectWithTag("Sword MR");
        sworddl = GameObject.FindGameObjectWithTag("Sword DL");
        sworddr = GameObject.FindGameObjectWithTag("Sword DR");
        hand = GameObject.FindGameObjectWithTag("Hand");
        anim = hand.GetComponent<Animator>();
    }

    void FinishAttack()
    {
        onAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onAttack==false)
        {
            if (Input.GetKeyDown(KeyCode.A)) // attack in one direction
            {
                if (GetDirectionRight())
                {

                    swordur.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;

                }
                else
                {
                    swordul.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;

                }
                onAttack = true;
                Invoke("FinishAttack", 0.5f);

            }
            if (Input.GetKeyDown(KeyCode.S)) // attack in one direction
            {
                if (GetDirectionRight())
                {

                    swordmr.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
                    anim.SetTrigger("playerRightAttack");
                }
                else
                {
                    swordml.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
                    anim.SetTrigger("playerLeftAttack");
                }
                onAttack = true;
                Invoke("FinishAttack", 0.5f);

            }
            if (Input.GetKeyDown(KeyCode.D)) // attack in one direction
            {
                if (GetDirectionRight())
                {

                    sworddr.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;

                }
                else
                {
                    sworddl.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;

                }
                onAttack = true;
                Invoke("FinishAttack", 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.W)) // attack around hero
            {
                swordml.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
                swordmr.gameObject.GetComponent<WeaponAttack>().activeAttackArea = true;
                onAttack = true;
                Invoke("FinishAttack", 0.5f);
            }
        }
    }
}
