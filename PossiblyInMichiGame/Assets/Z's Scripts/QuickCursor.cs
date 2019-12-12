using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickCursor : MonoBehaviour
{

    public Sprite cursortexture;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursortexture.texture, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
