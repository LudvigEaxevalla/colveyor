using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    //[SerializeField] private int[] inventorySlots = new int[3];
    private Vector3Int cellPosition;
    [SerializeField] private Tile TestTile;

    void Start()
    {
        Grid grid = transform.parent.GetComponent<Grid>();
        cellPosition = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cellPosition);
    }

    private void Awake()
    {
        
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mouseWorldPosition = Input.mousePosition;
            Instantiate(TestTile, cellPosition, Quaternion.identity);
        }
        if (Input.GetKeyDown("2"))
        {
            
        }
    }
}
