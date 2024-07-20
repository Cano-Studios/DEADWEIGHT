using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem smoke;
    static private ParticleManager instance;
    static public ParticleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ParticleManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void CreateSmoke(Vector3 position)
    {
        smoke.transform.position = position;
        smoke.Play();
    }
}