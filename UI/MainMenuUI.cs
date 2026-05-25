using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TopDownRace.ScriptableObjects;
namespace TopDownRace
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField, Space]
        private DataStorage m_DataStorage;

        [SerializeField, Space]
        private GameplayData m_GameplayData;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }

        public void BtnExit(string namaScene)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(namaScene);
        }

        public void BtnLevel(int num)
        {
            m_GameplayData.LevelNumber = num;

            string sceneName = "";

            switch (num)
            {
                case 0:
                    sceneName = "Forest";
                    break;

                case 1:
                    sceneName = "Desert";
                    break;

                case 2:
                    sceneName = "Snow";
                    break;
            }

            // simpan track terakhir
            PlayerPrefs.SetString("LastScene", sceneName);
            PlayerPrefs.Save();

            Time.timeScale = 1f;
            // masuk ke track
            SceneManager.LoadScene(sceneName);
        }
    }
}