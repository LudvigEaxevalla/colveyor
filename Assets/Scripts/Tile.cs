using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Tile Instance;
    [SerializeField] private Color basecolor, offsetcolor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
    private GameManager _gamemanager;

    public void Init(bool isOffset) 
    {
        _renderer.color = isOffset ? offsetcolor : basecolor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        //GamemanagerScript.GetComponent<scriptnamn>.variabelnamn = mig själv

        //_gamemanager.GetComponent<GameManager>().lastTile = this.gameObject;
        //^^^^^^ FIXA SÅ DET FUNKAR ^^^^^^
        Debug.Log(_gamemanager.GetComponent<GameManager>().lastTile);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
