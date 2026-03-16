using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D[] cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
    }

    public void ChangeCursor(int index)
    {
        Cursor.SetCursor(cursorTexture[index], hotSpot, cursorMode);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCursor(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCursor(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeCursor(2);
        }

    }
}
