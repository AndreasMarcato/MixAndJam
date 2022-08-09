using UnityEngine;
using UnityEngine.Tilemaps;

// refering to the clasic shapes in the game:
public enum Tetromino
{
    I,
    O,
    T,
    J,
    L,
    S,
    Z
}

[System.Serializable]
public struct TetrominoData
{
    public Tetromino tetromino;
    public Tile tile;

    // vector2int, because this is a 2d game using whole numbers (cells):
    //public Vector2Int[] cells;


    // changing it to a field, because we don't need to show them in the editor:
    // initializing getters and setters:
    public Vector2Int[] cells { get; private set; }
    // two dimentional array of positions:
    public Vector2Int[,] wallKicks { get; private set; }

    public void Initialize()
    {
        this.cells = Data.Cells[this.tetromino];
        this.wallKicks = Data.WallKicks[this.tetromino];
    }

}