using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] int itemID;
    [SerializeField] Transform characterInteractionPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Inventory playerInventory)
    {
        PickUpItem(playerInventory);
    }

    public void PickUpItem(Inventory playerInventory)
    {
        int freeSlotIndex;
        freeSlotIndex = playerInventory.CheckFreeSlot();
        print(freeSlotIndex);
        GameObject tempInventoryItem = playerInventory.gameObject.GetComponent<ItemList>().GetInventoryItem(itemID).gameObject;
        playerInventory.inventorySlot[freeSlotIndex] = tempInventoryItem.GetComponent<InventoryItem>();
        playerInventory.inventorySlot[freeSlotIndex].SetCurrentSlotInInventory(freeSlotIndex);
        playerInventory.SetCurrentItemSlotID(freeSlotIndex);
        
        //From print only, it seems  the inventory items are updated currently, though they show the wrong value in the component
        GameObject temp = Instantiate(playerInventory.inventorySlot[freeSlotIndex].gameObject, playerInventory.GetInventorySlotPosition(freeSlotIndex).position, Quaternion.identity);       
        Destroy(this.gameObject);
    }

    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return characterInteractionPosition;
    }

}
