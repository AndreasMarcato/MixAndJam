using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    protected int health, score, highScore;
    protected float x_pos;
    protected GameObject bullet, enemy, ship, textScore, textHealth;

    public void Update()
    {
        Debug.Log(score);
    }
    public void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;                //--Force Screen orientation important
        DataInit();
        Rerender();
    }

    public void DataInit(){
        score = 0;
        health = 4;
        textHealth = GameObject.Find("HealthText");
        textScore = GameObject.Find("ScoreText");
        bullet = GameObject.Find("Lasers");
        enemy = GameObject.Find("Enemy");
        ship = GameObject.Find("Spaceship");
        highScore = PlayerPrefs.GetInt("highscore", 0);
        //Debug.Log("Initialized");
        textScore.GetComponent<TextMeshProUGUI>().text = score.ToString();


        
    }
    
    public void Respawn()
    {
        //Debug.Log("Respawn");
        bullet.GetComponent<SpriteRenderer>().flipX = false;
        Rerender();
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        x_pos = Random.Range(-4, 4);
        bullet.transform.localPosition = new Vector3(0, 12, 0);
        enemy.transform.position = new Vector3(x_pos, 7.5f, 0);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 300);
    }
    public void TakeDamage()
    {
        health -= 1;
        //Debug.Log("-1 Health" + health);
        //Debug.Log(score);
        if (health == 0)
        {
            Lose();
            //Debug.Log("Lose");
        }
    }
    public void Lose()
    {
        Restart();
        PlayerPrefs.SetInt("highscore", score);
        //Debug.Log("New HighScore");
       
        //get current scene name an reload it after
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void Restart()
    {
        //Debug.Log("Restart");
        health = 3;
        //Debug.Log("Health 3");
        // score = 0;
        //Debug.Log("Score 0");
        Respawn();
    }
    public void Rerender()
    {
        //Debug.Log("Rerender");
        
        //Debug.Log(score + " score rendered");
        textHealth.GetComponent<TextMeshProUGUI>().text = health.ToString();
        //Debug.Log(health + " health rendered");
    }
}
