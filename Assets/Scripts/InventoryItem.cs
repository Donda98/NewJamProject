using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class InventoryItem : MonoBehaviour, IInteractable
{
    [SerializeField] int itemID;
    Inventory characterInventory;

    void Awake()
    {
        characterInventory = GetComponent<Inventory>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    
    public void OnClick()
    {
        SelectItem();
    }

    public void SelectItem()
    {
        characterInventory.EquipItem(this);
    }

    public void SetItemID(int newID)
    {
        itemID = newID;
    }

    
}
