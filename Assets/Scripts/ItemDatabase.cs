using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {
    //Przechowuje wszystkie przedmioty w liście z której potem można się do nich odwołać za pomocą nazwy
	public static ItemDatabase Instance;
	public List<Item> Database = new List<Item>();
	// Use this for initialization
	void Start () {
		if( Instance != null && Instance != this )
			Destroy(gameObject);
		else
			Instance = this;

        InitializeDatabase();
	}
	
    // wczytuje przedmioty z pliku .json
	private void InitializeDatabase()
	{
        Database = JsonConvert.DeserializeObject<List<Item>>( Resources.Load<TextAsset>("Items").ToString() );
    }

    public Item GetItem(string id)
    {
        foreach(Item i in Database)
        {
            //Debug.Log(i.itemId);
            if( i.itemId == id )
            {
                return i;
            }
        }
        Debug.LogWarning("Nie znaleziono przedmiotu o id " + id);
        return null;
    }
}
