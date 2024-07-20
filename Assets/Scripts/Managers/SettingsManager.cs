using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    GameObject settingsPanel;
    
    private static SettingsManager instance;
    public static SettingsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SettingsManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        settingsPanel.GetComponentInChildren<Slider>().value = AudioListener.volume;
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
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
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                settingsPanel.SetActive(false);
                Time.timeScale = 1;   
            }
            else
            {
                settingsPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void OnVolumeChange()
    {
        AudioListener.volume = settingsPanel.GetComponentInChildren<Slider>().value;
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
        #endif
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }
}
