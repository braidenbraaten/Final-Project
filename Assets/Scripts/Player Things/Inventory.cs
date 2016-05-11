using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<GameObject> inventoryItems;
    public GameObject Player;
    public GameObject grabedObject;

	// Use this for initialization
	void Start () {

        //inits the inventory items
        
     
	
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

    //adding items
    void addItemToInventory(GameObject grabedItem)
    {
        inventoryItems.Add(grabedItem);
    }

    //replacement
    void replaceItemInInventory(string itemName, GameObject newObject)
    {
        //loops through the inventory
        for (int i = 0; i < inventoryItems.Capacity; i++)
        {
            //looks for gameobjects with the same name as the parameter name
            if (itemName == inventoryItems[i].gameObject.name)
            {
                //replaces the object with the new one
                inventoryItems[i] = newObject;
            }
        }
    }

    GameObject getObject(string name)
    {
        for (int i = 0; i < inventoryItems.Capacity; i++)
        {
            if (inventoryItems[i].name == name)
            {
                return inventoryItems[i];
            }

        }
        return null;


    }

    //delete item
    void takeOutItem(string itemName)
    {
        for (int i = 0; i < inventoryItems.Capacity; i++)
        {
            if (inventoryItems[i].name == itemName)
            {
               // inventoryItems.con
            }
        }
    }
}
