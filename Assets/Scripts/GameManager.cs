using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Texture2D cursorSkin;
    public Camera playerCAM;
    public AudioClip[] audienceAudio;
    public AudioClip[] UIAudio;
    public AudioSource mixerAudio;
    public MainCanvas canvas;
    public GameObject playerInstance;
    public siparioBehaviour sipario;
    public GameObject audience;
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
        sipario.instructions = 1;
        sipario.sceneToLoad = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
    }

    public void AudienceReaction()
    {
        StartCoroutine(Wow());
    }
    public IEnumerator Wow()
    {
        mixerAudio.PlayOneShot(GameManager.Instance.audienceAudio[0]);
        audience.transform.position = audience.transform.position + new Vector3(0, 1, 0);
        yield return new WaitForSeconds(GameManager.Instance.audienceAudio[0].length);
        audience.transform.position = audience.transform.position - new Vector3(0, 1, 0);
    }
}
