using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParetePicconabile : PuzzleElement
{
    [SerializeField] CapsuleCollider tipoMacerie;
    [SerializeField] GameObject clickableSpace;
    public override void CustomOnClickAction(Inventory playerInventory)
    {
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.interactClips[1], 2.5f);
        playerInventory.FreeInventorySlot();
        tipoMacerie.enabled = true;
        clickableSpace.SetActive(true);
        Destroy(this.gameObject);
    }
}
