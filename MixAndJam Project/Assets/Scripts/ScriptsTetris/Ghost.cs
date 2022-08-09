using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ghost : MonoBehaviour
{
    public Tile tile;
    public Board board;
    public Piece trackingPiece;
    public Tilemap tilemap { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public Vector3Int position { get; private set; }

    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.cells = new Vector3Int[4];
    }

    // function that gets called after all the updates:
    // making sure out ghost piece gets updated after our main piece:
    private void LateUpdate()
    {
        Clear();
        Copy();
        Drop();
        Set();
    }

    private void Clear()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int tilePosition = this.cells[i] + this.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    private void Copy()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            this.cells[i] = this.trackingPiece.cells[i];
        }
    }

    private void Drop()
    {
        Vector3Int position = this.trackingPiece.position;

        // current row
        int current = position.y;
        // bottom of the board:
        // the positions ate in the middle of the board, so we need to get half of that 
        // - -> so it puts us towards the bottom:
        int bottom = -this.board.boardSize.y / 2 - 1;

        board.Clear(trackingPiece);

        // looping through whereever our piece is to the bottom:
        // simulating drop
        for (int row = current; row >= bottom; row--)
        {
            position.y = row;

            if (this.board.IsValidPosition(this.trackingPiece, position))
            {
                // updating our ghost piece to that position
                this.position = position;
            }
            else
            {
                break;
            }
        }

        board.Set(trackingPiece);
    }

    private void Set()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int tilePosition = this.cells[i] + this.position;
            tilemap.SetTile(tilePosition, this.tile);
        }
    }

}
