using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{

    // we need a reference to our tile map in order to draw:
    public Tilemap tilemap { get; private set; }
    // an array of the shape tiles, so we can customize them in the editor:
    public TetrominoData[] tetrominos;
    public Piece activePiece { get; private set; }
    public Vector3Int spawnPosition;

    // defining the border of the board:
    public Vector2Int boardSize = new Vector2Int(10, 20);


    public Text gameOver = null;
    public Text scoreText = null;
    public int score = 0;
    public Text winCondition = null;
    public Button nextButton;




    // defining a bounds as a property:
    // to define, we need the position and the size:
    public RectInt Bounds
    {
        get
        {
            // the position is initially in the center
            // moving the positon to a corner our board
            Vector2Int position = new Vector2Int(-this.boardSize.x/2, -this.boardSize.y/2);
            return new RectInt(position, this.boardSize);
        }
    }



    // spawning the shapes:
    // Awake will be called automaticaly when your component is first initiallized:
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;                //--Force screen orientation
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
        // loop through our list of data and initialize our list:
        for (int i = 0; i < this.tetrominos.Length; i++)
        {
            this.tetrominos[i].Initialize();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        EnableText();
        Invoke("DisableText", 4f);
        SpawnPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void DisableText()
    {
        winCondition.gameObject.SetActive(false);

    }

    private void EnableText()
    {
        winCondition.gameObject.SetActive(true);
    }




    public void SpawnPiece()
    {
        int random = Random.Range(0, this.tetrominos.Length);
        TetrominoData data = this.tetrominos[random];
        // reference to the board -> this:
        this.activePiece.Initialize(this, this.spawnPosition, data);

        if (IsValidPosition(this.activePiece, this.spawnPosition))
        {
            Set(this.activePiece);
        }
        else
        {
            GameOver();
        }

        
    }



    private void GameOver()
    {
        // clearing the whole map:
        //this.tilemap.ClearAllTiles();
        gameOver.gameObject.SetActive(true);
        StartCoroutine(Reload()); 

        // UI gameover menu:
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        //this.tilemap.ClearAllTiles();
        //score = 0;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    // set the pieces:
    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }


    // when we update the position we need to clear the previous piese and call again the set:
    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, null);
        }
    }


    // checking for the position:
    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;

        // we need to test if every individual cell inside that piece is valid
        for (int i = 0; i < piece.cells.Length; i++)
        {
            // getting the tile position for the current cell:
            // we have not yet updated the curent position 
            // so we are using the position we are passing to the method, instead of piece.position
            Vector3Int tilePosition = piece.cells[i] + position;

            // is it out ouf the border
            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            // is the space already ocupied
            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            } 

        }

        // if it loops through all of the cells and it never returns false, the position is valid
        return true;
    }


    // for testing and clearing lines:
    public void ClearLines()
    {
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;

        // from the bottom:
        while(row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
            }
            else
            {
                // we increment the row for test only if the the previous is full and is cleaned:
                row++;
            }
        }

    }

    //is the row full:
    private bool IsLineFull(int row)
    {
        RectInt bounds = this.Bounds;

        // from left to right:
        for  (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            if (!this.tilemap.HasTile(position))
            {
                // if there isn't a tile, than the line is not full
                return false;
            }
        }

        return true;
    }



    // cleaning the lines:
    private void LineClear(int row)
    {
        RectInt bounds = this.Bounds;
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(position, null);
            //score += 50;
            //scoreText.text = score.ToString();
        }
        score += 50;
        scoreText.text = "Score: " + score;


        if (score >= 400)                                         //--When you win the game!!------
        {
            Debug.Log("you win!");
            nextButton.gameObject.SetActive(true);  //--Show next button
        }



        // after clearing the tile, we make every line above this fall down:
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                // row + 1 , because we are grabbing the row above it:
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = this.tilemap.GetTile(position);
                // setting back row to the current:
                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);
            }
            row++;
        }


    }

    //--Load next scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
