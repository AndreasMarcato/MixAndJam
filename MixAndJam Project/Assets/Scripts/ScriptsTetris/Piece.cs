using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // we will be using just one piece through the entire game 
    // we just reinitialize it 

    // declaring the variables as properties
    public Board board { get; private set; }
    public TetrominoData data { get; private set; }
    public Vector3Int position { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public int rotationIndex { get; private set; }


    // rate for the pieces to fall down:
    public float stepDelay = 1f;
    public float lockDelay = 0.5f;


    private float stepTime;
    private float lockTime;




    // variables for swipe:
    Vector2 swipeStart;
    Vector2 swipeEnd;
    float minimumDistance = 10;

    public static event System.Action<SwipeDirection> OnSwipe = delegate { };
    public enum SwipeDirection
    {
        Up, Down, Left, Right
    };



    // spawn position, and the data ew want to use while this piece is active, and a reference to our gameboard:
    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;
        this.rotationIndex = 0;

        // access the current time of the game:
        this.stepTime = Time.time + this.stepDelay;
        this.lockTime = 0f;

        // if the array is nor initialized:
        if (this.cells == null)
        {
            this.cells = new Vector3Int[data.cells.Length];
        }

        // populating the array with the copy of the cells:
        for (int i = 0; i < data.cells.Length; i++)
        {
            this.cells[i] = (Vector3Int)data.cells[i];
        }

    }




    // Start is called before the first frame update
    void Start()
    {

    }







    // handle player input:
    // Update is called once per frame
    void Update()
    {
        this.board.Clear(this);

        // deltaTime is the time it has passed since the last frame is rendered
        this.lockTime += Time.deltaTime;




        // swipe simulation:
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                swipeEnd = touch.position;
                ProcessSwipe();
            }
        }







        // rotation in either direction:
        // if you think about the rotation as an array
        // when you call rotate, you are saying shift down/up an index (int)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotate(-1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate(1);
        }

      
        /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            coordinates = Input.GetTouch(0).position;
            if(coordinates.x==0 && coordinates.y==0)
                Rotate(1);
      
            Rotate(1);
        }
        */
        



            // movement direction whenever you press certain letters
            if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2Int.down);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HardDrop();
        }



        if (Time.time >= this.stepTime)
        {
            Step();
        }



        // reset the piesce when we are done with the movement
        this.board.Set(this);

    }



    private void Step()
    {
        this.stepTime = Time.time + this.stepDelay;
        Move(Vector2Int.down);

        if (this.lockTime >= this.lockDelay)
        {
            Lock();
        }
    }


    // locks in place:
    private void Lock()
    {
        this.board.Set(this);
        this.board.ClearLines();
        // spawning a new piece:
        this.board.SpawnPiece();
    }



    private void HardDrop()
    {
        // conituasly moving down, until we cannot move down any furder:
        while (Move(Vector2Int.down))
        {
            continue;
        }

        Lock();
    }


    // bool type for the functon to see whether or not the move succeeded
    private bool Move(Vector2Int translation)
    {
        //to move this amount in the x and this in the y:
        // we need to validate if the position you want to move to is not outside the borders
        // or it's not inside other piece:

        // calculating what that position would be:
        Vector3Int newPosition = this.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;

        // validaing our new position:
        // we need to comunicate back to the board

        bool valid = this.board.IsValidPosition(this, newPosition);

        if (valid)
        {
            this.position = newPosition;
            this.lockTime = 0f;
        }

        return valid;
    }




    public void Rotate(int direction)
    {
        //storing our current rotation, so if the rotation fails, we can revert back:
        int originalRotation = this.rotationIndex;
        this.rotationIndex = Wrap(this.rotationIndex + direction, 0, 4);
        // applying the rotation to each cell:
        // rotating the coppies:
        ApplyRotationMatrix(direction);

        if (!TestWallKicks(rotationIndex, direction))
        {
            this.rotationIndex = originalRotation;
            ApplyRotationMatrix(-direction);
        }
        {

        }
    }



    private void ApplyRotationMatrix(int direction)
    {
        for (int i = 0; i < this.cells.Length; i++)
        {
            Vector3 cell = this.cells[i];
            // x and y will become the new coordinates after it has been rotated:
            int x, y;

            // I and O are rotated a little bit different:
            switch (this.data.tetromino)
            {
                case Tetromino.I:
                case Tetromino.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt((cell.x * Data.RotationMatrix[0] * direction) + (cell.y * Data.RotationMatrix[1] * direction));
                    y = Mathf.CeilToInt((cell.x * Data.RotationMatrix[2] * direction) + (cell.y * Data.RotationMatrix[3] * direction));
                    break;
                //for every other case:
                default:
                    // using matrices from linear algebra:
                    x = Mathf.RoundToInt((cell.x * Data.RotationMatrix[0] * direction) + (cell.y * Data.RotationMatrix[1] * direction));
                    y = Mathf.RoundToInt((cell.x * Data.RotationMatrix[2] * direction) + (cell.y * Data.RotationMatrix[3] * direction));
                    break;
            }

            this.cells[i] = new Vector3Int(x, y, 0);

        }
    }





    // test if we run into walls:
    private bool TestWallKicks(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = GetWallKickIndex(rotationIndex, rotationDirection);

        for (int i = 0; i < this.data.wallKicks.GetLength(1); i++)
        {
            // each of these tests is defining a translation/movement:
            Vector2Int translation = this.data.wallKicks[wallKickIndex, i];
            if (Move(translation))
            {
                return true;
            }

        }

        return false;
    }


    // test from which to which index you are rotating to:
    private int GetWallKickIndex(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = rotationIndex * 2;

        if (rotationDirection < 0)
        {
            wallKickIndex--;

        }

        return Wrap(wallKickIndex, 0, this.data.wallKicks.GetLength(0));
    }



    // make sure you don't go out of bounds:
    private int Wrap(int input, int min, int max)
    {
        if (input < min)
        {
            return max - (min - input) % (max - min);
        }
        else
        {
            return min + (input - min) % (max - min);
        }
    }






    void ProcessSwipe()
    {
        float distance = Vector2.Distance(swipeStart, swipeEnd);
        if (swipeStart.x == swipeEnd.x)
            Rotate(1);
        else if (distance > minimumDistance)
        {
            if (IsVerticalSwipe())
            {
                if (swipeEnd.y > swipeStart.y)
                {
                    //OnSwipe(SwipeDirection.Up);
                    Debug.Log("up");
                }
                else
                {
                    HardDrop();
                    Debug.Log("down");
                }
            }
            else // horizontal
            {
                if (swipeEnd.x > swipeStart.x)
                {
                    Move(Vector2Int.right);
                    Debug.Log("right");
                }
                else
                {
                    Move(Vector2Int.left);
                    Debug.Log("left");
                }
            }
        }
    }

    bool IsVerticalSwipe()
    {
        float virtical = Mathf.Abs(swipeEnd.y - swipeStart.y);
        float horizontal = Mathf.Abs(swipeEnd.x - swipeStart.x);
        if (virtical > horizontal)
            return true;
        return false;
    }








}
