using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScriptPuzzleGame : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;



    void Start()
    {
        Invoke("CreatingPieces", 6f);


    }

    void Update()
    {
        // snap system:
        if (Vector3.Distance(transform.position, RightPosition) < 0.3f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    if(InRightPosition == true)
                    
                    Camera.main.GetComponent<DragAndDropPuzzleGame>().PlacedPieces++;
                }
            }

        }
    }



    private void CreatingPieces()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-4f, -3.5f));
    }



}
