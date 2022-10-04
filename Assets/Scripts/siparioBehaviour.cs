using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiparioBehaviour : MonoBehaviour
{
    public static SiparioBehaviour Instance;
    [SerializeField] private SkinnedMeshRenderer tende;
    [SerializeField] private MainCanvas canvas;
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
                ApriSipario(sceneToLoad);
                break;
            case 1:
                CalaSipario();
                break;
            default:
                if (canvas.isPaused||canvas.isOnMenu)
                {
                    tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 0f, speed * Time.deltaTime));
                   // lightTeatro.intensity = Mathf.Lerp(lightTeatro.intensity, 20000f, speed * 0.8f * Time.deltaTime);
                }
                else
                {
                    tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), 100f, speed * Time.deltaTime));
                   // lightTeatro.intensity = Mathf.Lerp(lightTeatro.intensity, 0f, speed * 0.8f * Time.deltaTime);
                }
                break;
        }
    }
    void ApriSipario(int x)
    {
        if (sceneIsLoaded)
        {
            if (sceneToLoad == 0)
            {
                instructions = 3;
                sceneIsLoaded = false;
            }
            else
            {
                //print("Apro il sipario");
                tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), targetAperture, speed * Time.deltaTime));
                if (tende.GetBlendShapeWeight(0) >= targetAperture - 1f)
                {
                    tende.SetBlendShapeWeight(0, 100f);
                    instructions = 3;
                    sceneIsLoaded = false;
                   // print("Sipario Aperto");
                }
            }
            
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
            sceneIsLoaded = true;
            targetAperture = 100f;
          //  print("Ho caricato la nuova Scena");
        }
    }
    
    void CalaSipario()
    {
       // print("Calo il sipario");
        targetAperture = 0f;
        if (tende.GetBlendShapeWeight(0) <= targetAperture+1f)
        {
            tende.SetBlendShapeWeight(0, 0f);
            sceneIsLoaded = false;
            instructions = 0;
            //print("Sipario CALATO");
        }
        else
        {
            tende.SetBlendShapeWeight(0, Mathf.Lerp(tende.GetBlendShapeWeight(0), targetAperture, speed * Time.deltaTime));
        }
    }
}
