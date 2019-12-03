﻿using System.Collections;
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
    public Dialogue_Holder dialogueHolder; //Taking the script that's on the NPCS

    
    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = contButton.GetComponent<Button>(); //Getting the button
        btn.onClick.AddListener(TaskOnClick); //Button calls TaskOnClick
        
        currentlyTalkingTo = null; //Set to null so that there is no compiler errors
        
        SetSequence(0); //Set sequence to 0 at awake just to make sure no errors come up
    }
    
    //Easily sets the NPC
    public void SetCharacter(GameObject NPC)
    {
       
        //Add in bool so that there is no restarting the dialogue
        isTalkingTo = true;
        
        Debug.Log("Character Set");
        
        currentlyTalkingTo = NPC; //Set currentlyTalkingTo from null to whatever the NPC is

        dialogueHolder = NPC.GetComponent<Dialogue_Holder>(); //Take the Dialogue Holder from the NPC
        
        SetSequence(0); //Resets the Sequence for every new character

    }

    //Called when button is clicked
    void TaskOnClick()
    {
        sequenceNumber++; //adds 1 to the sequence number to shuffle through the array
        
        Debug.Log(sequenceNumber); //Keep track of the sequences
        
        if (sequenceNumber >= dialogueHolder.dialogue.Length) //Resets everything once array is over
        {
            Debug.Log("conversation over");
            
            dialogueBox.SetActive(false); //turn off the UI
            
            sequenceNumber = 0; //Put everything back to 0
            SetSequence(0);  //Make sure it's absolutely reset (more of a fail save than anything)
            
            currentlyTalkingTo = null; //MUST BE NULL

            isTalkingTo = false;

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
        Debug.Log("Start conversation");
        
        dialogueText.text = dialogueHolder.dialogue[sequenceNumber]; //Connects the strings to the texts to the sequence

        nameText.text = dialogueHolder.characterName[sequenceNumber]; //Connects the strings to the texts to the sequence
        
        Debug.Log(sequenceNumber); 

    }
}