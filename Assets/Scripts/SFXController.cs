using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXController : MonoBehaviour
{
    //  public AudioSource[] clips;
    public AudioSource[] music;
    public float musicVolume = 10f;
    // Start is called before the first frame update

    //  private AudioSource flap;
    // private AudioSource die;
    private AudioSource mainMenuMusic;
    private AudioSource levelOneMusic;

    public static SFXController Instance { get; private set; }

    void Awake()
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
        SceneManager.activeSceneChanged += ChangedActiveScene;
        //  clips = GetComponents<AudioSource>();
        music = GetComponents<AudioSource>();

     //   flap = clips[0];
      //  die = clips[1];
        mainMenuMusic = music[0];
        levelOneMusic = music[1];
        mainMenuMusic.volume = musicVolume;
        levelOneMusic.volume = musicVolume;

        PlayMainMenuMusic();

    }

    //TODO: refactor this garbage code to handle more robust sound management

    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
        mainMenuMusic.loop = true;
    }

    private void StopMainMenuMusic()
    {
        mainMenuMusic.Stop();
    }

    private void StopLevelMusic()
    {
        levelOneMusic.Stop();
    }

    public void playLevelMusic()
    {
        levelOneMusic.Play();
        levelOneMusic.loop = true;

    }


    public void Update()
    {
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
            StopMainMenuMusic();
            playLevelMusic();
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }


}
