using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipo_NPC : NPC
{
    [SerializeField] PareteBloccante parete;
    [SerializeField] BoxCollider tablet;
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
            parete.enabled = true;
            tablet.enabled = true;
            parete.GetComponent<BoxCollider>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            audio.clip = negativeClip;
            audio.Play();
            print("It is not what I need");
        }
    }
}
