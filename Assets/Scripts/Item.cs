using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] float itemID;
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
}
