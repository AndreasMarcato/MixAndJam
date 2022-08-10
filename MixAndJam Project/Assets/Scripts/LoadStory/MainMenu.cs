using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1; //..Time works again
        Screen.orientation = ScreenOrientation.LandscapeRight;                //--Force screen orientation
    }

    //--Load next scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGAme()
    {
        Application.Quit();
    }
}
