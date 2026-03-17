using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Gamestate State;
    public GameObject lastTile;
    //spara senaste tile jag kolliderat med
    public static event Action<Gamestate> OnGameStateChange;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateGameState(Gamestate.GenerateGrid);
    }
    public void UpdateGameState(Gamestate newState)
    {
        State = newState;

        switch (newState) { 
            case Gamestate.GenerateGrid:
                GridManager.instance.GenerateGrid();
                break;
            case Gamestate.PlaceDebris:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChange?.Invoke(newState);

    }
}
public enum Gamestate
{
    GenerateGrid,
    PlaceDebris
}