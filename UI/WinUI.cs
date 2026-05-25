using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TopDownRace
{
    public class WinUI : MonoBehaviour
    {
        public static WinUI m_Current;

        private void Awake()
        {
            m_Current = this;
        }
        void Start()
        {

        }

        void Update()
        {
        }

        public void Restart()
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

        public void Continue()
        {
            SceneManager.LoadScene("Menu");
        }
    }

}