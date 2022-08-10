using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //--This if for managment of the Scenes

public class GameController_JumpingGame : MonoBehaviour
{
    //--Load Scene, nothing here yet?

    //--Audio
    public AudioSource audioSource;
    //--Game Over
    public GameObject gameOverScreen;
    //--Pause
    public static bool isPaused;
    //--Winning the game
    public GameObject winScreen;


    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;                  //--Force screen oriantation
        isPaused = false;           //--Game is no longer paused
        pauseGame();                //--Call the pauseGame to continue      Remember, pause can be used to hold the game before starting if needed
        audioSource.Play();         //--Play the song
    }


    //--Pause game happens here
    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0;     //--if game is paused, time doesn't move = pause
            audioSource.Stop();
            //isPaused = false;
        }
        else
        {
            Time.timeScale = 1;     //--if game is NOT paused, time will move again
            //isPaused = true;
        }
    }

    //--GAME OVER Functio is here
    public void GameOver()
    {
        gameOverScreen.SetActive(true); //--If game is over it will show the game over screen
    }

    //--Replay funciton
    public void ReplayJumpingGame()
    {
        SceneManager.LoadScene("02_JumpingGame");   //--This will replay the JumpingGame
    }


    //--Return to Main Menu Button
    public void LoadScene(string sceneName)
    {
        //--When MainMenu button is pressed, MainMenu scene will be loaded
        //--Remember to add object with this code into the button
        //--Name the scene you want to go to there, this time 00_Main_Menu
        SceneManager.LoadScene(sceneName);
        //--Continue button TBM!!                   -----THIS ONE IS NOT DONE!!! MERGE FIRST RIGHT NOW TAKES TO MAIN MENU
                                                    //---GO TO WinPanel to edit this !!!!!!! nothing to be added here for this
    }



    //--This is when you WIN the game
    public void WinScene()
    {
        winScreen.SetActive(true); //--Winning screen is loaded
    }
}
