using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
	// później, w razie potrzeby możemy zastąpić GameObject własną klasą przedmiotu
	public List <GameObject> equipment = new List<GameObject>();
	
	// Przedmioty aktualnie używane przez Gracza
	// Jak będzie ich więcej to można zastąpić tablicą
	public GameObject Weapon;
	public GameObject Spear;
	
	public void ShowEquipment()
	{
		foreach(GameObject g in equipment)
		{
			Debug.Log(g.name);
		}
	}
	
	public void AddToEq(GameObject added)
	{
		equipment.Add(added);
	}
	
	public void RemoveFromEq(GameObject removed)
	{
		equipment.Remove(removed);
	}
}
