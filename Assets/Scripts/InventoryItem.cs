using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IInteractable
{
    [SerializeField] int itemID;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    
    public void OnClick(Inventory playerInventory)
    {
        SelectItem();
    }

    public void SelectItem()
    {
        
    }

    public void SetItemID(int newID)
    {
        itemID = newID;
    }

    public Transform GetInteractablePosition()
    {
        return gameObject.transform;
    }
}

    

