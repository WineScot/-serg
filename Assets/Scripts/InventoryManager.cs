using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private GameObject Template;

    private GameObject player;
    public List<Item> inventory;
    private List<GameObject> Items = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        StartInventory();
    }
    public void StartInventory () {
        inventory = gameObject.GetComponentInParent<Player>().eq.equipment;
        foreach (Item g in inventory)
        {
			UpdateInventory(g);
			/*g.gameObject = Instantiate(Template);
            g.gameObject.SetActive(true);
            g.gameObject.GetComponent<EquipmentElement>().SetText(g.name);
            g.gameObject.transform.SetParent(Template.transform.parent, false);
            Items.Add(g);*/
        }
    }

    public void UpdateInventory(Item g)
    {     
            GameObject slot = Instantiate(Template) as GameObject;
            slot.SetActive(true);
            slot.GetComponent<EquipmentElement>().SetText(g.itemName);
            slot.transform.SetParent(Template.transform.parent, false);
            Items.Add(slot);
    }
}
