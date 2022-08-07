using UnityEngine;

public class RandomStart : MonoBehaviour
{
    private float x_pos;
    void Start()
    {
        x_pos = Random.Range(-4, 4);
        RandomSpawn();
    }

    public void RandomSpawn(){
        transform.Translate(x_pos, 0, 0);
    }
}
