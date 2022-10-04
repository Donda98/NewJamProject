using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheaterAmbience : MonoBehaviour
{
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.sceneAmbience = this;
        sound.volume = GameManager.Instance.generalVolume;
    }

    public void UpdateVolume(float value)
    {
        sound.volume = value;
    }
}
