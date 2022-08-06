using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering;

public class DragAndDropPuzzleGame : MonoBehaviour
{
    public GameObject SelectedPiece;
    //int orderInLayer = 0;


    /*
    private bool isDragActive = false;
    // coordinated of our input:
    private Vector2 screenPosition;
    // efective final position:
    private Vector3 worldPosition;
    */




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MOUSE LOGIC:
        // if left mouse button is clicked:
        
        if (Input.GetMouseButtonDown(0))
        {
            // system to detect clicking position:
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

        // for dropping the pieces
        if (Input.GetMouseButtonUp(0))
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
        
        // END MOUSE LOGIC


        /*
        if (isDragActive && (Input.GetMouseButtonDown(0)   ||   (Input.touchCount == 1   &&  Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            //return;
        }



        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            //return;
        }


        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PiecesScriptPuzzleGame>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = true;
                }
                InDrag();
            }
        }
        */



        // TOUCH LOGIC:
        // detecting a single touch:
        /*
        if (Input.touchCount > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PiecesScriptPuzzleGame>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = true;
                }

            }
        }


        if (Input.touchCount == 1  &&  Input.GetTouch(0).phase == TouchPhase.Ended)
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
        */



    }

    /*
    void InDrag()
    {
        isDragActive = true;
    }


    void Drag()
    {
        if (SelectedPiece != null)
        {
            //Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
    }

    void Drop()
    {
        if (SelectedPiece != null)
        {
            SelectedPiece.GetComponent<PiecesScriptPuzzleGame>().Selected = false;
            SelectedPiece = null;

        }
    }
    */

}
