using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class EQElement : MonoBehaviour , IBeginDragHandler, IDragHandler , IEndDragHandler {

    private Transform trans;
    private Transform itemParent;
    public GameObject eq;
    public EqElementType elementTyp = EqElementType.SWORD;
    
    // Use this for initialization
	void Start ()
    {
        trans = GetComponent<Transform>();
        itemParent = trans.parent;
        eq = GameObject.FindGameObjectWithTag("eq");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBeginDrag(PointerEventData eventDate) // when we click on item
    {
        trans.SetParent(eq.gameObject.GetComponent<Ekwipunek>().trans); // when we take item we change his parent to CanvasEQ
        GetComponent<CanvasGroup>().blocksRaycasts = false; //włączamy wykrywanie kursora myszy poprzez wyłączenie blokady promienia
    }

    public void OnDrag(PointerEventData eventDate) // when we move item
    {
        trans.position = eventDate.position; // item and cursor have the same position
    }

    public void OnEndDrag(PointerEventData eventDate) // when we drop item
    {
        if (trans.transform.parent.tag == "eq" || trans.transform.parent.tag == "scroleq")
        {
            trans.SetParent(itemParent);
            Debug.Log("tu jest błąd");
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true; //wyłączamy wykrywanie kursora myszy poprzez włączenie blokady promienia        
        
    }
}
