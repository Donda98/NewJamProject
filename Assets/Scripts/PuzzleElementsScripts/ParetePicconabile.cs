using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParetePicconabile : PuzzleElement
{
    [SerializeField] CapsuleCollider tipoMacerie;
    [SerializeField] GameObject clickableSpace;
    public override void CustomOnClickAction(Inventory playerInventory)
    {
        Destroy(this.gameObject);
        playerInventory.FreeInventorySlot();
        tipoMacerie.enabled = true;
        clickableSpace.SetActive(true);
    }
}
