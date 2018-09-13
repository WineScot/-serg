using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float healthLevel = 100f;
    private float maxhealthLevel = 100f;
    //private int magicLevel = 1000;
    //private int baseAttack = 40;
    private float armorPoint = 0f;
    private float canHeal = 0.0f;

    public Texture2D healthTexture;
    private GameObject eqDisplay;



    /*void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, healthLevel * 100 / maxhealthLevel, 20), healthTexture);
    }*/


    public void TakeHealthPoint(float attackPoints) // this function takes hero health points
    {
        attackPoints -= armorPoint;
        if (attackPoints > 0)
        {            
			healthLevel -= attackPoints;
        }

        if (healthLevel <= 0)
        {
            //event when we die
        }
    }

    public void Cure(bool totally, int curyPoints) // this function cures hero
    {
        if (totally) // if we want cure hero totally
        {
            healthLevel = maxhealthLevel;
        }
        else // if we want cure hero incompletely
        {
            healthLevel += curyPoints;
            if (healthLevel > maxhealthLevel) healthLevel = maxhealthLevel;
        }
    }

    // Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame

	void Update () {

        

    }
    IEnumerator heal() //Odczekuje, aby przyrost hp fajniej wygladal
    {
        yield return new WaitForSeconds(0.5f);
    }

    
}
