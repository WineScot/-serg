using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {
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
	
	private void InitializeDatabase()
	{

        Database = JsonConvert.DeserializeObject<List<Item>>( Resources.Load<TextAsset>("Items").ToString() );
        Debug.Log(Database[0].attack);
    }
}
