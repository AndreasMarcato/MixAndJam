using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menuScript_ : MonoBehaviour
{
    public void PlayGame(int LevelNumber)
    {
        PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("Game");
    }
    public void OpenLink(string URL)
    {
        Application.OpenURL(URL);
    }
    public void Quit()
    {
        //Debug.Log('Application Closed!');
        Application.Quit();
    }
}
