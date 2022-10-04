using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CumuloDiNeve : MonoBehaviour, IInteractable
{
    [SerializeField]  Transform interactionPosition;
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
        print("Ho Richiamato ON CLICK");
        CustomOnClickAction();
    }
    public void CustomOnClickAction()
    {
        print("Dovrei distruggere la neve");
        Destroy(this.gameObject);
    }
}
