using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] private Color basecolor, offsetcolor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
    //private GameManager _gameManager;
    private GameObject _gamemanager;

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
        //GamemanagerScript.GetComponent<scriptnamn>.variabelnamn = mig själv
        _gamemanager.GetComponent<GameManager>().lastTile = this.gameObject;
        Debug.Log(_gamemanager.GetComponent<GameManager>().lastTile);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
