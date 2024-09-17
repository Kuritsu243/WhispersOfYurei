using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject Obj;
    [TextArea]
    public string Description;
}

public class InventoryItemInstance : MonoBehaviour
{
    public InventoryItem item;

    public InventoryItem Pickup()
    {
        Destroy(gameObject);
        return item;
    }
}