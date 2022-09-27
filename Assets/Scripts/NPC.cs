using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    private string[] dialogueList;
    [SerializeField] Transform dialoguePopUpPosition;
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
        ReproduceDialogue();
    }

    public void ReproduceDialogue()
    {

    }
}
