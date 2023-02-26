using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Toggle toggle;
    public void Start()
    {

        if(PlayerPrefs.GetInt("Muted") == 1)
        {
            toggle.isOn = true;
            AudioListener.pause = true;
        }
        else
        {
            toggle.isOn = false;
            AudioListener.pause = false;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Mute()
    {
        if (!AudioListener.pause)
        {
            PlayerPrefs.SetInt("Muted", 1);
            AudioListener.pause = true;
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            AudioListener.pause = false;
        }
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
