﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
	// lista wszystkich przedmiotów
	public List <Item> equipment = new List<Item>();
	
	// Przedmioty aktualnie używane przez Gracza
	// Jak będzie ich więcej to można zastąpić tablicą
	public Item Weapon;
	public Item Spear;
	
	public void ShowEquipment()
	{
		foreach(Item g in equipment)
		{
			Debug.Log(g.name);
		}
	}
	
	public void AddToEq(Item added)
	{
		equipment.Add(added);
	}
	
	public void RemoveFromEq(Item removed)
	{
		equipment.Remove(removed);
	}
}
