using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnClick(Inventory playerInventory);

    Transform GetInteractablePosition();
}
