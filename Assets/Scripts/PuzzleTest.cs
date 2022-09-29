using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTest : PuzzleElement
{
    // Start is called before the first frame update
    public override void CustomOnClickAction(Inventory playerInventory)
    {
        playerInventory.FreeInventorySlot();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
