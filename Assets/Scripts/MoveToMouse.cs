using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask layersToRay;

    [SerializeField] private Camera mainCam;

    private Vector3 target;
    private Ray cameraRay;
    private GameObject objectHit;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[0]);
           Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(cameraRay,out RaycastHit hit,layersToRay))
           {
                objectHit = hit.collider.gameObject;
                if(objectHit.TryGetComponent(out InteractableLEO interactableObjectHit) == true)
                {
                    /*  switch(interactableObjectHit)
                      {

                      }*/
                    print($"Mi muovo verso:{target.x}");
                    target = hit.point;
                }
                else
                {
                    print("Non posso andarci!");
                }
           }
           else
           {
                print("Non posso andarci!");

           }

           target.z = transform.position.z;
           target.y = transform.position.y;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}