using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    private AudioSource audienceAudio;
    public AudioClip[] audiencePlaylist;
    public float volume;
    private bool areWaiting;

    private void Awake()
    {
        audienceAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        volume = 0.175f;
    }

    private void Update()
    {
        if (areWaiting)
        {
            audienceAudio.volume = Mathf.Lerp(audienceAudio.volume, volume, Time.deltaTime * 2f);
        }
        else
        {
            audienceAudio.volume = Mathf.Lerp(audienceAudio.volume, 0f, Time.deltaTime * 1f);
        }
    }

    public void AudienceReaction()
    {
        areWaiting = true;
        StartCoroutine(Wow());
    }

    public void Chatting()
    {
        areWaiting = true;
        audienceAudio.PlayOneShot(audiencePlaylist[1]);
    }

    public void UpdateVolume()
    {
       volume = GameManager.Instance.generalVolume;
        audienceAudio.volume = volume;    
    }


    public void ShutUP()
    {
        areWaiting = false;
    }
    public IEnumerator Wow()
    {
        audienceAudio.PlayOneShot(audiencePlaylist[0]);
        transform.position = transform.position + new Vector3(0, 1, 0);
        yield return new WaitForSeconds(audiencePlaylist[0].length);
        areWaiting=false;
        transform.position = transform.position - new Vector3(0, 1, 0);
    }
}
