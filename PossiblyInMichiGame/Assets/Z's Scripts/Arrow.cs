using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public string roomName; //stores the name of the room the arrow will take you to when clicked

    public SpriteRenderer sr;

    public void Start() //starts invisible
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        Hide();
    }

    public void Show() //Sets the sprite to be shaded
    {
        sr.color = Color.white;
        /*do
        {
            sr.color -= new Color(0.01f, 0.01f, 0.01f, 0.01f);
        } while (sr.color != Color.clear);*/
    }

    public void Hide() //Turns the alpha to 0 making the arow invisible
    {
        sr.color = Color.clear;
    }
}
