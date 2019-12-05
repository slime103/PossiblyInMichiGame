using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Manager : MonoBehaviour
{
    public enum MouseState
    {
        None,
        Quarter,
        Key,
        Gum,
        Baby,
        Shoe,
        Ear,
        Snail,
        Perfume
    }

    public Inventory myInv;

    public Sprite[] itemSprites;

    public MouseState myState;
    // Start is called before the first frame update
    void Start()
    {
        SetState(MouseState.None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(MouseState targetState)
    {
        myState = targetState;
        switch (targetState)
        {
            case MouseState.None:
                Cursor.SetCursor(itemSprites[8].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Quarter:
                Cursor.SetCursor(itemSprites[0].texture, new Vector2(50, 50), CursorMode.Auto);
                break;
            case MouseState.Key:
                Cursor.SetCursor(itemSprites[1].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Gum:
                Cursor.SetCursor(itemSprites[2].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Baby:
                Cursor.SetCursor(itemSprites[3].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Ear:
                Cursor.SetCursor(itemSprites[4].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Shoe:
                Cursor.SetCursor(itemSprites[5].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Snail:
                Cursor.SetCursor(itemSprites[6].texture, Vector2.zero, CursorMode.Auto);
                break;
            case MouseState.Perfume:
                Cursor.SetCursor(itemSprites[7].texture, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
}
