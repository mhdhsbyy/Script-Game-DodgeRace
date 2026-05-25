using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPause = false;

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void BtnRestart()
    {
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.DeleteKey("HasSave");
        PlayerPrefs.DeleteKey("FinishedLaps");
        PlayerPrefs.DeleteKey("CarCount");

        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.DeleteKey("CarX_" + i);
            PlayerPrefs.DeleteKey("CarY_" + i);
            PlayerPrefs.DeleteKey("CarZ_" + i);
            PlayerPrefs.DeleteKey("CarRotZ_" + i);

            PlayerPrefs.DeleteKey("RivalWaypoint_" + i);
            PlayerPrefs.DeleteKey("RivalLaps_" + i);
            PlayerPrefs.DeleteKey("PlayerCheckpoint_" + i);
        }

        PlayerPrefs.Save();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) {
                Resume();
                Time.timeScale = 1f;
            } else {
                Pause();
            }
        }
    }
}
