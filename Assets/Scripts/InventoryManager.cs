using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private GameObject Template;

    private GameObject player;
    public List<GameObject> inventory;
    private List<GameObject> Items;

    // Use this for initialization
    void Start()
    {
        StartInventory();
    }
    public void StartInventory () {
        inventory = gameObject.GetComponentInParent<Player>().eq.equipment;
        foreach (GameObject g in inventory)
        {
            GameObject slot = Instantiate(Template) as GameObject;
            slot.SetActive(true);
            slot.GetComponent<EquipmentElement>().SetText(g.name);
            slot.transform.SetParent(Template.transform.parent, false);
            Items.Add(slot);
        }
    }

    public void UpdateInventory(GameObject g)
    {     
            GameObject slot = Instantiate(Template) as GameObject;
            slot.SetActive(true);
            slot.GetComponent<EquipmentElement>().SetText(g.name);
            slot.transform.SetParent(Template.transform.parent, false);
            Items.Add(slot);
    }
}
