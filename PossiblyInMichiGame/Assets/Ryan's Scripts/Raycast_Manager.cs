using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//INTENT: Basic raycast for picking up objects and talking to NPCS
//USAGE: Put this on a raycast manager to use inventory objects, pick up things or talk to people
public class Raycast_Manager : MonoBehaviour
{
    private RaycastHit target; //For storing the gameObject we're clicking 

    public Dialogue_Manager dialogueManager; //Get the dialogue manager
    public Mouse_Manager myMouse;
    public Inventory myInv;
    public CameraManager camera;

    // Start is called before the first frame update
    void Start()
    {
        //dialogueManager = GameObject.Find("Dialogue_Manager").GetComponent<Dialogue_Manager>(); //Get the dialogue manager
    }

    // Update is called once per frame
    void Update()
    {
		
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Gets mouse position

        float maxDistance = 1000f; //I made it really long bc it's just easier
        
        RaycastHit mouseRayHit = new RaycastHit(); //Instantiate the ray
        
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxDistance, Color.cyan); //Draw it out so we can see it

        // Make the ray
        if (Physics.Raycast(mouseRay, out mouseRayHit, maxDistance)) 
        {
            if (dialogueManager.isTalkingTo == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("left mouse button clicked");
                    if (mouseRayHit.collider.CompareTag("NPC"))
                    {

                        //Later on I want to add a different mouse hover color so objects are more obviously clickable

                        //If left mouse button is clicked:
                        if (Input.GetMouseButton(0))
                        {
                            dialogueManager.SetCharacter(mouseRayHit.collider.gameObject, myMouse.myState); //Gets the dialogue holder from the Character
                            dialogueManager.dialogueBox.SetActive(true); //Turns on the dialogue box
                        }
                    }
                    else if (mouseRayHit.collider.tag.Contains("Item") && myMouse.myState == Mouse_Manager.MouseState.None)
                    {
                        Debug.Log("There's an item here");
                        if (Input.GetMouseButton(0))
                        {
                            myInv.AddItem(mouseRayHit.collider.gameObject.GetComponent<Item>());
                        }
                    }
                    else if (mouseRayHit.collider.CompareTag("Arrow") && mouseRayHit.collider.gameObject.GetComponent<Arrow>().unlocked)
                    {
                        string NameOfRoom = mouseRayHit.collider.gameObject.GetComponent<Arrow>().roomName;
                        camera.MoveToRoom(NameOfRoom);
                   
                        Debug.Log("Hit an arrow");
                    }
                    else if (mouseRayHit.collider.CompareTag("Nose"))
                    {
                        if (myMouse.myState == Mouse_Manager.MouseState.Perfume)
                        {
                            SceneManager.LoadScene("WinScreen");
                        }
                        else if (myMouse.myState != Mouse_Manager.MouseState.Perfume &&
                                 myMouse.myState != Mouse_Manager.MouseState.None)
                        {
                            myInv.ReturnItem(myMouse.myState);
                            myMouse.SetState(Mouse_Manager.MouseState.None);
                        }
                    }
                    else if (mouseRayHit.collider.CompareTag("Background"))
                    {
                        myMouse.ResetState();
                    }
                }
                if (Input.GetMouseButton(1))
                {
                    Debug.Log("Other mouse button clicked");
                    if (myMouse.myState != Mouse_Manager.MouseState.None)
                    {
                        myMouse.ResetState();
                    }
                }
            }

        }

    }
}
