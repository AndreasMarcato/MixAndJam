using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController_JumpingGame : MonoBehaviour
{
    //--Game Over
    public static bool isGameOver;
    public GameObject gameOverScreen;

    //--Pause
    public static bool isPaused;

    //--Load Scene


    private void Awake()
    {
        isGameOver = false;         //--Game is not over so false
        isPaused = false;           //--Game is no longer paused
        pauseGame();                //--Call the pauseGame to continue
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true); //--If game is over it will show the game over screen
        }
    }

    //--Pause game happens here
    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0;     //--if game is paused, time doesn't move = pause
            //isPaused = false;
        }
        else
        {
            Time.timeScale = 1;     //--if game is NOT paused, time will move again
            //isPaused = true;
        }
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
    }

}
