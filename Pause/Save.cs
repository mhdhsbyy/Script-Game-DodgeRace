using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TopDownRace;

public class Save : MonoBehaviour
{
    public void SavePoint()
    {
        if (GameControl.m_Current == null || GameControl.m_Current.m_Cars == null)
        {
            Debug.Log("GameControl atau data mobil tidak ditemukan saat save.");
            return;
        }

        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

        // SAVE LAP PLAYER / GAME
        PlayerPrefs.SetInt("FinishedLaps", GameControl.m_Current.m_FinishedLaps);

        PlayerPrefs.SetInt("CarCount", GameControl.m_Current.m_Cars.Length);

        for (int i = 0; i < GameControl.m_Current.m_Cars.Length; i++)
        {
            GameObject car = GameControl.m_Current.m_Cars[i];

            if (car != null)
            {
                PlayerPrefs.SetFloat("CarX_" + i, car.transform.position.x);
                PlayerPrefs.SetFloat("CarY_" + i, car.transform.position.y);
                PlayerPrefs.SetFloat("CarZ_" + i, car.transform.position.z);
                PlayerPrefs.SetFloat("CarRotZ_" + i, car.transform.eulerAngles.z);

                Rivals rival = car.GetComponent<Rivals>();
                if (rival != null)
                {
                    PlayerPrefs.SetInt("RivalWaypoint_" + i, rival.m_WaypointsCounter);
                    PlayerPrefs.SetInt("RivalLaps_" + i, rival.m_FinishedLaps);
                }

                PlayerCar player = car.GetComponent<PlayerCar>();
                if (player != null)
                {
                    PlayerPrefs.SetInt("PlayerCheckpoint_" + i, player.m_CurrentCheckpoint);
                }
            }
        }

        PlayerPrefs.SetInt("HasSave", 1);
        PlayerPrefs.Save();

        Debug.Log("Save berhasil. Lap tersimpan: " + GameControl.m_Current.m_FinishedLaps);
    }

    void Start()
    {
        StartCoroutine(LoadPosition());
    }

    IEnumerator LoadPosition()
    {
        yield return new WaitForSeconds(1f);

        if (PlayerPrefs.GetInt("HasSave", 0) != 1)
            yield break;

        if (GameControl.m_Current == null || GameControl.m_Current.m_Cars == null)
        {
            Debug.Log("GameControl atau data mobil tidak ditemukan saat load.");
            yield break;
        }

        // LOAD LAP PLAYER / GAME
        GameControl.m_Current.m_FinishedLaps = PlayerPrefs.GetInt("FinishedLaps", 0);

        int carCount = PlayerPrefs.GetInt("CarCount", 0);

        for (int i = 0; i < carCount && i < GameControl.m_Current.m_Cars.Length; i++)
        {
            GameObject car = GameControl.m_Current.m_Cars[i];

            if (car != null)
            {
                Vector3 savedPos = new Vector3(
                    PlayerPrefs.GetFloat("CarX_" + i),
                    PlayerPrefs.GetFloat("CarY_" + i),
                    PlayerPrefs.GetFloat("CarZ_" + i)
                );

                float rotZ = PlayerPrefs.GetFloat("CarRotZ_" + i);

                car.transform.position = savedPos;
                car.transform.rotation = Quaternion.Euler(0, 0, rotZ);

                Rigidbody2D rb = car.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }

                Rivals rival = car.GetComponent<Rivals>();
                if (rival != null)
                {
                    rival.m_WaypointsCounter = PlayerPrefs.GetInt("RivalWaypoint_" + i, rival.m_WaypointsCounter);
                    rival.m_FinishedLaps = PlayerPrefs.GetInt("RivalLaps_" + i, rival.m_FinishedLaps);
                }

                PlayerCar player = car.GetComponent<PlayerCar>();
                if (player != null)
                {
                    player.m_CurrentCheckpoint = PlayerPrefs.GetInt("PlayerCheckpoint_" + i, player.m_CurrentCheckpoint);
                }
            }
        }

        Debug.Log("Load berhasil. Lap diload: " + GameControl.m_Current.m_FinishedLaps);
    }
}