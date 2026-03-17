using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] private Color basecolor, offsetcolor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
<<<<<<< HEAD
    public ConveyorBeltScript conveyor;
=======
    //private GameManager _gameManager;
    private GameObject _gamemanager;
>>>>>>> main

    private void Start()
    {
        //_gamemanager = GetComponent<GameManager>();
        _gamemanager = GameObject.Find("GameManager");
    }

    public void Init(bool isOffset) 
    {
        _renderer.color = isOffset ? offsetcolor : basecolor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
<<<<<<< HEAD
        conveyor.currentTile = this.gameObject;
=======
        //GamemanagerScript.GetComponent<scriptnamn>.variabelnamn = mig själv
        _gamemanager.GetComponent<GameManager>().lastTile = this.gameObject;
        Debug.Log(_gamemanager.GetComponent<GameManager>().lastTile);
>>>>>>> main
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
