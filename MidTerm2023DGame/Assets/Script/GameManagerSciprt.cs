using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSciprt : MonoBehaviour
{
    public Texture2D cursorImg;

    private void Awake()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(cursorImg,Vector2.zero,CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
