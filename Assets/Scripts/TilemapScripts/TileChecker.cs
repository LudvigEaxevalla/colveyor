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

        bool headingLeft = false;
        bool headingRight = false;

        //Right, Down, Left, Up
        if (tile == tileCheck[tRight])
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
            headingRight = true;
            headingLeft = false;
        }

        else if (tile == tileCheck[tDown])
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
        }

        else if (tile == tileCheck[tLeft])
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
            headingRight = false;
            headingLeft = true;
        }

        else if (tile == tileCheck[tUp])
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
        }



        //Corners

        // Top right corner
        if (tileMap.GetTile(left) == tileCheck[tRight] && tile == tileCheck[TR] || 
            tileMap.GetTile(down) == tileCheck[BL] && tileMap.GetTile(left) == tileCheck[tRight] && tile == tileCheck[TR] ||
            tileMap.GetTile(left) == tileCheck[BL] && tile == tileCheck[TR] && headingRight)
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));

        }

        else if (tileMap.GetTile(down) == tileCheck[tUp] && tile == tileCheck[TR] || 
            tileMap.GetTile(down) == tileCheck[BL] && tile == tileCheck[TR] && tileMap.GetTile(left) == tileCheck[tLeft] ||
            tileMap.GetTile(left) == tileCheck[BL] && tile == tileCheck[TR] && headingLeft)
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));

        }

        // Bottom right corner

        else if (tileMap.GetTile(up) == tileCheck[tDown] && tile == tileCheck[BR] || 
            tileMap.GetTile(up) == tileCheck[TL] && tile == tileCheck[BR] && tileMap.GetTile(left) == tileCheck[tLeft] ||
            tileMap.GetTile(left) == tileCheck[TL] && tile == tileCheck[BR] && headingLeft)
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
        }

        else if (tileMap.GetTile(left) == tileCheck[tRight] && tile == tileCheck[BR] || 
            tileMap.GetTile(up) == tileCheck[TL] && tile == tileCheck[BR] && tileMap.GetTile(left) == tileCheck[tRight] ||
            tileMap.GetTile(up) == tileCheck[TL] && tile == tileCheck[BR] && headingRight)
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
        }

        // Bottom left corner

        else if (tileMap.GetTile(right) == tileCheck[tLeft] && tile == tileCheck[BL] || 
            tileMap.GetTile(up) == tileCheck[TR] && tile == tileCheck[BL] && tileMap.GetTile(right) == tileCheck[tLeft] ||
            tileMap.GetTile(up) == tileCheck[TR] && tile == tileCheck[BL] && headingLeft)
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
        }

        else if (tileMap.GetTile(up)  == tileCheck[tDown] && tile == tileCheck[BL] || 
            tileMap.GetTile(right) == tileCheck[tRight] && tile == tileCheck[BL] && tileMap.GetTile(up) == tileCheck[TR] ||
            tileMap.GetTile(right) == tileCheck[TR] && tile == tileCheck[BL] && headingRight) 
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        // Top left corner

        else if (tileMap.GetTile(down) == tileCheck[tUp] && tile == tileCheck[TL] || 
            tileMap.GetTile(down) == tileCheck[BR] && tile == tileCheck[TL] && tileMap.GetTile(right) == tileCheck[tRight] ||
            tileMap.GetTile(right) == tileCheck[BR] && tile == tileCheck[TL] && headingRight)
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        else if (tileMap.GetTile(right) == tileCheck[tLeft] && tile == tileCheck[TL] || 
            tileMap.GetTile(right) == tileCheck[tLeft] && tile == tileCheck[TL] && tileMap.GetTile(down) == tileCheck[BR] ||
            tileMap.GetTile(right) == tileCheck[BR] && tile == tileCheck[TL] && headingLeft)
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
        }
    }
}
