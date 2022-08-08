using UnityEngine;

public class Logic : MonoBehaviour
{
    protected sbyte health = 3;
    protected int score;
    protected float x_pos;
    protected GameObject bullet;
    protected GameObject enemy;

    public void Awake()
    {
        bullet = GameObject.Find("Lasers");
        enemy = GameObject.Find("Enemy");
    }
    
    public void ReSpawn()
    {
        x_pos = Random.Range(-4, 4);
        bullet.transform.localPosition = new Vector3(0, 12, 0);
        enemy.transform.position = new Vector3(x_pos, 7.5f, 0);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 300);
    }
}
