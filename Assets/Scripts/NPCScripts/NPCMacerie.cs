using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMacerie : MonoBehaviour, IInteractable
{
    [SerializeField] Transform interactionPosition;
    public AudioClip positiveClip;
    public AudioClip negativeClip;
    public void CustomOnClickAction()
    {
            GetComponent<CapsuleCollider>().enabled = false;
            GameManager.Instance.StartAct(3);
            GameManager.Instance.audience.AudienceReaction();
            GameManager.Instance.playerInstance.GetComponent<PlayerLevel>().lvlUP();
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = positiveClip;
            audio.Play();
    }

    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        return interactionPosition;
    }

    public void OnClick(Inventory playerInventory)
        {
            CustomOnClickAction();
        }
}
