using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D[] cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void ChangeCursor(int index)
    {
        Cursor.SetCursor(cursorTexture[index], hotSpot, cursorMode);

    }

    // Update is called once per frame
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
