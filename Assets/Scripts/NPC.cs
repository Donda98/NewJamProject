using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject[] dialogueList;
    [SerializeField] Transform dialoguePopUpPosition;
    [SerializeField] Transform characterInteractionPosition;
    public int requiredItemID;
    //[SerializeField] int[] itemIDAnswers = { 0, 0, 0, 0, 0, 0 };
    public void OnClick(Inventory playerInventory)
    {
        if (playerInventory.currentItem == null)
        {
            ReproduceDefaultDialogue();
            print("tikitikidesuka?");
        }
        else
        {
            ReproduceDialogue(playerInventory);
        }
    
    }

    public virtual void ReproduceDialogue(Inventory playerInventory)
    {
        
    }
    
    public void ReproduceDefaultDialogue()
    {
        GameObject tempDialogue = Instantiate(dialogueList[0], dialoguePopUpPosition.position, Quaternion.identity);
        Destroy(tempDialogue, 5);
    }
    
    public virtual void CustomNPCEvent()
    {

    }

    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return characterInteractionPosition;
    }
}
