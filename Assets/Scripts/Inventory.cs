using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] inventorySlot = { null, null, null };
    [SerializeField] Transform[] inventorySlotPosition = { null, null, null};
    public InventoryItem currentItem;


    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void FreeInventorySlot(int slotNumber)
    {
        inventorySlot[slotNumber] = null;
    }
    
    public int CheckFreeSlot()
    {
        int freeSlot = 0;

        for (int i = 0; i < inventorySlot.Length; i++)
        {
            if (inventorySlot[i] == null)
            {
                freeSlot = i;
                break;
            }
        }
       
        return freeSlot;
    }

    public void EquipItem(InventoryItem selectedItem)
    {
        currentItem = selectedItem;
    }

    public Transform GetInventorySlotPosition(int slotIndex)
    {
        return inventorySlotPosition[slotIndex];
    }
}
