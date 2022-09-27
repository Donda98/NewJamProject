using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class SpotlightSystem : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] Light spotlight;
    [SerializeField] float followSpeed;
    // Start is called before the first frame update

    private void Awake()
    {
        spotlight = GetComponent<Light>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    public void FollowObject()
    {
        Vector3 direction = objectToFollow.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, followSpeed * Time.deltaTime);
    }

    public void Switch()
    {
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
