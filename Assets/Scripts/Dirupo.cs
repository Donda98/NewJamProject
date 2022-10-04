using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirupo : PuzzleElement
{
    [SerializeField] private GameObject chiodo;
    public override void CustomOnClickAction(Inventory playerInventory)
    {
        chiodo.SetActive(true);
        Destroy(this.gameObject);
    }
}
