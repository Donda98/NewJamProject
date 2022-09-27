using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioClip[] audienceAudio;
    public AudioClip[] UIAudio;

    public AudioSource mixerAudio;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if(Instance != null)
        {
            Destroy(this);
        }
    }
    
    void Start()
    {
        mixerAudio = gameObject.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        
    }
}
