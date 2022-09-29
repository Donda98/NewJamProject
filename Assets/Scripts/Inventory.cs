using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] inventorySlot = { null, null, null };
    [SerializeField] Transform[] inventorySlotPosition = { null, null, null};
    public InventoryItem currentItem;
    [SerializeField] GameObject currentGameObject;
    private int currentItemSlotID;
    public Vector3 itemTargetPosition;

    private float moveSpeed = 90f;

    [SerializeField] Camera mainCam;
    public LayerMask layersToRay;


    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

   
    public void FreeInventorySlot()
    {
        inventorySlot[currentItemSlotID] = null;
        currentItem = null;
        Destroy(currentGameObject);
    }
    
    public int CheckFreeSlot()
    {
        int freeSlot = 0;

        for (int i = 0; i < inventorySlot.Length; i++)
        {
            if (inventorySlot[i] == null)
            {
                freeSlot = i;
                break;
            }
        }
       
        return freeSlot;
    }

    public void MoveItemAround(InventoryItem chosenInventoryItem)
    {
        StartCoroutine(MoveInventoryItem(chosenInventoryItem));
    }

    public void EquipItem(InventoryItem selectedItem)
    {
        currentItem = selectedItem;
    }

    public Transform GetInventorySlotPosition(int slotIndex)
    {
        return inventorySlotPosition[slotIndex];
    }
    IEnumerator MoveInventoryItem(InventoryItem chosenInventoryItem)
    {
        currentGameObject = chosenInventoryItem.gameObject;
        while (chosenInventoryItem == currentItem)
        {
            currentItem.gameObject.layer = 0;
            Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out RaycastHit hit, 500f, layersToRay))
            {
                itemTargetPosition = hit.point;
            }

            currentItem.gameObject.transform.position = Vector3.MoveTowards(currentItem.gameObject.transform.position, itemTargetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        chosenInventoryItem.gameObject.layer = 11;
        resetInventorySlotPosition(chosenInventoryItem);
    }

    public void resetInventorySlotPosition(InventoryItem itemToReset)
    {
        itemToReset.transform.position = inventorySlotPosition[itemToReset.currentSlotInInventory].position;
    }

    public void SetCurrentItemSlotID(int itemSlotID)
    {
        currentItemSlotID = itemSlotID;
    }
}
