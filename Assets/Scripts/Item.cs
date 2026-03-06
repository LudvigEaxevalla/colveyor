using System.ComponentModel;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{


    [Header("Only gameplay")]
    public TileBase tile;
    public ToolboxItemFilterType type;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]



    [Header("Both")]
    public Sprite image;


    public enum ItemType
    {
        Select,
        ConveyorBelt
    }
}
