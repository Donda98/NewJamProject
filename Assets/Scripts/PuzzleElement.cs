using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleElement : MonoBehaviour, IInteractable
{
    [SerializeField] Transform characterInteractionPosition;
    [SerializeField] int requiredItemID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Inventory playerInventory)
    {
        if (playerInventory.currentItem.GetItemID() == requiredItemID)
        {
            CustomOnClickAction();
        }
        else
        {
            print("Wrong item");
        }
    }

    public virtual void CustomOnClickAction()
    {

    }

    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return characterInteractionPosition;
    }
}
