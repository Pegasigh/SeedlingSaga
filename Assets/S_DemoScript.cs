using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DemoScript : MonoBehaviour
{
    public S_InventoryManager inventoryManager;
    public SO_Item[] itemsToPickup;

    public void PickupItem (int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        //if (result == true) Debug.Log("Item added: " + itemsToPickup[id].name);
        //else Debug.Log("ITEM NOT ADDED: " + itemsToPickup[id].name);
    }

    public void GetSelectedItem()
    {
        SO_Item item = inventoryManager.GetSelectedItem(false);
        if (item != null) Debug.Log(item.name);
    }

    public void UseSelectedItem()
    {
        SO_Item item = inventoryManager.GetSelectedItem(true);
        if (item != null) Debug.Log(item.name);
    }
}
