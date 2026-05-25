using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSound : MonoBehaviour
{
    public static btnSound instance;

    public AudioSource audioSource;
    public AudioClip clickSound;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void PlayClick()
    {
        if (instance != null)
        {
            instance.audioSource.PlayOneShot(instance.clickSound);
        }
    }
}
