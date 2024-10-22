using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField]
    AudioSource mainMenuMusic;
    [SerializeField]
    AudioSource gameMusic;
    [SerializeField, Tooltip("Jump sound effect")]
    AudioSource jumpSound;
    [SerializeField, Tooltip("Victory Sound Effect")]
    AudioSource victorySound;
    
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            if (gameMusic.isPlaying)
            {
                gameMusic.Stop();
            }
            if (!mainMenuMusic.isPlaying)
            {
                mainMenuMusic.Play();
            }
        }
        else
        {
            if (mainMenuMusic.isPlaying)
            {
                mainMenuMusic.Stop();
            }
            if (!gameMusic.isPlaying)
            {
                gameMusic.Play();
            }
        }
    }

    public void PlayJumpSound()
    {
        if (!jumpSound.isPlaying)
        {
            jumpSound.Play();
        }else {
            jumpSound.Stop();
            jumpSound.Play();
        }
    }

    public void PlayVictorySound()
    {
        if (!victorySound.isPlaying)
        {
            //gameMusic.Stop();
            victorySound.Play();
        }
        else
        {
            victorySound.Stop();
            victorySound.Play();
        }
    }
}
