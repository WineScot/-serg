using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {

    
    public GameObject hero;
    public GameObject eq;
    public GameObject locker;
    public Transform trans;
    public int w = 4;

    // Use this for initialization
    void Start ()
    {
        locker = GameObject.FindGameObjectWithTag("locker");
        hero = GameObject.FindGameObjectWithTag("Player");
        eq = GameObject.FindGameObjectWithTag("eq");
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            eq.gameObject.GetComponent<Ekwipunek>().lockerArea = true;
            eq.gameObject.GetComponent<Ekwipunek>().thislocker = base.gameObject;
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            eq.gameObject.GetComponent<Ekwipunek>().lockerArea = false;
        }
    }


}
