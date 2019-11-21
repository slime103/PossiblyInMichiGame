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

    public MouseState myState;
    // Start is called before the first frame update
    void Start()
    {
        myState = MouseState.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
