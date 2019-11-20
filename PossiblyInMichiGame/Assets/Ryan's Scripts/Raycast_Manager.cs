using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INTENT: Basic raycast for picking up objects and talking to NPCS
//USAGE: Put this on a raycast manager to use inventory objects, pick up things or talk to people
public class Raycast_Manager : MonoBehaviour
{
    
    public Camera mainCamera; //Sometimes the camera isn't already set so it's just for safety
    private RaycastHit target; //For storing the gameObject we're clicking 
    
    public Vector3 mousePosition;

    public Dialogue_Manager dialogueManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = GetComponent<Camera>(); //For getting the camera
        dialogueManager = GetComponent<Dialogue_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
		
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Gets mouse position

        float maxDistance = 1000f; //I made it really long bc it's just easier
        
        RaycastHit mouseRayHit = new RaycastHit(); //Instantiate the ray
        
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxDistance, Color.cyan); //A debug to see it

        // Make the ray
        if (Physics.Raycast(mouseRay, out mouseRayHit, maxDistance)) 
        {
            if (mouseRayHit.collider.CompareTag("NPC"))
            {
                //Debug.Log("Oh bitch got hit!");
                dialogueManager.SetCharacter(collider.gameObject);
            }

            /*if (mouseRayHit.collider.CompareTag("Object"))
            {
                
            }*/
            
        }

    }
}
