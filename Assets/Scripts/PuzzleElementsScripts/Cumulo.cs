using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cumulo : PuzzleElement
{
    [SerializeField] Cumulo[] altriCumuli = { null, null };
    [SerializeField] GameObject robot;
    int cumuliRestanti;

    private void Awake()
    {
        cumuliRestanti = altriCumuli.Length;
    }

    public override void CustomOnClickAction(Inventory playerInventory)
    {
        print("I cumuli");
        if(cumuliRestanti == 0)
        {
           GameObject spawnRobot = Instantiate(robot, this.transform.position, Quaternion.identity);
           playerInventory.FreeInventorySlot();
        }
        else
        {
            for (int i = 0; i < altriCumuli.Length; i++)
            {
                altriCumuli[i].riduciNumeroCumuli();
            }
        }
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.interactClips[0],2.5f);
        Destroy(this.gameObject);
    }

    public void riduciNumeroCumuli()
    {
        cumuliRestanti--;
    }
}
