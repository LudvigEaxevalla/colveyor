using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D[] cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public SpriteRenderer placeHighlight;

    [SerializeField] Camera cam;

    //public ConveyorBeltScript conveyor;

    public LevelEditor placing;


    public enum cursorState
    {
        Select,
        Conveyor,
        ColorHouse,
        Fourth
    }

    private cursorState currentState;

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) TransitionTo(cursorState.Select);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TransitionTo(cursorState.Conveyor);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TransitionTo(cursorState.ColorHouse);
        if (Input.GetKeyDown(KeyCode.Alpha4)) TransitionTo(cursorState.Fourth);
    }

    private void Start()
    {
        currentState = cursorState.Select;
        Debug.Log("Sate is: " + currentState);
        placeHighlight.enabled = false;
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
                //conveyor.isPlacing = true;
                placing.placingConveyor = true;
                placeHighlight.enabled = true;
                placeHighlight.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Sate is: " + currentState);
                    break;

            case cursorState.ColorHouse:
                ChangeCursor(2);
                placing.placingColorHouse = true;
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
                //conveyor.isPlacing = false;
                placing.placingConveyor = false;
                placeHighlight.enabled = false;
                break;
            case cursorState.ColorHouse:
                placing.placingColorHouse = false;
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
