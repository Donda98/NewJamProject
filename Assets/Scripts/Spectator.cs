using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.audience = gameObject;
    }
    
}
