using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingReferences : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 previousPosition;
    public Vector2 sub;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 objectPosition = transform.position;
        sub = objectPosition - previousPosition;
        previousPosition = transform.position;
	}
}
