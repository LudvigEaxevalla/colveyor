using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChecker : MonoBehaviour
{
    public Tilemap tileMap;
    public List<TileBase> tileCheck;
    private int tileIndex;
    int speed = 3;


    void Update()
    {
        Vector3Int pos = tileMap.WorldToCell(transform.position);

        GetDirection(pos, speed);
    }


    void GetDirection(Vector3Int pos, int speed)
    {

        TileBase tile = tileMap.GetTile(pos);
        if (tileMap == null) return;
        if (tileCheck == null) return;

        Vector3Int left = pos + new Vector3Int(-1, 0, 0);
        Vector3Int right = pos + new Vector3Int(1, 0, 0);
        Vector3Int up = pos + new Vector3Int(0, 1, 0);
        Vector3Int down = pos + new Vector3Int(0, -1, 0);

        int tRight = 0;
        int tDown = 1;
        int tLeft = 2;
        int tUp = 3;

        int TL = 4;
        int TR = 5;
        int BR = 6;
        int BL = 7;

        //Right, Down, Left, Up
        if (tile == tileCheck[tRight])
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        else if (tile == tileCheck[tDown])
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
        }

        else if (tile == tileCheck[tLeft])
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
        }

        else if (tile == tileCheck[tUp])
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
        }



        //Corners

        // Top right corner
        if (tileMap.GetTile(left) == tileCheck[tRight] && tile == tileCheck[TR] || tileMap.GetTile(down) == tileCheck[BL] && tileCheck[TR])
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));

        }

        else if (tileMap.GetTile(down) == tileCheck[tUp] && tile == tileCheck[TR] || tileMap.GetTile(down) == tileCheck[BL] && tile == tileCheck[TR] && tileMap.GetTile(left) == tileCheck[tLeft])
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));

        }

        // Bottom right corner

        else if (tileMap.GetTile(up) == tileCheck[tDown] && tile == tileCheck[BR] || tileMap.GetTile(up) == tileCheck[TL] && tile == tileCheck[BR] && tileMap.GetTile(left) == tileCheck[tLeft])
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
        }

        else if (tileMap.GetTile(left) == tileCheck[tRight] && tile == tileCheck[BR])
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
        }

        // Bottom left corner

        else if (tileMap.GetTile(right) == tileCheck[tLeft] && tile == tileCheck[BL] || tileMap.GetTile(up) == tileCheck[TR] && tile == tileCheck[BL])
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
        }

        else if (tileMap.GetTile(up)  == tileCheck[tDown] && tile == tileCheck[BL])
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        // Top left corner

        else if (tileMap.GetTile(down) == tileCheck[tUp] && tile == tileCheck[TL] || tileMap.GetTile(down) == tileCheck[BR] && tile == tileCheck[TL] && tileMap.GetTile(right) == tileCheck[tRight])
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        else if (tileMap.GetTile(right) == tileCheck[tLeft] && tile == tileCheck[TL])
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
        }
    }
}
