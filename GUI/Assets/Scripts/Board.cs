using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private bool[,] board;

    public Board()
    {
        board = new bool[15, 15];
        for(int x=0;x<15;x++)
            for(int y=0;y<15;y++)
                board[x, y] = true; // true means that the board is empty, false means that the board has tiles
    }

    public void setBoard(int x,int y,bool value)
    {
        board[x, y] = value;
    }

    public bool getBoard(int x,int y)
    {
        return board[x, y];
    }
}
