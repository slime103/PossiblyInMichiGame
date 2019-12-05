using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INTENT: Allows customizable dialogue for the player to click through
//USAGE: Put this on all of the NPCs with reckless abandon
public class Dialogue_Holder : MonoBehaviour
{
    public Mouse_Manager myMouse;
    public Mouse_Manager.MouseState idealState;
    public bool taskComplete;
    
    //It's an array so you can put as many dialogue sequences as you want
    public string[] dialogueTaskIncomplete; //Dialogue string
    public string[] dialogueTaskComplete;
    public string[] dialogueIncorrectStateIncomplete;
    public string[] dialogueIncorrectStateComplete;
    public string[] dialogueCorrectState;
    public string[] characterName; //Name string
    public string character;

    void Start()
    {
        taskComplete = false;
    }

}
