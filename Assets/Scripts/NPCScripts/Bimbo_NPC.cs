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
            GameManager.Instance.StartAct(2);
            GameManager.Instance.AudienceReaction();
        }
        else
        {
            print("It is not what I need");
        }
    }
}
