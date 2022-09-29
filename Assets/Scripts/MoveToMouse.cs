using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask layersToRay;
    public LayerMask itemLayer;

    [SerializeField] private Camera mainCam;

    private bool mouseOnItem;
    private Vector3 target;
    private GameObject itemHit;
    private IInteractable interacted;

    private bool isMoving = false;
    private bool isGoingToInteractionPoint = false;

    private Inventory characterInventory;

    private void Awake()
    {
        characterInventory = GetComponent<Inventory>();
    }
    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        MousePositionCheck();

        if (Input.GetMouseButtonDown(0))
        {
            DestinationCheck();
            AlignOnXAxis();
        }
        GoToTargetDestination();
        if (Input.GetMouseButtonDown(1))
        {
            characterInventory.currentItem = null;
        }
    }

    private void MousePositionCheck()
    {
        if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit_01, 500f, itemLayer))
        {
            mouseOnItem = true;
            itemHit = hit_01.collider.gameObject;
            //print("Sono sopra un Item");
        }
        else
        {
            mouseOnItem = false;
        }
    }

    private void GoToTargetDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target && isGoingToInteractionPoint == false)
        {
            isMoving = false;
        }
    }

    private void DestinationCheck()
    {
        if (mouseOnItem == false)
        {
            GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[0]);
            Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out RaycastHit hit, 500f, layersToRay))
            {
                target = hit.point;
                isMoving = true;
                isGoingToInteractionPoint = false;
            }
            else
            {
                print("Non posso andarci!");

            }
        }
        else
        {
            if ((interacted = itemHit.GetComponent<IInteractable>()) != null)
            {
                print("Ho cliccato VERAMENTE un item");
                target = interacted.GetInteractablePosition(characterInventory).position;
                StartCoroutine(ReachInteractableCoRoutine(interacted));
            }
            else
            {
                print("Ho cliccato un Item");
            }
        }
    }

    private void AlignOnXAxis()
    {
        //keeps the movement only on the x axis by resetting the z and y position
        target.z = transform.position.z;
        target.y = transform.position.y;
    }

    IEnumerator ReachInteractableCoRoutine(IInteractable interacted)
    {
        isMoving = true;
        isGoingToInteractionPoint = true;
        print("Coroutine Started");
        print("I am on my way");
        while (this.gameObject.transform.position.x != target.x && isMoving == true) 
        {
            yield return null;
        }
        if (isMoving == true && isGoingToInteractionPoint == true)
        {
            isGoingToInteractionPoint = false;
            isMoving = false;
            print("Point reached");
            TriggerOnClickAction(interacted);
        }
    }

    private void TriggerOnClickAction(IInteractable interacted)
    {
        interacted.OnClick(characterInventory);
    }
}