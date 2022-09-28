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
        InventoryItem tempInventoryItem = playerInventory.gameObject.GetComponent<ItemList>().GetInventoryItem(itemID);
        playerInventory.inventorySlot[freeSlotIndex] = tempInventoryItem;
        playerInventory.inventorySlot[freeSlotIndex].SetItemID(freeSlotIndex);
        Instantiate(playerInventory.inventorySlot[freeSlotIndex].gameObject, playerInventory.GetInventorySlotPosition(freeSlotIndex).position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public Transform GetInteractablePosition()
    {
        return characterInteractionPosition;
    }

}
