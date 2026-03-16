using System;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private Color basecolor, offsetcolor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
    public ConveyorBeltScript conveyor;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? offsetcolor : basecolor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        conveyor.currentTile = this.gameObject;
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void Start()
    {
        conveyor = GameObject.Find("ConveyorBelt").GetComponent<ConveyorBeltScript>();
       
    }
}
