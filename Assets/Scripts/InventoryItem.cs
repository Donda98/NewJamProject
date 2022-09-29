using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IInteractable
{
    [SerializeField] int itemID;
    public int currentSlotInInventory;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    
    public void OnClick(Inventory playerInventory)
    {
        SelectItem(playerInventory);
        playerInventory.MoveItemAround(playerInventory.currentItem);
    }

    public void SelectItem(Inventory playerInventory)
    {
        //if (playerInventory.currentItem == null)
        //{
            playerInventory.EquipItem(this);
        //}

    }
    public int GetItemID()
    {
        return itemID;
    }
    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return playerInventory.gameObject.transform;
    }

    public void SetCurrentSlotInInventory(int slotIndexPosition)
    {
        currentSlotInInventory = slotIndexPosition;
    }
    
}

    

