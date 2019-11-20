using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INTENT: Controls the main dialogue system. Contains the dialogue box and text (NOT STRINGS)
//USAGE: Put this on a Dialogue Holder Manager to keep track of dialogue. Probably gonna use raycasts
public class Dialogue_Manager : MonoBehaviour
{
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
    
    //Scripts
    public Dialogue_Holder dialogueHolder; //Taking the script that's on the NPCS

    
    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = contButton.GetComponent<Button>(); //Getting the button
        btn.onClick.AddListener(TaskOnClick);
        Debug.Log("Button Set");
        currentlyTalkingTo = null; //Set to null so that there is no compiler errors
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Easily sets the NPC
    public void SetCharacter(GameObject NPC)
    {
       
        currentlyTalkingTo = NPC; 

        dialogueHolder = NPC.GetComponent<Dialogue_Holder>();
        
        //Debug.Log("NPC Set");
    }

    //Called when button is clicked
    void TaskOnClick()
    {
        sequenceNumber++; //adds 1 to the sequence number to shuffle through the array
        
        if (sequenceNumber >= dialogueHolder.dialogue.Length)
        {
            Debug.Log("conversation over");
            dialogueBox.SetActive(false);
            sequenceNumber = 0;
            SetSequence(0); //Reset for now
            currentlyTalkingTo = null;

        }
        else
        {
            Debug.Log("Next Sequence");
            SetSequence(sequenceNumber);
        } 
        
    }
    
    //The Dialogue System
    private void SetSequence(int sequenceNumber)
    {
        Debug.Log("Start conversation");
        
        dialogueText.text = dialogueHolder.dialogue[sequenceNumber]; //Connects the strings to the texts to the sequence

        nameText.text = dialogueHolder.characterName[sequenceNumber]; //Connects the strings to the texts to the sequence
        
        Debug.Log(sequenceNumber);

    }
}
