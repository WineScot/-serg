using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemId;
	public string itemName;
    public string description;
	public enum Type { Weapon, Potion, Other };
	// typ przedmiotu. Potem można to zastąpić dziedziczniem jeśli będzie to konieczne
	public Type itemType;
    public int attack;
    // i inne...
	
    [Newtonsoft.Json.JsonConstructor]
	public Item( string _itemId, string _itemName, string _description, Type _itemType, int _attack )
	{
        this.itemId = _itemId;
        this.itemName = _itemName;
        this.description = _description;
        this.itemType = _itemType;
        this.attack = _attack;
	}
	
}
