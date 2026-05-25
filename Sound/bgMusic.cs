using UnityEngine;
using UnityEngine.SceneManagement;

public class bgMusic : MonoBehaviour
{
    public static bgMusic instance;

    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // 🔥 AUTO AMBIL AUDIO SOURCE (biar tidak error)
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusicIfNeeded();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicIfNeeded();
    }

    void PlayMusicIfNeeded()
    {
        if (audioSource == null) return; // 🔥 anti crash

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Menu" || sceneName == "MainMenu")
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}