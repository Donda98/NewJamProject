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
    public bool isPaused;
    public bool isOnMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GameManager.Instance.canvas = this.GetComponent<MainCanvas>();
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
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
        GameManager.Instance.language = language.GetComponent<TMP_Dropdown>().value;
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
    }

    public void ExitGame()
    {
        GameManager.Instance.mixerAudio.PlayOneShot(GameManager.Instance.UIAudio[2]);
        GameManager.Instance.QuitGame();
    }
}