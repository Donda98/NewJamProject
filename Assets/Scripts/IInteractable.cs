using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnClick();

    Transform GetInteractablePosition();
}
