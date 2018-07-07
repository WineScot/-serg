using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModeChanging : MonoBehaviour {

    private WeaponController weaponController;
    public int mode; // attack mode, 1 - sword, 2 - spear
    public GameObject spearToInstantiate;

	void Start () {
        mode = 1; //initially player attacks with sword
        weaponController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
    }

    void DisablingMode()
    {
        if(mode == 1)
        {
            weaponController.enabled = false;
        }
        if(mode == 2)
        {
            GameObject spear = GameObject.FindGameObjectWithTag("Spear");
            if (spear != null && spear.transform.parent.tag == "Player") Destroy(spear);
        }
    }
	
    void EnablingMode(int enablingMode)
    {
        DisablingMode();
        mode = enablingMode;
        if(mode == 1)
        {
            weaponController.enabled = true;
        }
        if(mode == 2)
        {
            // in update function
        }
        
    }

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) EnablingMode(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EnablingMode(2);

        if (mode == 2) // It's needed to do this in update function, because spear is destroying when player take it
        {
            GameObject spear = GameObject.FindGameObjectWithTag("Spear");
            if (spear == null)
            {
                GameObject instance = Instantiate(spearToInstantiate, transform) as GameObject;
            }
        }
    }
}
