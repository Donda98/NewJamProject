using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiparioBehaviour : MonoBehaviour
{
    public static SiparioBehaviour Instance;
    [SerializeField] private SkinnedMeshRenderer tende;
    [SerializeField] private MainCanvas canvas;
    public float timeToOpenOrClose;
    [SerializeField] private bool hasToClose;
   public SpotlightSystem spotLight;
    private Coroutine cor;
   // [SerializeField] private Light lightTeatro;
    public float speed;
    public int instructions;
    public float targetAperture;
    public int sceneToLoad;
    private bool sceneIsLoaded;
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
        if(GameManager.Instance!=null)
        GameManager.Instance.sipario = this;
    }
    void Start()
    {
        GameManager.Instance.sipario = this;
    }

    private void Update()
    {
        switch (instructions)
        {
            case 0:
                //ApriSipario(sceneToLoad);
                break;
            case 1:
                //CalaSipario();
                break;
            //default:
            //    if (canvas.isPaused || canvas.isOnMenu)
            //    {
            //        tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 0, Mathf.Exp(2)*(-speed * Time.deltaTime)));
            //        // lightTeatro.intensity = Mathf.Lerp(lightTeatro.intensity, 20000f, speed * 0.8f * Time.deltaTime);
            //    }
            //    break;
                //else
                //{
                //    tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 100, Mathf.Exp(2) * (-speed * Time.deltaTime)));
                //    // lightTeatro.intensity = Mathf.Lerp(lightTeatro.intensity, 0f, speed * 0.8f * Time.deltaTime);
                //}
                //break;
        }
    }
    public void ApriSipario()
    {
        cor = StartCoroutine(ApriSiparioCoroutine());
    }
    public IEnumerator ApriSiparioCoroutine()
    {
        //CitiesManager.Instance.ShowCity();
        bool doOnce=false;
        yield return new WaitForSeconds(timeToOpenOrClose);
        while (tende.GetBlendShapeWeight(0) < 100)
        {
            if (!doOnce&& tende.GetBlendShapeWeight(0)>80)
            {
                spotLight.FadeLight();
                doOnce = true;
            }
            if (tende.GetBlendShapeWeight(0) > 99f)
            {
                tende.SetBlendShapeWeight(0, 100);
            }
            tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 100, Mathf.Exp(2) * (speed * Time.deltaTime)));
            yield return null;
        }
        hasToClose = true;
    }

    public IEnumerator ChiudiSiparioCoroutine()
    {
        bool doOnce = false;
        bool doOnce2 = false;
        if (!doOnce)
        {
            spotLight.FadeLight();
            doOnce = true;
        }
        yield return new WaitForSeconds(timeToOpenOrClose);
        while (tende.GetBlendShapeWeight(0) > 2.5)
        {
            print(tende.GetBlendShapeWeight(0));
            if (tende.GetBlendShapeWeight(0) < 2.6f)
            {
                tende.SetBlendShapeWeight(0, 2.5f);
            }
            if(!doOnce2&& tende.GetBlendShapeWeight(0) < 30)
            {
                CitiesManager.Instance.ShowCity();
                doOnce2 = true;
            }
            tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 2, Mathf.Exp(2) * (2*speed * Time.deltaTime)));
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
        cor =StartCoroutine(ApriSiparioCoroutine());

    }


    public IEnumerator ChiudiSiparioPerMenu()
    {
        if (cor != null)
        {
            StopCoroutine(cor);
        }
        
        bool doOnce = false;
        if (!doOnce)
        {
            spotLight.shouldFadeIn = false;
            spotLight.FadeLight();
            doOnce = true;
        }
       
        while (tende.GetBlendShapeWeight(0) > 2.5)
        {
            print(tende.GetBlendShapeWeight(0));
            if (tende.GetBlendShapeWeight(0) < 2.6f)
            {
                tende.SetBlendShapeWeight(0, 2.5f);
            }
            tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 2, Mathf.Exp(2) * (3*speed * Time.deltaTime)));
            yield return null;
        }
        SceneManager.LoadScene(0);
        GameManager.Instance.sipario = this;
        MainCanvas.Instance.menuPages[0].SetActive(true);

    }


    public void ApriSipario(int x)
    {
        if (hasToClose)
        {
            StartCoroutine(ChiudiSiparioCoroutine());
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
            ApriSipario();
        }
    }
    
    void CalaSipario()
    {
        targetAperture = 0f;
        if (tende.GetBlendShapeWeight(0) <= targetAperture+1f)
        {
            tende.SetBlendShapeWeight(0, 0f);
            sceneIsLoaded = false;
            instructions = 0;
        }
        else
        {
            tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), targetAperture, speed * Time.deltaTime));
        }
    }
}
