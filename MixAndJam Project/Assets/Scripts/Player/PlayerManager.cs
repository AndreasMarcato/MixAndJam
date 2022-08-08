using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;
  
    

   

    public static bool isGamePaused;
    public GameObject[] characterPrefabs;



    private void Awake()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject go = Instantiate(characterPrefabs[index], transform.position, Quaternion.identity);
      
    }

    void Start()
    {
      
        Time.timeScale = 1;
        gameOver = isGameStarted = isGamePaused= false;

        
    }

    void Update()
    {
        //Update UI
     

        //Game Over
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        //Start Game
        if (SwipeManager.tap  && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
