using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering;

public class DragAndDropPuzzleGame : MonoBehaviour
{
    public GameObject SelectedPiece;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                // if our ray hits an object with the puzzle tag...
                if (hit.transform.CompareTag("Puzzle"))
                {
                    if (!hit.transform.GetComponent<PiecesScriptPuzzleGame>().InRightPosition)
                    {
                        SelectedPiece = hit.transform.gameObject;
                        SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = true;
                    }

                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (SelectedPiece != null)
                {
                    SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = false;
                    SelectedPiece = null;

                }
            }

            if (SelectedPiece != null)
            {
                Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                SelectedPiece.transform.position = new Vector3(touchPoint.x, touchPoint.y, 0);
            }
        }






        // mouse touch simulation
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // if our ray hits an object with the puzzle tag...
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PiecesScriptPuzzleGame>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = true;
                    //SelectedPiece.GetComponent<SortingLayer>
                }

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = false;
                SelectedPiece = null;

            }
        }


        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }



    }



}
