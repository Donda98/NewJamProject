using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipo_NPC : NPC
{
    [SerializeField] PareteBloccante parete;
    [SerializeField] BoxCollider tablet;
    [SerializeField] Animator animator;
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
            StartCoroutine(PointTowards());
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

    public IEnumerator PointTowards()
    {
        animator.SetBool("isPointing", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("isPointing", true);
    }
}
