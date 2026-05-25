using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace TopDownRace
{

    public class LoseUI : MonoBehaviour
    {


        void Start()
        {

        }

        void Update()
        {

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
        public void BtnExit()
        {

            SceneManager.LoadScene("Menu");
        }

    }

}