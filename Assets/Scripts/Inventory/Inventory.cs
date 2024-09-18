using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private static int MAX_ITEMS = 4;

    public void DropItem(InventoryItem itemToDrop)
    {
        if (inventory.Count > 0)
        {
            InventoryItem foundItem;
            if (foundItem = FindItem(itemToDrop.Name))
            {
                GameObject droppedItem = new GameObject();
                droppedItem.AddComponent<Rigidbody>();
                droppedItem.AddComponent<PickupableItem>().item = foundItem;
                GameObject itemModel = Instantiate(foundItem.Obj, droppedItem.transform);

                inventory.Remove(foundItem);
            }
        }
    }

    public void PickupItem(PickupableItem itemToPickup)
    {
        if (inventory.Count < MAX_ITEMS)
        {
            if (!FindItem(itemToPickup.item.Name))
            {
                InventoryItem item = itemToPickup.Pickup();
                inventory.Add(item);
            }
        }
    }

    private InventoryItem FindItem(String name)
    {
        return inventory.Find(e => e.Name == name);
    }

    // DEBUG DAT BOSS
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         GameObject torch = GameObject.Find("TORCH");
    //         PickupableItem torchItem = torch.GetComponent<PickupableItem>();
    //         PickupItem(torchItem);
    //     }
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         DropItem(inventory[0]);
    //     }
    // }
}
