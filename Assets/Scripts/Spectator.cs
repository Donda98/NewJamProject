using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    private float jumpSpeed = 10;
    private float jumpHeight = 1;
    private float jumpDuration = 2;
    private bool reacting;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)&&reacting==false)
        {
            StartCoroutine(Wow());
            print("Urrà!");
        }
     
    }

    private IEnumerator Wow()
    {
        reacting = true;
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.audienceAudio[0]);
        transform.position = transform.position + new Vector3(0, jumpHeight, 0);
        yield return new WaitForSeconds(GameManager.Instance.audienceAudio[0].length);
        transform.position = transform.position - new Vector3(0, jumpHeight, 0);
        reacting = false;
    }
    
}
