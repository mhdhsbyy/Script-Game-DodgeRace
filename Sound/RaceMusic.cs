using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceMusic : MonoBehaviour
{
    private static RaceMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
