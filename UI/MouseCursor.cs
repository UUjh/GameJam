using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D mouseCursor;
    public Texture2D clickCursor;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(clickCursor, hotspot, cursorMode);

        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(mouseCursor, hotspot, cursorMode);
        }
    }

}

