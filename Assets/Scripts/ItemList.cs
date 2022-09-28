using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] InventoryItem[] inventorySlot = { null, null, null, null, null, null };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InventoryItem GetInventoryItem(int IDslot)
    {
        return inventorySlot[IDslot];
    }
}
