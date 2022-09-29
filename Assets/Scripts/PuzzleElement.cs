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
        if(playerInventory.currentItem != null)
        {
            if (playerInventory.currentItem.GetItemID() == requiredItemID)
            {
                print("AMAZING BOSS, THAT'S WHY YOU ARE THE BEST. THE ONE AND ONLY.");
                CustomOnClickAction(playerInventory);
            }
            else
            {
                print("Wrong item");
            }
        }

    }

    public virtual void CustomOnClickAction(Inventory playerInventory)
    {

    }

    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return characterInteractionPosition;
    }
}
