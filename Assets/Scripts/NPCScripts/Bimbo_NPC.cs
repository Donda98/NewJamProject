using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bimbo_NPC : NPC
{
    [SerializeField] BoxCollider medikit;
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
            GameManager.Instance.StartAct(2);
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
