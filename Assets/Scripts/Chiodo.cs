using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiodo : PuzzleElement
{
    [SerializeField] private GameObject cordaEChiodo;

    public override void CustomOnClickAction(Inventory playerInventory)
    {
        cordaEChiodo.SetActive(true);
        Destroy(this.gameObject);
    }
}
