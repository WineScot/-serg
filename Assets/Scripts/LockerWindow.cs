using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LockerWindow : MonoBehaviour, IDropHandler
{


    public EqElementType elementTyp = EqElementType.EKWIPUNEK;
    public GameObject ekwipunekObiekt;
    public int maxElement;
    public Transform trans;
    public Transform parent;

    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

        EQElement item = eventData.pointerDrag.GetComponent<EQElement>();
        
        item.transform.parent = parent;
       

     
    }
}


