using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 sub = transform.parent.gameObject.GetComponent<MovingReferences>().sub;
        Vector2 objectPosition = transform.position;
        transform.position = sub + objectPosition;
	}
}
