using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class EQElement : MonoBehaviour , IBeginDragHandler, IDragHandler , IEndDragHandler {

    private Transform trans;
    private Transform itemParent;
    public GameObject eq;
    public Image imagewindow;
    private string itemparameters;
    public float attackPoint;
    public float defencePoint;
    public float attackBleedingPoint;
    public float attackPoisonPoint;
    public float attackFirePoint;
    public float defenceBleedingPoint;
    public float defencePoisonPoint;
    public float defenceFirePoint;
    public Text textwindow;
    public EqElementType elementTyp = EqElementType.SWORD;
    
    // Use this for initialization
	void Start ()
    {
        trans = GetComponent<Transform>();
        itemParent = trans.parent;
        eq = GameObject.FindGameObjectWithTag("eq");
        imagewindow.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void OnBeginDrag(PointerEventData eventDate) // when we click on item
    {
        trans.SetParent(eq.gameObject.GetComponent<Ekwipunek>().trans); // when we take item we change his parent to CanvasEQ
        GetComponent<CanvasGroup>().blocksRaycasts = false; //włączamy wykrywanie kursora myszy poprzez wyłączenie blokady promienia
        itemparameters = "";
        if (attackPoint > 0) { itemparameters += "Atak: " + attackPoint + "\n"; }
        if(defencePoint > 0) { itemparameters += "Obrona: " + defencePoint + "\n"; }
        if (attackBleedingPoint > 0) { itemparameters += "Krwawienie(atk): " + attackBleedingPoint + "\n"; }
        if (attackPoisonPoint > 0) { itemparameters += "Trucizna(atk): " + attackPoisonPoint + "\n"; }
        if (attackFirePoint > 0) { itemparameters += "Ogien(atk): " + attackFirePoint + "\n"; }
        if (defenceBleedingPoint > 0) { itemparameters += "Krwawienie(obr): " + defenceBleedingPoint + "\n"; }
        if (defencePoisonPoint > 0) { itemparameters += "Trucizna(obr): " + defencePoisonPoint + "\n"; }
        if (defenceFirePoint > 0) { itemparameters += "Ogien(obr): " + defenceFirePoint + "\n"; }
        textwindow.text = itemparameters;
        imagewindow.sprite = GetComponent<Image>().sprite;
        imagewindow.enabled = true;
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
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true; //wyłączamy wykrywanie kursora myszy poprzez włączenie blokady promienia        
        
    }
}
