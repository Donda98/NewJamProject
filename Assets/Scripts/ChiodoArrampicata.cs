using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiodoArrampicata : MonoBehaviour,IInteractable
{
    [SerializeField] BoxCollider[] upperClickableSpace;
    [SerializeField] BoxCollider[] bottomClickableSpace;
    [SerializeField] BoxCollider[] cumuliDiNeve;
    [SerializeField] CapsuleCollider tipoNellaNeve;
    private GameObject player;
    [SerializeField] Transform upperTeleportTransform;
    [SerializeField] Transform bottomTeleportTransform;
    [SerializeField] BoxCollider medikit;
    public bool questIsActive;
    private bool isPlayerDown;

    private void Start()
    {
        player = GameManager.Instance.playerInstance;
    }
    public  void CustomOnClickAction()
    {

        if (isPlayerDown)
        {
            if (medikit!=null&&tipoNellaNeve!=null&&questIsActive)
            {
                medikit.enabled = true;
                tipoNellaNeve.enabled = false;
            }
            else
            {
                if (tipoNellaNeve != null)
                {
                    tipoNellaNeve.enabled = false;
                }
            }
            foreach (BoxCollider collider in cumuliDiNeve)
            {
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
            upperClickableSpace[0].enabled = true;
            bottomClickableSpace[0].enabled = false;
            upperClickableSpace[1].enabled = true;
            bottomClickableSpace[1].enabled = false;
            player.transform.position = new Vector3(upperTeleportTransform.position.x, upperTeleportTransform.position.y, player.transform.position.z);
            player.GetComponent<MoveToMouse>().SetTarget(player.transform.position);
            isPlayerDown = false;
        }
        else
        {
            if (medikit != null)
            {
                medikit.enabled = false;
            }

            if (tipoNellaNeve != null && questIsActive)
            {
                tipoNellaNeve.enabled = true;
            }

            foreach (BoxCollider collider in cumuliDiNeve)
            {
                if (collider != null)
                {
                    collider.enabled = true;
                }
            }
            upperClickableSpace[0].enabled = false;
            bottomClickableSpace[0].enabled = true;
            upperClickableSpace[1].enabled = false;
            bottomClickableSpace[1].enabled = true;
            player.transform.position = new Vector3(bottomTeleportTransform.position.x, bottomTeleportTransform.position.y, player.transform.position.z);
            player.GetComponent<MoveToMouse>().SetTarget(player.transform.position);
            isPlayerDown = true;
        }
    }

    public void OnClick(Inventory playerInventory)
    {
        CustomOnClickAction();
    }

    public Transform GetInteractablePosition(Inventory playerInventory)
    {
        if (isPlayerDown)
        {
            return bottomTeleportTransform;
        }
        else
        {
            return upperTeleportTransform;
        }
    }
}
