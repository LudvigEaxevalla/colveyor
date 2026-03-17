using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D[] cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public ConveyorBeltScript conveyor;


    public enum cursorState
    {
        Select,
        Conveyor,
        Third,
        Fourth
    }

    private cursorState currentState;

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) TransitionTo(cursorState.Select);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TransitionTo(cursorState.Conveyor);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TransitionTo(cursorState.Third);
        if (Input.GetKeyDown(KeyCode.Alpha4)) TransitionTo(cursorState.Fourth);
    }

    private void Start()
    {
        currentState = cursorState.Select;
        Debug.Log("Sate is: " + currentState);
    }

    private void TransitionTo(cursorState newState)
    {
        if (currentState == newState) return;

        ExitState(currentState);
        currentState = newState;
        EnterState(currentState);

    }

    private void EnterState(cursorState state)
    {
        switch (state)
        {
            case cursorState.Select:
                ChangeCursor(0);
                Debug.Log("Sate is: " + currentState);
                break;

            case cursorState.Conveyor:
                ChangeCursor(1);
                conveyor.isPlacing = true;
                Debug.Log("Sate is: " + currentState);
                break;

            case cursorState.Third:
                ChangeCursor(2);
                Debug.Log("Sate is: " + currentState);
                break;

            case cursorState.Fourth:
                ChangeCursor(3);
                Debug.Log("Sate is: " + currentState);
                break;
        }
    }

    private void ExitState(cursorState state)
    {
        switch (state)
        {
            case cursorState.Conveyor:
                conveyor.isPlacing = false;
                break;
        }
    }


    public void ChangeCursor(int index)
    {
        Cursor.SetCursor(cursorTexture[index], hotSpot, cursorMode);

    }



    void Update()
    {
        HandleInput();

    }
}
