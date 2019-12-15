using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INTENT: Controls the main dialogue system. Contains the dialogue box and text (NOT STRINGS)
//USAGE: Put this on a Dialogue Holder Manager to keep track of dialogue. Probably gonna use raycasts
public class Dialogue_Manager : MonoBehaviour
{
    
    //RYAN'S NOTE PLEASE READ BEFORE EDITING: This script is super weird and can be easily broken. If you see an error
    //it's most likely because Unity doesn't like things being null. Don't worry about it or just screech at me.
    
    //Also, this isn't the Dialogue Holder script so don't put this on the NPCS!!!
    
    //THANKS!
    
    //Numbers
    public int sequenceNumber; //Keeps track of where we are in the conversation

    //Buttons
    public Button contButton; //Continue Button (can be replaced by just clicking on the dialogue box if I figure that out
    
    //Texts
    public Text dialogueText; //displays the dialogue text
    public Text nameText; //displays the name text

    //GameObjects
    public GameObject dialogueBox; //Dialogue box (every other UI element is a child of this for simplicity)
    public GameObject currentlyTalkingTo; //Keeps track of who we're currently talking to
    
    //Bools
    public bool isTalkingTo;
    
    //Scripts
    public DialogueHolder dialogueHolder; //Taking the script that's on the NPCS
    public string[] thisDialogueSequence;
    public Mouse_Manager myMouse;
    public Inventory myInv;
    public CameraManager camera;

    
    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = contButton.GetComponent<Button>(); //Getting the button
        btn.onClick.AddListener(TaskOnClick); //Button calls TaskOnClick
        
        currentlyTalkingTo = null; //Set to null so that there is no compiler errors
        
        SetSequence(0); //Set sequence to 0 at awake just to make sure no errors come up
    }
    
    //Easily sets the NPC
    public void SetCharacter(GameObject NPC, Mouse_Manager.MouseState state)
    {
       
        //Add in bool so that there is no restarting the dialogue
        isTalkingTo = true;
        
        Debug.Log("Character Set");
        
        currentlyTalkingTo = NPC; //Set currentlyTalkingTo from null to whatever the NPC is

        dialogueHolder = NPC.GetComponent<DialogueHolder>(); //Take the Dialogue Holder from the NPC
        Debug.Log(state);
        /*
        switch (dialogueHolder.taskComplete)
        {
            case false:
                switch (state)
                {
                    case Mouse_Manager.MouseState.None:
                        if (!dialogueHolder.introduced)
                        {
                            thisDialogueSequence = dialogueHolder.introduction;
                        }
                        else
                        {
                            thisDialogueSequence = dialogueHolder.dialogueIncompleteNoItem;
                        }
                        break;
                    case Mouse_Manager.MouseState.Quarter:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteQuarter;
                        break;
                    case Mouse_Manager.MouseState.Key:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteKey;
                        break;
                    case Mouse_Manager.MouseState.Gum:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteGum;
                        break;
                    case Mouse_Manager.MouseState.Baby:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteBaby;
                        break;
                    case Mouse_Manager.MouseState.Ear:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteEar;
                        break;
                    case Mouse_Manager.MouseState.Shoe:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteShoe;
                        break;
                    case Mouse_Manager.MouseState.Snail:
                        thisDialogueSequence = dialogueHolder.dialogueIncompleteSnail;
                        break;
                }
                break;
            case true:
                switch (state)
                {
                    case Mouse_Manager.MouseState.None:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteNoItem;
                        break;
                    case Mouse_Manager.MouseState.Quarter:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteQuarter;
                        break;
                    case Mouse_Manager.MouseState.Key:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteKey;
                        break;
                    case Mouse_Manager.MouseState.Gum:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteGum;
                        break;
                    case Mouse_Manager.MouseState.Baby:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteBaby;
                        break;
                    case Mouse_Manager.MouseState.Ear:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteEar;
                        break;
                    case Mouse_Manager.MouseState.Shoe:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteShoe;
                        break;
                    case Mouse_Manager.MouseState.Snail:
                        thisDialogueSequence = dialogueHolder.dialogueCompleteSnail;
                        break;
                }
                break;
        }*/
        //thisDialogueSequence = dialogueHolder.ReadMouseAndGetDialogue(state);
        if (myMouse.myState != Mouse_Manager.MouseState.None && thisDialogueSequence == dialogueHolder.ReadMouseAndGetDialogue(dialogueHolder.idealState))
        {
            myInv.RemoveItem();
            if (dialogueHolder.swapSprite)
            {
                dialogueHolder.mySR.sprite = dialogueHolder.endSprite;
            }
        }
        else if (myMouse.myState != Mouse_Manager.MouseState.None && thisDialogueSequence != dialogueHolder.ReadMouseAndGetDialogue(dialogueHolder.idealState))
        {
            myMouse.ResetState();
        }
        SetSequence(0); //Resets the Sequence for every new character
    }

    public void Bark(DialogueHolder whichChar)
    {
        isTalkingTo = true;
        currentlyTalkingTo = whichChar.gameObject;
        dialogueHolder = whichChar;
        //set this dialogue to the barks
        SetSequence(0);
    }

    //Called when button is clicked
    void TaskOnClick()
    {
        sequenceNumber++; //adds 1 to the sequence number to shuffle through the array
        
        Debug.Log(sequenceNumber); //Keep track of the sequences
        
        if (sequenceNumber >= thisDialogueSequence.Length) //Resets everything once array is over
        {
            Debug.Log("conversation over");
            
            dialogueBox.SetActive(false); //turn off the UI
            
            sequenceNumber = 0; //Put everything back to 0
            SetSequence(0);  //Make sure it's absolutely reset (more of a fail save than anything)
            
            currentlyTalkingTo = null; //MUST BE NULL

            isTalkingTo = false;
            if (thisDialogueSequence == dialogueHolder.dialogueIdeal)
            {
                myInv.RemoveItem();
                dialogueHolder.taskComplete = true;
                if (dialogueHolder.reward != Mouse_Manager.MouseState.None)
                {
                    myInv.ReturnItem(dialogueHolder.reward);
                }
                if (dialogueHolder.unlockArrow)
                {
                    dialogueHolder.toUnlock.ActivateArrow();
                }
            }
            else if (!dialogueHolder.introduced)
            {
                dialogueHolder.introduced = true;
            }
        }
        else //Keeps the sequence going
        {
            Debug.Log("Next Sequence");
            SetSequence(sequenceNumber); //Progress in sequence
        } 
        
    }
    
    //The Dialogue System
    public void SetSequence(int sequenceNumber)
    {

        dialogueText.text = thisDialogueSequence[sequenceNumber]; //Connects the strings to the texts to the sequence

        //nameText.text = dialogueHolder.character; //Connects the strings to the texts to the sequence
        
        Debug.Log(sequenceNumber);

    }
}
