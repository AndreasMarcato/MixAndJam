using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelection_Hub : MonoBehaviour
{
    //--Remember to place right (UI) objects here
    public GameObject showMainMenu;         //--MainMenu
    public GameObject showJumpingGameStart; //--Object where the UI is for starting JumpingGame
    public GameObject showArtCardGameStart; //--ArtCardGame
    public GameObject showPingPongGameStart;
    public GameObject showTetrisGameStart;

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //--If MainMenu tag on trigger, show UI for it
        if (CompareTag("MainMenu"))
        {
            showMainMenu.SetActive(true);
        }

        //--If you are on trigger with JumpingGame Tag, it will show UI where to start
        if (CompareTag("JumpingGame"))
        {
            showJumpingGameStart.SetActive(true);
        }

        //--If ArtPuzzleGame tag on trigger, show UI for it
        if (CompareTag("ArtPuzzleGame"))
        {
            showArtCardGameStart.SetActive(true);
        }

        //-- Ping Pong Game
        if (CompareTag("PingPongGame"))
        {
            showPingPongGameStart.SetActive(true);
        }

        //-- Tetris Game
        if (CompareTag("TetrisGame"))
        {
            showTetrisGameStart.SetActive(true);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //--After we leave OnTrigger area we will close the UI window
        showMainMenu.SetActive(false);
        showJumpingGameStart.SetActive(false);
        showArtCardGameStart.SetActive(false);
        showPingPongGameStart.SetActive(false);
        showTetrisGameStart.SetActive(false);
    }

}
