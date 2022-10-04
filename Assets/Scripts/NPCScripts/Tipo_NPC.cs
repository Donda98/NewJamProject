using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipo_NPC : NPC
{
    [SerializeField] PareteBloccante parete;
    [SerializeField] BoxCollider tablet;
    public override void ReproduceDialogue(Inventory playerInventory)
    {
        if (playerInventory.currentItem.GetItemID() == requiredItemID)
        {
            print("OH SUGOI DESU NE");
            playerInventory.FreeInventorySlot();
            parete.enabled = true;
            tablet.enabled = true;
            parete.GetComponent<BoxCollider>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            print("It is not what I need");
        }
    }
}
