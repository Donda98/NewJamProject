using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesManager : MonoBehaviour
{
    public static CitiesManager Instance;
    [SerializeField] GameObject[] cities;
    private Coroutine cor;
    private int currentcity = -1;
    [SerializeField] float maxTranslation=10;
    [SerializeField] float speed;
    [SerializeField] float secondsToGoBack=3;
    float startTranslation;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
    public void ShowCity()
    {
        currentcity += 1;
        if (cor != null)
        {
            StopCoroutine(cor);
        }
        startTranslation = cities[currentcity].transform.position.y;
        if (currentcity < cities.Length)
        {
            StartCoroutine(ShowCityCoroutine());
        }
    }

    private IEnumerator ShowCityCoroutine()
    {
        Vector3 curPos = cities[currentcity].transform.position;
       
        while (startTranslation - curPos.y < maxTranslation-1)
        {
            curPos = new Vector3(curPos.x, Mathf.Lerp(curPos.y, startTranslation - maxTranslation, speed * Time.deltaTime),curPos.z);
            cities[currentcity].transform.position = curPos;
            yield return null;
        }
        yield return new WaitForSeconds(secondsToGoBack);
        startTranslation = curPos.y;
        StartCoroutine(HideCityCoroutine());

    }

    private IEnumerator HideCityCoroutine()
    {
        Vector3 curPos = cities[currentcity].transform.position;

        while (curPos.y - startTranslation < maxTranslation-1)
        {
            curPos = new Vector3(curPos.x, Mathf.Lerp(curPos.y, startTranslation + maxTranslation, speed * Time.deltaTime), curPos.z);
            cities[currentcity].transform.position = curPos;
            yield return null;
        }

    }

}
