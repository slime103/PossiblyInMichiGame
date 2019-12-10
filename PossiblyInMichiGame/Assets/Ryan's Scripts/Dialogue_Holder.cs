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
    public TextAsset dialogueText; //use this to import the dialogue for each character

    //It's an array so you can put as many dialogue sequences as you want
    public string[] welcomeBarks;
    public string[] dialogue_CorrectItem;
    public string[] dialogue_Complete_NoItem;
    public string[] dialogue_Incomplete_Item; //Dialogue string
    public string[] dialogue_Complete_Item;
    public string[] dialogue_Incomplete_NoItem;
    public string[] characterName; //Name string
    public string character;
    public Mouse_Manager.MouseState reward;
    public bool manualTransport, unlockArrow;
    public string destination;
    public Arrow toUnlock;

    void Start()
    {
        ImportDialogue();
        taskComplete = false;
    }

    void ImportDialogue()
    {
        string[] dialogueStates;

        dialogueStates = (dialogueText.text.Split('\n'));

        //sort array
        character = dialogueStates[0];
        welcomeBarks = dialogueStates[1].Split(',');
        dialogue_CorrectItem = dialogueStates[2].Split(',');
        dialogue_Complete_NoItem = dialogueStates[3].Split(',');
        dialogue_Complete_Item = dialogueStates[4].Split(',');
        dialogue_Incomplete_Item = dialogueStates[5].Split(',');
        dialogue_Incomplete_NoItem = dialogueStates[6].Split(',');
        
    }

}
