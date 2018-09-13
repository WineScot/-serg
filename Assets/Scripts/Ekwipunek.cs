﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ekwipunek : MonoBehaviour {

    private Canvas ekwipunek;
    private GameObject locker;
    public bool lockerArea = false;
    public GameObject thislocker;
    private int listSize;
    private Transform trans;
    private Transform child;

    // Use this for initialization
    void Start ()
    {
        locker = GameObject.FindGameObjectWithTag("locker");
        locker.SetActive(false);
        ekwipunek = (Canvas)GetComponent<Canvas>();
        ekwipunek.enabled = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
           if(lockerArea)
            {
                locker.SetActive(true);  
            }
           else
            {
                locker.SetActive(false);
            }
           if(ekwipunek.enabled)
            {
                ekwipunek.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                if(lockerArea)
                {
                    listSize = locker.gameObject.GetComponent<ItemWindow>().trans.childCount;
                    for (int i = 0; i < listSize; i++)
                    {
                        child = locker.gameObject.GetComponent<ItemWindow>().transform.GetChild(0);
                        child.SetParent(trans.parent);
                        child.SetParent(thislocker.gameObject.GetComponent<Locker>().trans);
                    }
                }
            }
           else
            {
                if(lockerArea)
                {
                    listSize = thislocker.gameObject.GetComponent<Locker>().trans.childCount;
                    if (locker.gameObject.GetComponent<ItemWindow>().trans != null)
                    {
                        for (int i = 0; i < listSize; i++)
                        {
                            
                                child = thislocker.gameObject.GetComponent<Locker>().trans.GetChild(0);
                                child.SetParent(trans.parent);

                                child.SetParent(locker.gameObject.GetComponent<ItemWindow>().trans);
                            


                        }
                    }
                }
                ekwipunek.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }
}
