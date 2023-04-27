using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip[] music;
    public AudioSource audioSource;
    public AudioSource sfxSource;
    public Slider sliderMusicVolume;
    public Slider sliderSFXVolume;
    public Toggle sfxToggle;

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

        sliderMusicVolume.value = 0.3f;
        sliderSFXVolume.value = 0.5f;
        sfxToggle.isOn = true;

    }


    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        clips = GetComponents<AudioClip>();
        music = GetComponents<AudioClip>();

        // start at half, we want to write a player config presistence class that holds the player 
        // settings profile and figures out the previous values on game start


    }

    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (sfxToggle.isOn)
            {
                sfxSource.volume = sliderSFXVolume.value;
            }
            else
            {
                sfxSource.volume = 0f;
            }
            audioSource.volume = sliderMusicVolume.value;
        }
       

    }
    //TODO: refactor this garbage code to handle more robust sound management

    public void PlayBackGroundMusic(int track)
    {
        audioSource.clip = music[track];
        audioSource.Play();
        audioSource.loop = true;
    }

    public void StopBackGroundMusic(int track)
    {
        audioSource.Stop();
    }

    public void playSFXClip(int clipNumber)
    {
        sfxSource.clip = clips[clipNumber];
        sfxSource.Play();
        sfxSource.loop = false;
    }


    public void Update()
    {
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            currentName = "Replaced";
            StopBackGroundMusic(current.buildIndex);
            PlayBackGroundMusic(next.buildIndex);
        }

        if(current == next)
        {
            StopBackGroundMusic(current.buildIndex);
            PlayBackGroundMusic(current.buildIndex);
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }


}
