using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bimbo_NPC : NPC
{
    public override void ReproduceDialogue(Inventory playerInventory)
    {
        if (playerInventory.currentItem.GetItemID() == requiredItemID)
        {
            print("OH SUGOI DESU NE");
            playerInventory.FreeInventorySlot();
            //concludes and change scene
        }
        else
        {
            print("It is not what I need");
        }
    }
}
