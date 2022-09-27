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

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out RaycastHit hit_01, 500f, itemLayer))
        {
            mouseOnItem = true;
            itemHit = hit_01.collider.gameObject;
            print("Sono sopra un Item");
        }
        else
        {
            mouseOnItem = false;
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
    }
}