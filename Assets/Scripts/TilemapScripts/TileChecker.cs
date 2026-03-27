using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChecker : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase tileToCheckFor;


    void Update()
    {
        Vector3Int pos = tileMap.WorldToCell(transform.position);

        TileBase tile = tileMap.GetTile(pos);

        if (tile == tileToCheckFor)
        {
            Debug.Log("I detect a desired tile!");
            transform.Translate(Vector3.right * Time.deltaTime);
        }

    }
}
