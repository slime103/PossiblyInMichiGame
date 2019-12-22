using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//INTENT: Allows customizable dialogue for the player to click through
//USAGE: Put this on all of the NPCs with reckless abandon
public class Dialogue_Holder : MonoBehaviour
{
    public SpriteRenderer mySR;
    public Sprite startSprite, endSprite;
    public Mouse_Manager myMouse;
    public Mouse_Manager.MouseState idealState;
    public bool taskComplete, manualTransport;
    public string targetRoom;
    public TextAsset dialogueText; //use this to import the dialogue for each character

    //It's an array so you can put as many dialogue sequences as you want
    public string[] introduction;
    public string[] dialogueIncompleteNoItem;
    public string[] dialogueIncompleteQuarter;
    public string[] dialogueIncompleteKey;
    public string[] dialogueIncompleteGum;
    public string[] dialogueIncompleteBaby;
    public string[] dialogueIncompleteEar;
    public string[] dialogueIncompleteShoe;
    public string[] dialogueIncompleteSnail;
    public string[] dialogueCompleteNoItem;
    public string[] dialogueCompleteQuarter;
    public string[] dialogueCompleteKey;
    public string[] dialogueCompleteGum;
    public string[] dialogueCompleteBaby;
    public string[] dialogueCompleteEar;
    public string[] dialogueCompleteShoe;
    public string[] dialogueCompleteSnail;
    public string[] dialogueIdeal;
    public string[] characterName; //Name string
    public string character;

    public Mouse_Manager.MouseState reward;
    public bool swapSprite, unlockArrow, introduced;
    public Arrow toUnlock;
    
    void Awake()
    {
        ImportDialogue();
    }

    void Start()
    {
        mySR.sprite = startSprite;
        ImportDialogue();
        switch (idealState)
        {
            case Mouse_Manager.MouseState.Quarter:
                dialogueIdeal = dialogueIncompleteQuarter;
                break;
            case Mouse_Manager.MouseState.Key:
                dialogueIdeal = dialogueIncompleteKey;
                break;
            case Mouse_Manager.MouseState.Gum:
                dialogueIdeal = dialogueIncompleteGum;
                break;
            case Mouse_Manager.MouseState.Baby:
                dialogueIdeal = dialogueIncompleteBaby;
                break;
            case Mouse_Manager.MouseState.Ear:
                dialogueIdeal = dialogueIncompleteEar;
                break;
            case Mouse_Manager.MouseState.Shoe:
                dialogueIdeal = dialogueIncompleteShoe;
                break;
            case Mouse_Manager.MouseState.Snail:
                dialogueIdeal = dialogueIncompleteSnail;
                break;
        }
    }

    void ImportDialogue() //reads text file and splits it into corresponding arrays
    {
        string[] dialogueStates; //temp holder array

        dialogueStates = (dialogueText.text.Split('\n')); //splits by line

        //sort array, splits each line by comma
        character = dialogueStates[0];
        introduction = dialogueStates[1].Split('~');
        dialogueIncompleteNoItem = dialogueStates[2].Split('~');
        dialogueIncompleteQuarter = dialogueStates[3].Split('~');
        dialogueIncompleteKey = dialogueStates[4].Split('~');
        dialogueIncompleteGum = dialogueStates[5].Split('~');
        dialogueIncompleteBaby = dialogueStates[6].Split('~');
        dialogueIncompleteEar = dialogueStates[7].Split('~');
        dialogueIncompleteShoe = dialogueStates[8].Split('~');
        dialogueIncompleteSnail = dialogueStates[9].Split('~');
        dialogueCompleteNoItem = dialogueStates[10].Split('~');
        dialogueCompleteQuarter = dialogueStates[11].Split('~');
        dialogueCompleteKey = dialogueStates[12].Split('~');
        dialogueCompleteGum = dialogueStates[13].Split('~');
        dialogueCompleteBaby = dialogueStates[14].Split('~');
        dialogueCompleteEar = dialogueStates[15].Split('~');
        dialogueCompleteShoe = dialogueStates[16].Split('~');
        dialogueCompleteSnail = dialogueStates[17].Split('~');
    }

    public string[] ReadMouseAndGetDialogue(Mouse_Manager.MouseState inputState)
    {
        switch (taskComplete)
        {
            case false:
                switch (inputState)
                {
                    case Mouse_Manager.MouseState.None:
                        if (!introduced)
                        {
                            return introduction;
                        }
                        else
                        {
                            return dialogueIncompleteNoItem;
                        }
                    case Mouse_Manager.MouseState.Quarter:
                        return dialogueIncompleteQuarter;
                    case Mouse_Manager.MouseState.Key:
                        return dialogueIncompleteKey;
                    case Mouse_Manager.MouseState.Gum:
                        return dialogueIncompleteGum;
                    case Mouse_Manager.MouseState.Baby:
                        return dialogueIncompleteBaby;
                    case Mouse_Manager.MouseState.Ear:
                        return dialogueIncompleteEar;
                    case Mouse_Manager.MouseState.Shoe:
                        return dialogueIncompleteShoe;
                    case Mouse_Manager.MouseState.Snail:
                        return dialogueIncompleteSnail;
                }
                break;
            case true:
                switch (inputState)
                {
                    case Mouse_Manager.MouseState.None:
                        return dialogueCompleteNoItem;
                    case Mouse_Manager.MouseState.Quarter:
                        return dialogueCompleteQuarter;
                    case Mouse_Manager.MouseState.Key:
                        return dialogueCompleteKey;
                    case Mouse_Manager.MouseState.Gum:
                        return dialogueCompleteGum;
                    case Mouse_Manager.MouseState.Baby:
                        return dialogueCompleteBaby;
                    case Mouse_Manager.MouseState.Ear:
                        return dialogueCompleteEar;
                    case Mouse_Manager.MouseState.Shoe:
                        return dialogueCompleteShoe;
                    case Mouse_Manager.MouseState.Snail:
                        return dialogueCompleteSnail;
                }
                break;
        }
        return null;
    }

}
