using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TopWall : Logic
{
    public Button nextButton;



    void OnTriggerEnter2D()
    {
        
        score += 1;
        textScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        if (score == 5)
            WinCondition();

        Respawn();
    }

    void WinCondition()
    {
        //Mirka you can add the scene game to Load here;
        //or if you want to have a few seconds to load the next scene,
        //you can use the Invoke("WinCondition", seconds_to_wait_with_f) on line 13 instead of WinCondition();
        // SceneManager.LoadScene("Scene");              //--Btw the thing down is better
        nextButton.gameObject.SetActive(true);           //--Activate and show the nextButton
        Time.timeScale = 0;                              //--Stop the game once you win
    }

    //--Haha, this whole thing is needed to change scenes
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
