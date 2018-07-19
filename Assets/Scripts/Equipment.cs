using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
	// lista wszystkich przedmiotów
	public List <Item> equipment = new List<Item>();
	
	// Przedmioty aktualnie używane przez Gracza
	// Jak będzie ich więcej to można zastąpić tablicą
	public Item Weapon;
	public Item Spear;
	
	public void AddToEq(Item added)
	{
		equipment.Add(added);
	}
	
	public void RemoveFromEq(Item removed)
	{
		equipment.Remove(removed);
	}
	
	void Start()
	{
		//domyślny miecz
		//Item miecz = new Item(0);
		//miecz.attack = 20;
		//equipment.Add(miecz);
		Weapon = ItemDatabase.Instance.GetItem("Weapon");
		Spear = ItemDatabase.Instance.GetItem("Spear");
	}
}
