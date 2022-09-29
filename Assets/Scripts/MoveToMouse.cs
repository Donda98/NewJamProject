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
            if (canvas.isPaused == false)
            {
                canvas.ShowPauseMenu();
                canvas.isPaused = true;
                isClicking = false;
            }
            else
            {
                canvas.ResumeGame();
                canvas.isPaused = false;
            }
        }
        
        //Controllo se il gioco è in pausa, per capire se attivare o meno i controlli del player.
        if (canvas.isOnMenu == false && canvas.isPaused==false)
        {
            //Controllo se il cursore è sopra un ITEM, in caso cambio la sua texture e assegno l'item ad una variabile.
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

            //Alla pressione del tasto sinistro del Mouse, se sono sopra un Item ci interagisco, altrimenti assegno come target da raggiungere il punto cliccato.
            if (Input.GetMouseButtonDown(0))
            {
                isClicking = true;
                if (mouseOnItem == false)
                {
                    Cursor.SetCursor(cursorSkin[1], Vector2.zero, CursorMode.ForceSoftware);
                    GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[1]);
                    Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(cameraRay, out RaycastHit hit, 500f, layersToRay))
                    {
                        SetTarget(hit.point);
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
                }

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
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }
    }

    private void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        target.z = transform.position.z;
        target.y = transform.position.y;
    }
}