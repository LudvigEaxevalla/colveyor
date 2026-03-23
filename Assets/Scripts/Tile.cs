using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] private Color basecolor, offsetcolor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
    public ConveyorBeltScript conveyor;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        conveyor = GameObject.Find("ConveyorBelt").GetComponent<ConveyorBeltScript>();
    }

    public void Init(bool isOffset) 
    {
        _renderer.color = isOffset ? offsetcolor : basecolor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        conveyor.currentTile = this.gameObject;
        _gameManager.lastTile = this.gameObject;
        Debug.Log(_gameManager.GetComponent<GameManager>().lastTile);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
