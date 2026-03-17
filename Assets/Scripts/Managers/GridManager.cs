using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public int width, height;
    public static GridManager instance;

    [SerializeField] private Tile tileprefab;

    [SerializeField] private Transform _camera;
    [SerializeField] private Transform tileparent;

    private void Awake()
    {
        instance = this;
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tileprefab, new Vector3(x, y), Quaternion.identity, tileparent);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x+y) % 2 == 1;
                spawnedTile.Init(isOffset);

            } 
        }

        _camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

        
    }
}
