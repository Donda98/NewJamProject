using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    public bool mouseActive;
    public LayerMask layersToRay;
    public LayerMask itemLayer;
    public Texture2D[] cursorSkin;

    [SerializeField] private Camera mainCam;
    [SerializeField] private MainCanvas canvas;

    private bool mouseOnItem;
    private bool isClicking;
    private bool isInteracting;
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
        mainCam = GameManager.Instance.playerCAM;
        canvas = GameManager.Instance.canvas;
        GameManager.Instance.playerInstance = gameObject;
        Cursor.SetCursor(cursorSkin[0], Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && canvas.isOnMenu == false)
        {
            Cursor.SetCursor(cursorSkin[0], Vector2.zero, CursorMode.ForceSoftware);
            GameManager.Instance.sipario.instructions = 3;
            if (canvas.isPaused == false)
            {
                canvas.ShowPauseMenu();
                isClicking = false;
            }
            else
            {
                canvas.ResumeGame();
            }
        }

        if (canvas.isOnMenu == false && canvas.isPaused == false)
        {
            MousePositionCheck();

            if (Input.GetMouseButtonDown(0))
            {
                DestinationCheck();
            }
            if (Input.GetMouseButtonDown(1))
            {
                characterInventory.currentItem = null;
            }
            //Al rilascio del tasto sinistro del Mouse, se stavo interagendo con un Item ne richiamerò una funzione, altrimenti non faccio nulla.
            if (Input.GetMouseButtonUp(0))
            {
                isClicking = false;
                if (mouseOnItem)
                {
                    //Pick Up Item
                    if (isInteracting)
                    {
                        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[3]);
                        print("Interagisco con l'oggetto");
                        SetTarget(itemHit.transform.position);
                    }
                    else
                    {
                        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[1]);
                    }
                }
                else
                {
                    GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[1]);
                }
                Cursor.SetCursor(cursorSkin[0], Vector2.zero, CursorMode.ForceSoftware);
                isInteracting = false;
            }
            //Aggiorno costantemente la posizione del Player, che si muoverà sempre in direzione del Target alla velocità Speed.
            GoToTargetDestination();
        }
    }

    private void MousePositionCheck()
    {
        if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit_01, 500f, itemLayer))
        {
            mouseOnItem = true;
            itemHit = hit_01.collider.gameObject;
            if (isClicking == false)
            {
                Cursor.SetCursor(cursorSkin[2], Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else
        {
            mouseOnItem = false;
            if (isClicking == false)
            {
                Cursor.SetCursor(cursorSkin[0], Vector2.zero, CursorMode.ForceSoftware);
            }
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
        isClicking = true;
        if (mouseOnItem == false)
        {
            GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[0]);
            Cursor.SetCursor(cursorSkin[1], Vector2.zero, CursorMode.ForceSoftware);
            Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out RaycastHit hit, 500f, layersToRay))
            {
                SetTarget(hit.point);
                isMoving = true;
                isGoingToInteractionPoint = false;
            }
            else
            {
                print("Non posso andarci!");

            }
            isInteracting = false;
        }
        else
        {
            isInteracting = true;
            Cursor.SetCursor(cursorSkin[3], Vector2.zero, CursorMode.ForceSoftware);
            if ((interacted = itemHit.GetComponent<IInteractable>()) != null)
            {
                if (characterInventory.currentItem != null && ((itemHit.GetComponent<Item>())))
                print("Ho cliccato VERAMENTE un item");
                SetTarget(interacted.GetInteractablePosition(characterInventory).position);
                StartCoroutine(ReachInteractableCoRoutine(interacted));
            }
            else
            {
            }
        }
        if (transform.position.x < target.x)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
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
    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        target.z = transform.position.z;
        target.y = transform.position.y;
    }
}