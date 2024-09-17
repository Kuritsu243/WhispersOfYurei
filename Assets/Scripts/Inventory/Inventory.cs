using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private static int MAX_ITEMS = 4;

    public bool AddItem(InventoryItem itemToAdd)
    {
        if (inventory.Count < MAX_ITEMS)
        {
            if (!inventory.Find(e => e.Name != itemToAdd.Name))
            {
                inventory.Add(itemToAdd);
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(InventoryItem itemToRemove)
    {
        if (inventory.Count > 0)
        {
            InventoryItem foundItem;
            if (foundItem = inventory.Find(e => e.Name == itemToRemove.Name))
            {
                inventory.Remove(foundItem);
                return true;
            }
        }
        return false;
    }

    public void DropItem(InventoryItem itemToDrop)
    {
        if (inventory.Count > 0)
        {
            InventoryItem foundItem;
            if (foundItem = inventory.Find(e => e.Name == itemToDrop.Name))
            {
                GameObject droppedItem = new GameObject();
                droppedItem.AddComponent<Rigidbody>();
                droppedItem.AddComponent<InventoryItemInstance>().item = foundItem;
                GameObject itemModel = Instantiate(foundItem.Obj, droppedItem.transform);

                inventory.Remove(foundItem);
            }
        }
    }
}
