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
}
