using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopWall : Logic
{
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
        SceneManager.LoadScene("Scene");
    }
}
