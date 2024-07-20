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
}
