using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
	public static ItemDatabase Instance;
	public List<Item> Database = new List<Item>();
	// Use this for initialization
	void Start () {
		if( Instance != null && Instance != this )
			Destroy(gameObject);
		else
			Instance = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
