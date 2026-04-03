using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] Tilemap currentTilemap;
    public List<TileBase> tileRules = new();
    private int currentTileIndex = 0;
    public bool placingConveyor;
    public bool placingColorHouse;
    public CursorManager cursor;

    [SerializeField] Camera cam;


    private void Update()
    {

        if (placingConveyor)
        {
            PlacingConveyor();
        }

        if (placingColorHouse)
        {
            PlacingColorHouse();
        }

    }

    void PlacingConveyor()
    {
        Vector3Int pos = currentTilemap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentTileIndex = (currentTileIndex + 1) % tileRules.Count;
            if (!cursor.placeHighlight.flipX)
            {
                cursor.placeHighlight.flipX = true;
            }
            else
            {
                cursor.placeHighlight.flipX = false;
            }
        }

        if (Input.GetMouseButton(0))
        {
            PlaceTile(pos);
        }
        if (Input.GetMouseButton(1))
        {
            DeleteTile(pos);
        }



    }


    void PlacingColorHouse()
    {
        Vector3Int pos = currentTilemap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            PlaceTile(pos);
        }
        if (Input.GetMouseButtonDown(1))
        {
            DeleteTile(pos);
        }
    }

    void PlaceTile(Vector3Int pos)
    {
        currentTilemap.SetTile(pos, tileRules[currentTileIndex]);
    }

    void DeleteTile(Vector3Int pos)
    {
        currentTilemap.SetTile(pos, null);
    }

}
