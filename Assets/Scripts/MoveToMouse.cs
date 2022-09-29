using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask layersToRay;
    public LayerMask itemLayer;
    public bool mouseActive;
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
        if (canvas.isOnMenu == false && canvas.isPaused==false)
        {
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit_01, 500f, itemLayer))
            {
                mouseOnItem = true;
                itemHit = hit_01.collider.gameObject;
                print("Sono sopra un Item");
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
                        target = hit.point;
                    }
                    else
                    {
                        print("Non posso andarci!");
                    }
                }
                else
                {
                    isInteracting = true;
                    Cursor.SetCursor(cursorSkin[3], Vector2.zero, CursorMode.ForceSoftware);
                    print("Ho cliccato un Item");
                }
                target.z = transform.position.z;
                target.y = transform.position.y;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            
            if (Input.GetMouseButtonUp(0))
            {
                isClicking = false;
                if (mouseOnItem)
                {
                    //Pick Up Item
                    if (isInteracting)
                    {
                        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[3]);
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
            }
        }
    }
}