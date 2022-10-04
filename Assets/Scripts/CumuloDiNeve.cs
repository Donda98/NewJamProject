using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CumuloDiNeve : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform interactionPosition;
    [SerializeField] private CapsuleCollider tipoDaSalvare;


    private void Awake()
    {
    }
    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return interactionPosition;
    }

    public void OnClick(Inventory playerInventory)
    {
        CustomOnClickAction();
    }
    public void CustomOnClickAction()
    {
        Destroy(this.gameObject);
    }
}
