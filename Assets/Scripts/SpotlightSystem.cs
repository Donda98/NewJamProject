using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class SpotlightSystem : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] Light spotlight;
    [SerializeField] float followSpeed;

    private void Awake()
    {

    }
    void Start()
    {
        spotlight = GetComponent<Light>();
    // objectToFollow = GameManager.Instance.playerInstance;
        spotlight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            FollowObject();
            if (Input.GetKeyDown("f"))
            {
                Switch();
            }
            if (Input.GetKeyDown("m"))
            {
                ModifyLightIntensity(500);
            }
            if (Input.GetKeyDown("l"))
            {
                ModifyLightIntensity(-500);
            }
        }
    }

    public void FollowObject()
    {
        Vector3 direction = objectToFollow.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, followSpeed * Time.deltaTime);
    }

    public void Switch()
    {
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
        spotlight.enabled = !spotlight.enabled;
    }

    public void ModifyLightIntensity(int intensityIncrease)
    {
        spotlight.intensity += intensityIncrease;
    }

    public void SetLightColor(Color newColor)
    {
        spotlight.color = newColor;
    }


}
