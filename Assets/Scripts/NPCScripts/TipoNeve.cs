using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoNeve : NPC
{
    public override void ReproduceDialogue(Inventory playerInventory)
    {
        if (playerInventory.currentItem.GetItemID() == requiredItemID)
        {
            print("OH SUGOI DESU NE");
            playerInventory.FreeInventorySlot();
            GetComponent<CapsuleCollider>().enabled = false;
            GameManager.Instance.StartAct(4);
            GameManager.Instance.audience.AudienceReaction();
            GameManager.Instance.playerInstance.GetComponent<PlayerLevel>().lvlUP();
        }
        else
        {
            print("It is not what I need");
        }
    }
}
