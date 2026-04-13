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

        bool goingUp = false;
        bool goingRight = false;

        //Right, Down, Left, Up
        if (tile == tileCheck[0])
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
            goingRight = true;
        }

        else if (tile == tileCheck[1])
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
            goingUp = false;
        }

        else if (tile == tileCheck[2])
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
            goingRight = false;
        }

        else if (tile == tileCheck[3])
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
            goingUp = true;
        }



        //Corners

        // Top right corner
        if (tileMap.GetTile(left) && tile == tileCheck[5] && !goingRight)
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
            goingUp = false;
            goingRight = false;

        }

        else if (tileMap.GetTile(down) && tile == tileCheck[5] && goingUp)
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
            goingRight = false;
            goingUp = false;

        }

        // Bottom right corner

        else if (tileMap.GetTile(up) && tile == tileCheck[6] && !goingUp)
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
            goingRight = false;
            goingUp = true;
        }

        else if (tileMap.GetTile(left) && tile == tileCheck[6] && goingRight)
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
            goingUp = true;
            goingRight = false;
        }

        // Bottom left corner

        else if (tileMap.GetTile(right) && tile == tileCheck[7] && !goingRight)
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed));
            goingUp = true;
            goingRight = false;
        }

        else if (tileMap.GetTile(up) && tile == tileCheck[7] && !goingUp)
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
            goingRight = true;
            goingUp = false;
        }

        // Top left corner

        else if (tileMap.GetTile(down) && tile == tileCheck[4] && goingUp)
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
            goingRight = true;
            goingUp = false;
        }

        else if (tileMap.GetTile(right) && tile == tileCheck[4] && !goingRight)
        {
            transform.Translate((Vector3.down * Time.deltaTime * speed));
            goingUp = false;
            goingRight = false;
        }


        Debug.Log("Looking " + tileMap.GetTile(right));
    }
}
