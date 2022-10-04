using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Texture2D cursorSkin;
    public Camera playerCAM;
    public AudioClip[] UIAudio;
    public AudioClip[] interactClips;
    public AudioSource mixerAudio;
    public MainCanvas canvas;
    public GameObject playerInstance;
    public SiparioBehaviour sipario;
    public Spectator audience;
    public TheaterAmbience sceneAmbience;
    public int playerLVL;
    public float generalVolume=0.175f;
    public int language; //0 = Inglese, 1 = Italiano


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
        mixerAudio = gameObject.GetComponent<AudioSource>();
        Cursor.SetCursor(cursorSkin, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartAct(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartAct(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            StartAct(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartAct(4);
        }
    }

    public void UpdateVolume()
    {
        mixerAudio.volume = generalVolume;
        sceneAmbience.UpdateVolume(generalVolume);
    }
    public void StartAct(int x)
    {
        
        sipario.instructions = 1;
        sipario.sceneToLoad = x;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        playerLVL = 0;
        sipario.instructions = 1;
        sipario.sceneToLoad = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }  
}
