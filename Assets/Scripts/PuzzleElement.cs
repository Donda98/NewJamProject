using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleElement : MonoBehaviour, IInteractable
{
    [SerializeField] Transform characterInteractionPosition;
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
        CustomOnClickAction();
    }

    public virtual void CustomOnClickAction()
    {

    }

    public Transform GetInteractablePosition()
    {
        return characterInteractionPosition;
    }
}
