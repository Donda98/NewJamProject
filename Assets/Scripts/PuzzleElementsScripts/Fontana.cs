using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fontana : PuzzleElement
{
    [SerializeField] GameObject robotPulito;
    [SerializeField] Transform robotSpawnPosition;

    public override void CustomOnClickAction(Inventory playerInventory)
    {
        GameObject tempRobotPulito = Instantiate(robotPulito, robotSpawnPosition.position, Quaternion.identity);
        playerInventory.FreeInventorySlot();
    }
}
