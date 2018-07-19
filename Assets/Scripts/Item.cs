using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public string name;
	enum Kind { Weapon, Potion, Other };
	// typ przedmiotu. Potem można to zastąpić dziedziczniem jeśli będzie to konieczne
	public int kind;
	public int attack;
	
	public Item( int k )
	{
		kind = k;
	}
	
	public int GetAttack()
	{
		if(kind == (int)Kind.Weapon)
		{
			return attack;
		}
		else
		{	
			Debug.LogWarning("Przedmiot który nie jest bronią został użyty jako broń");
			return -1;
		}	
	}
}
