using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : PuzzleElement
{
    [SerializeField] private GameObject bastoneConSchermo;

    public override void CustomOnClickAction(Inventory playerInventory)
    {
        playerInventory.FreeInventorySlot();
        bastoneConSchermo.SetActive(true);
        Destroy(this.gameObject);
    }
}
