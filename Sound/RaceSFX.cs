using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip loseSound;

    private bool hasPlayedWin = false;
    private bool hasPlayedLose = false;

    void Update()
    {
        if (TopDownRace.GameControl.m_Current.m_WonRace && !hasPlayedWin)
        {
            audioSource.PlayOneShot(winSound);
            hasPlayedWin = true;
        }

        if (TopDownRace.GameControl.m_Current.m_LostRace && !hasPlayedLose)
        {
            audioSource.PlayOneShot(loseSound);
            hasPlayedLose = true;
        }
    }

}
