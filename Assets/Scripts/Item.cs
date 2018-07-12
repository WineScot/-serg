using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : GameObject {

	enum Kind { Weapon, Potion, Other };
	// typ przedmiotu. Potem można to zastąpić dziedziczniem jeśli będzie to konieczne
	public int kind = 0;
	
	public int GetAttack()
	{
		if(kind == (int)Kind.Weapon)
		{
			int attack = 20;
			return 20;
		}
		else
		{	
			Debug.LogWarning("Przedmiot który nie jest bronią został użyty jako broń");
			return -1;
		}	
	}
}
