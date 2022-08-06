using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScriptPuzzleGame : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;





    /*
    public GameObject background = null;
    private SpriteRenderer sprite = null;
    public Sprite starsBack = null;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = background.GetComponent<SpriteRenderer>();

        Debug.Log("start");
        
        StartCoroutine(Timer(1.5f));
        
        Debug.Log("stop");
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-4f, -3.5f));

    }

    // Update is called once per frame
    void Update()
    {
        // snap system:
        if (Vector3.Distance(transform.position, RightPosition) < 0.3f)
        {
            if (!Selected)
            {
                transform.position = RightPosition;
                InRightPosition = true;
            }
            
        }
        
    }


    private IEnumerator Timer(float seconds)
    {
        Debug.Log("timer start");
        yield return new WaitForSeconds(seconds);
        Debug.Log("timer end");
        //sprite = starsBack;
    }
    */



    void Start()
    {
        
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-4f, -3.5f));

    }

    void Update()
    {
        // snap system:
        if (Vector3.Distance(transform.position, RightPosition) < 0.3f)
        {
            if (!Selected)
            {
                transform.position = RightPosition;
                InRightPosition = true;
            }

        }
    }

}
