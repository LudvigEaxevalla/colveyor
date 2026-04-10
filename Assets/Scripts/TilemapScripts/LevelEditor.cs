using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] Tilemap currentTilemap;
    public TileBase defaultConveyor;
    public List<TileBase> corners = new();
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
        CheckCorner(pos);
        if (Input.GetKeyDown(KeyCode.R))
        {
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
        currentTilemap.SetTile(pos, defaultConveyor);
    }

    void DeleteTile(Vector3Int pos)
    {
        currentTilemap.SetTile(pos, null);
    }

    void CheckCorner(Vector3Int pos)
    {
        Vector3Int topRight = (pos + new Vector3Int(-1, -1, 0));
        Vector3Int topLeft = (pos + new Vector3Int(1, -1, 0));
        Vector3Int bottomRight = (pos + new Vector3Int(-1, 1, 0));
        Vector3Int bottomLeft = (pos + new Vector3Int(1, 1, 0));

        if (currentTilemap.GetTile(topRight) != null)
        {
            Debug.Log("is null");
            currentTilemap.SetTile(pos, corners[0]);


        }
    }

}
