using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {

    public float height = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            float vel = Mathf.Sqrt(2000 * height);
            other.gameObject.GetComponent<EnemyDetection>().ChangeVelocity(new Vector2(0, vel));
        }
    }
}
