using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] Tilemap currentTilemap;
    [SerializeField] Tilemap housetilemap;
    [SerializeField] Tilemap conveyorTilemap;
    public List<TileBase> conDirection;
    [HideInInspector] public int rotationIndex = 0;
    public List<TileBase> corners = new();
    [HideInInspector] public int cornerIndex;
    public List<TileBase> houses;
    public bool placingConveyor;
    public bool placingBuilding;
    public CursorManager cursor;
    [SerializeField] Camera cam;

    public GameObject houseObject;
    public GameObject mixerObject;

    private void Update()
    {
        if (placingConveyor)
            PlacingConveyor();

        if (placingBuilding)
            PlacingBuilding();
    }

    void PlacingConveyor()
    {
        currentTilemap = conveyorTilemap;
        Vector3Int pos = currentTilemap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetKeyDown(KeyCode.R))
        {
            rotationIndex = (rotationIndex + 1) % 4;
        }

        if (Input.GetMouseButton(0))
        {
            PlaceTile(pos);
            CheckAndUpdateArea(pos);
        }
        if (Input.GetMouseButton(1))
        {
            DeleteTile(pos);
            CheckAndUpdateArea(pos);
        }
    }

    void PlacingBuilding()
    {
        currentTilemap = housetilemap;
        Collider2D hit;
        Vector3Int pos = currentTilemap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(pos);
        hit = Physics2D.OverlapPoint(mousePos);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            rotationIndex = (rotationIndex + 1) % 2;
        }

        if (Input.GetMouseButtonDown(0))
            PlaceTile(pos);

        if (Input.GetMouseButtonDown(1))
        {
            DeleteTile(pos);
            if (hit != null)
            {
                if (hit.transform.tag == "building")
                {
                     Destroy(hit.transform.gameObject);
                }
            }
            
        }
      
    }

    void PlaceTile(Vector3Int pos)
    {
        if (currentTilemap == conveyorTilemap)
        {
             currentTilemap.SetTile(pos, conDirection[rotationIndex]);
        }

        else if (currentTilemap == housetilemap)
        {
            currentTilemap.SetTile(pos, houses[rotationIndex]);
            if (rotationIndex == 0)
            {
                GameObject.Instantiate(houseObject, pos, transform.rotation);
            }

            else if (rotationIndex == 1)
            {
                GameObject.Instantiate(mixerObject, pos, transform.rotation);
            }
        }
    }

    void DeleteTile(Vector3Int pos)
    {
        currentTilemap.SetTile(pos, null);
    }

    void CheckAndUpdateArea(Vector3Int pos)
    {
        CheckCorner(pos);
        CheckCorner(pos + new Vector3Int(-1, 0, 0));
        CheckCorner(pos + new Vector3Int(1, 0, 0));
        CheckCorner(pos + new Vector3Int(0, 1, 0));
        CheckCorner(pos + new Vector3Int(0, -1, 0));
    }

    void CheckCorner(Vector3Int pos)
    {
        if (currentTilemap.GetTile(pos) == null) return;

        Vector3Int left = pos + new Vector3Int(-1, 0, 0);
        Vector3Int right = pos + new Vector3Int(1, 0, 0);
        Vector3Int up = pos + new Vector3Int(0, 1, 0);
        Vector3Int down = pos + new Vector3Int(0, -1, 0);

        bool leftEmpty = currentTilemap.GetTile(left) == null;
        bool rightEmpty = currentTilemap.GetTile(right) == null;
        bool upEmpty = currentTilemap.GetTile(up) == null;
        bool downEmpty = currentTilemap.GetTile(down) == null;

        bool isCorner = false;

        if (!leftEmpty && !upEmpty && rightEmpty && downEmpty) { cornerIndex = 0; isCorner = true; } // topleft
        else if (!rightEmpty && !upEmpty && leftEmpty && downEmpty) { cornerIndex = 1; isCorner = true; } // topright
        else if (!leftEmpty && !downEmpty && rightEmpty && upEmpty) { cornerIndex = 2; isCorner = true; } // bottomleft
        else if (!rightEmpty && !downEmpty && leftEmpty && upEmpty) { cornerIndex = 3; isCorner = true; } // bottomright

        if (isCorner)
            currentTilemap.SetTile(pos, corners[cornerIndex]);
        else
            currentTilemap.SetTile(pos, conDirection[rotationIndex]); 
    }
}