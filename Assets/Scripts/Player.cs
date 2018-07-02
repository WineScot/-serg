using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float healthLevel = 100f;
    private float maxhealthLevel = 100f;
    private int magicLevel = 1000;
    private int baseAttack = 40;
    private int armorLevel = 10;
    private float canHeal = 0.0f;

    public Texture2D healthTexture;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, healthLevel * 100 / maxhealthLevel, 20), healthTexture);

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
            //event when we die
        }
    }

    public void Cure(bool totally, int curyPoints) // this function cure hero
    {
        if (totally) // if we want cure hero totally
        {
            healthLevel = maxhealthLevel;
        }
        else // if we want cure hero incompletly
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

        if(Input.GetButtonDown("Fire1"))//Funkcja testowa, po wcisniecu "h" gracz zadaje sobie obrazenia (Kto wie dlaczego "h" ?) To pewnie z jakiejś gry co?
        {
            healthLevel -= 10;
            canHeal = 5.0f;
        }
        if(canHeal>0.0f)
        {
            canHeal -= Time.deltaTime; // canHeal to czas po którym gracz zostanie uleczony, jezeli nic go nie trafi
        }

        if(canHeal<=0.0f)
        {
            if(healthLevel<maxhealthLevel)
            {
                healthLevel += maxhealthLevel * 0.01f;
                StartCoroutine("heal"); //Uruchamia podprogram
            }
            Mathf.Clamp(healthLevel, 0, maxhealthLevel); //Utrzymuje healthLevel, zaby nie rzekroczyl wartosci granicznych
        }


    }
    IEnumerator heal() //Odczekuje, aby przyrost hp fajniej wygladal
    {
        yield return new WaitForSeconds(0.5f);
    }
}
