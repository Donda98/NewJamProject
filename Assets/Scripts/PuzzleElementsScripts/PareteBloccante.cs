using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PareteBloccante : PuzzleElement
{
    [SerializeField] private GameObject detriti;
    [SerializeField] private BoxCollider piccone;
    [SerializeField] private ParetePicconabile picconabile;

    public override void CustomOnClickAction(Inventory playerInventory)
    {
        if (detriti != null)
        {
            playerInventory.FreeInventorySlot();
            Destroy(detriti);
            piccone.enabled = true;
            picconabile.enabled = true;
            Destroy(this);
        }
    }
}