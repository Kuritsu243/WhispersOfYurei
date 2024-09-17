using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    public InventoryItem item;

    public InventoryItem Pickup()
    {
        Destroy(gameObject);
        return this.item;
    }
}