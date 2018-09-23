using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemWindow : MonoBehaviour , IDropHandler {

    public EqElementType elementTyp = EqElementType.EKWIPUNEK;
    public GameObject ekwipunekObiekt;
    public int maxElement;
    public Transform trans;

    // Use this for initialization
    void Start ()
    {
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        
        EQElement item = eventData.pointerDrag.GetComponent<EQElement>();
        if(elementTyp == EqElementType.EKWIPUNEK) // if our window is ekipunek then we can put them everything
        {
            item.transform.parent = trans;
        }
        else
        {
            if(elementTyp == item.elementTyp) // slot type and item typ mus be the same
            {
                if (trans.childCount < maxElement) // some slots have only one position
                {
                item.transform.parent = trans;
                }
                else
                {
                Transform elem = transform.GetChild(0); //take item from slot
                elem.SetParent(ekwipunekObiekt.transform); //we put this item in MYeQ
                item.transform.parent = trans; //new element is in window
                }
            }

            
        }
    }
}
