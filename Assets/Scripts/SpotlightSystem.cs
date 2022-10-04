using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[RequireComponent(typeof(Light))]
public class SpotlightSystem : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] HDAdditionalLightData spotlight;
    [SerializeField] float followSpeed;
    [SerializeField] float maxIntensity;
    [SerializeField] float fadeSpeed;
    private SiparioBehaviour sipario;
    public bool shouldFadeIn=true;

    private void Awake()
    {

    }
    void Start()
    {
        sipario = FindObjectOfType<SiparioBehaviour>();
        sipario.spotLight = this;
        spotlight = GetComponent<Light>().GetComponent<HDAdditionalLightData>();
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

    public void FadeLight()
    {
        print("call fade");
        if (shouldFadeIn)
        {
            StartCoroutine(FadeInLight());
            shouldFadeIn = false;
        }
        else
        {
            StartCoroutine(FadeOutLight());
            shouldFadeIn = false;
        }
    }
    private IEnumerator FadeInLight()
    {
        while (spotlight.intensity < maxIntensity-1)
        {
            spotlight.intensity = Mathf.Lerp(spotlight.intensity, maxIntensity, fadeSpeed * Time.deltaTime);
            yield return null;
        }

    }

    private IEnumerator FadeOutLight()
    {
        while (spotlight.intensity > 1)
        {
            spotlight.intensity = Mathf.Lerp(spotlight.intensity, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
