using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CumuloDiNeve : MonoBehaviour, IInteractable
{
    [SerializeField]  Transform interactionPosition;
    [SerializeField] private CapsuleCollider tipoDaSalvare;
    [SerializeField] private ChiodoArrampicata chiodo;
    public static int numeroCumuli=0;

    private void Awake()
    {
        numeroCumuli++;
    }
    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return interactionPosition;
    }

    public void OnClick(Inventory playerInventory)
    {
        numeroCumuli--;
        if (numeroCumuli <= 0)
        {
            tipoDaSalvare.enabled = true;
            chiodo.questIsActive = true;
        }
        Destroy(this.gameObject);
    }
}
