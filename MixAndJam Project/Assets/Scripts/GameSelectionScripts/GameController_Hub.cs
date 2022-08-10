using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController_Hub : MonoBehaviour
{

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;                  //--Force screen oriantation
    }



    //--When adding this to button, remember to name the scene you want to move to
    //--These will move you to the right Scene
    public void LoadMainMenuScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //--This is for loading into JumpingGame Scene
    public void LoadJumpingGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //--This is for loading into Art Puzzle Game Scene
    public void LoadArtPuzzleGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
