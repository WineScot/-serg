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
	
    void EquipWeapon(string name)
    {
        // dodać sprawdzenie czy to broń
        Weapon = ItemDatabase.Instance.GetItem(name);
        WeaponAttack atk = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponAttack>();
        atk.attackPoint = Weapon.attack;
    }

    void EquipSpear(string name)
    {
        // sprawdzić czy włucznia
        Spear = ItemDatabase.Instance.GetItem(name);
        SpearThrowing spr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpearThrowing>();
        spr.attackPoint = Spear.attack;
    }

	void Start()
	{
        //domyślny miecz
        //Item miecz = new Item(0);
        //miecz.attack = 20;
        //equipment.Add(miecz);
        EquipWeapon("Weapon");
        EquipSpear("Spear");
        //Spear = ItemDatabase.Instance.GetItem("Spear");
	}
}
