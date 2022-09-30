using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas Instance;
    [SerializeField] private GameObject[] menuPages;
    [SerializeField] private GameObject volumeSlide;
    [SerializeField] private GameObject language;
    [SerializeField] private GameObject background;
    [SerializeField] private TMP_Text[] textContent;
    public bool isPaused;
    public bool isOnMenu;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
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
        GameManager.Instance.canvas = this.GetComponent<MainCanvas>();
        FindAllResolutions();
        ShowMenu();
        GetComponent<Canvas>().worldCamera = GameManager.Instance.playerCAM;
    }

    void Update()
    {
        
    }

    public void ShowMenu()
    {
        if (isPaused)
        {
            menuPages[0].SetActive(false);      //Main menù
            menuPages[1].SetActive(false);      //Options 
            menuPages[2].SetActive(false);      //Credits
            menuPages[3].SetActive(true);       //PauseMenu
        }
        else
        {
            menuPages[0].SetActive(true);       //Main menù
            menuPages[1].SetActive(false);      //Options 
            menuPages[2].SetActive(false);      //Credits
            menuPages[3].SetActive(false);      //PauseMenu
            isOnMenu = true;
            isPaused = false;
            background.SetActive(false);
        }
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);

    }
    public void ShowOptions()
    {
        if (isPaused == true)
        {
            background.SetActive(true);
        }
        else
        {
            background.SetActive(false);
        }
        menuPages[0].SetActive(false);      //Main menù
        menuPages[1].SetActive(true);       //Options 
        menuPages[2].SetActive(false);      //Credits
        menuPages[3].SetActive(false);      //PauseMenu
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);

    }
    public void ShowCredits()
    {
        menuPages[0].SetActive(false);      //Main menù
        menuPages[1].SetActive(false);      //Options 
        menuPages[2].SetActive(true);       //Credits
        menuPages[3].SetActive(false);      //PauseMenu
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);

    }

    public void HideMenu()
    {
        menuPages[0].SetActive(false);      //Main menù
        menuPages[1].SetActive(false);      //Options 
        menuPages[2].SetActive(false);      //Credits
        menuPages[3].SetActive(false);      //PauseMenu
        isOnMenu = false;
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
        GameManager.Instance.StartAct(1);
    }

    public void ShowPauseMenu()
    {
        menuPages[0].SetActive(false);      //Main menù
        menuPages[1].SetActive(false);      //Options 
        menuPages[2].SetActive(false);      //Credits
        menuPages[3].SetActive(true);       //PauseMenu
        background.SetActive(true);
        isPaused = true;
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
    }
    public void ResumeGame()
    {
        menuPages[0].SetActive(false);      //Main menù
        menuPages[1].SetActive(false);      //Options 
        menuPages[2].SetActive(false);      //Credits
        menuPages[3].SetActive(false);      //PauseMenu
        isPaused = false;
        background.SetActive(false);
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
    }

    public void BackToMenu()
    {
        menuPages[0].SetActive(true);       //Main menù
        menuPages[1].SetActive(false);      //Options 
        menuPages[2].SetActive(false);      //Credits
        menuPages[3].SetActive(false);      //PauseMenu
        isOnMenu = true;
        isPaused = false;
        background.SetActive(false);
        GameManager.Instance.LoadMenu();
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
    }
    public void SetVolume()
    {
        GameManager.Instance.mixerAudio.volume = volumeSlide.GetComponent<Slider>().value;
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
    }

    public void SetLanguage()
    {
         int idioma = language.GetComponent<TMP_Dropdown>().value;
        GameManager.Instance.language = idioma;
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
        switch (idioma)
        {
            case 0:
                textContent[0].text = "Start";
                textContent[1].text = "Options";
                textContent[2].text = "Credits";
                textContent[3].text = "Quit";
                textContent[4].text = "Volume";
                textContent[5].text = "Language";
                textContent[6].text = "Fullscreen";
                textContent[7].text = "Resolution";
                textContent[8].text = "Return";
                textContent[9].text = "Return";
                textContent[10].text = "Resume";
                textContent[11].text = "Options";
                textContent[12].text = "Back to menu";
                break;

            case 1:
                textContent[0].text = "Inizia";
                textContent[1].text = "Opzioni";
                textContent[2].text = "Crediti";
                textContent[3].text = "Esci";
                textContent[4].text = "Volume";
                textContent[5].text = "Lingua";
                textContent[6].text = "Schermo Intero";
                textContent[7].text = "Risoluzione";
                textContent[8].text = "Indietro";
                textContent[9].text = "Indietro";
                textContent[10].text = "Riprendi";
                textContent[11].text = "Opzioni";
                textContent[12].text = "Torna al menù";
                break;

            case 2:
                textContent[0].text = "Empezar";
                textContent[1].text = "Opciones";
                textContent[2].text = "Créditos";
                textContent[3].text = "Salir";
                textContent[4].text = "Volumen";
                textContent[5].text = "Lenguas";
                textContent[6].text = "Pantalla completa";
                textContent[7].text = "Resolución";
                textContent[8].text = "Retornar";
                textContent[9].text = "Retornar";
                textContent[10].text = "Continuar";
                textContent[11].text = "Opciones";
                textContent[12].text = "Vuelve al menú";
                break;
        }

    }

    public void ExitGame()
    {
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
        GameManager.Instance.QuitGame();
    }

    public void FindAllResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}