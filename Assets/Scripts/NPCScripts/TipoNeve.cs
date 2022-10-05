using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoNeve : NPC
{
    public AudioClip positiveClip;
    public AudioClip negativeClip;
    public override void ReproduceDialogue(Inventory playerInventory)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (playerInventory.currentItem.GetItemID() == requiredItemID)
        {
            audio.clip = positiveClip;
            audio.Play();
            print("OH SUGOI DESU NE");
            playerInventory.FreeInventorySlot();
            GetComponent<CapsuleCollider>().enabled = false;
            GameManager.Instance.LoadMenu();
            GameManager.Instance.audience.AudienceReaction();
            GameManager.Instance.playerInstance.GetComponent<PlayerLevel>().lvlUP();
        }
        else
        {
            audio.clip = negativeClip;
            audio.Play();
            print("It is not what I need");
        }
    }
}
