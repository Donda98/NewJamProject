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
            if (canvas.isPaused == false)
            {
                canvas.ShowPauseMenu();
                canvas.isPaused = true;

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
                Cursor.SetCursor(cursorSkin[1], Vector2.zero, CursorMode.ForceSoftware);

            }
            else
            {
                mouseOnItem = false;
                Cursor.SetCursor(cursorSkin[0], Vector2.zero, CursorMode.ForceSoftware);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (mouseOnItem == false)
                {
                    GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[0]);
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
                    print("Ho cliccato un Item");
                }
                target.z = transform.position.z;
                target.y = transform.position.y;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            
            if (Input.GetMouseButtonUp(0))
            {
                if (mouseOnItem == false)
                {
                    GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[1]);
                }
                else
                {
                    //Pick Up Item
                    GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[3]);
                }
            }
        }else
        {
            Cursor.SetCursor(cursorSkin[0], Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}