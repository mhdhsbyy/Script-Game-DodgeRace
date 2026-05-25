using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject infopanel;

    // Start is called before the first frame update
    void Start()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton(string namaScene)
    {
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.DeleteKey("HasSave");

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

        PlayerPrefs.DeleteKey("FinishedLaps");
        PlayerPrefs.DeleteKey("CarCount");

        PlayerPrefs.Save();

        Time.timeScale = 1f;
        SceneManager.LoadScene(namaScene);
    }

    public void InfoButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(true);
    }

    public void BackButton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Tombol Keluar Telah Ditekan...");
    }

    public void ContinueButton()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "");
        int hasSave = PlayerPrefs.GetInt("HasSave", 0);

        Debug.Log("HAS SAVE: " + hasSave);
        Debug.Log("LAST SCENE: " + lastScene);

        if (hasSave == 1 && lastScene != "")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.Log("Belum ada save game.");
        }
    }
}
