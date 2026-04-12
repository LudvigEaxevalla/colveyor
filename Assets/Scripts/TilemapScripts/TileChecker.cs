using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChecker : MonoBehaviour
{
    public Tilemap tileMap;
    public List<TileBase> tileCheck;
    private int tileIndex = -1;


    void Update()
    {
        Vector3Int pos = tileMap.WorldToCell(transform.position);

        TileBase tile = tileMap.GetTile(pos);
    }


    void GetDirection(Vector3Int pos)
    {
        if (tileMap == null) return;
        if (tileCheck == null) return;
    }
}
