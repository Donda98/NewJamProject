using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    private string[] dialogueList;
    [SerializeField] Transform dialoguePopUpPosition;
    [SerializeField] Transform characterInteractionPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        // Cooroutine to check (in the MoveToMouse function) if the character has reached the interaction point. Only then NPC may speak.
        ReproduceDialogue();
    }

    public void ReproduceDialogue()
    {

    }

    public Transform GetInteractablePosition()
    {
        return characterInteractionPosition;
    }
}
