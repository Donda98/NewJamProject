using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] float itemID;
    [SerializeField] Transform characterInteractionPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        // Cooroutine to check (in the MoveToMouse function) if the character has reached the interaction point. Only then it may pick up the item.
        PickUpItem();
    }

    public void PickUpItem()
    {
        Inventory inventory = GetComponent<Inventory>();
        int freeSlotIndex;
        freeSlotIndex = inventory.CheckFreeSlot();
        inventory.inventorySlot[freeSlotIndex].SetItemID(freeSlotIndex);
        Destroy(this);
    }

    public Transform GetInteractablePosition()
    {
        return characterInteractionPosition;
    }

}
