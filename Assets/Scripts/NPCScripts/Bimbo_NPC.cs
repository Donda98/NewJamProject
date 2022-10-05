using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bimbo_NPC : NPC
{
    public override void ReproduceDialogue(Inventory playerInventory)
    {
        if (playerInventory.currentItem.GetItemID() == requiredItemID)
        {
            print("OH SUGOI DESU NE");
            playerInventory.FreeInventorySlot();
            GameManager.Instance.StartAct(2);
            GameManager.Instance.audience.AudienceReaction();
            GameManager.Instance.playerInstance.GetComponent<PlayerLevel>().lvlUP();
        }
        else
        {
            print("It is not what I need");
        }
    }
}
