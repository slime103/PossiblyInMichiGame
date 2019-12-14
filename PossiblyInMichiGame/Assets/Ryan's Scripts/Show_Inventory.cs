using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INENT: Make the inventory less obnoxious in the top of the screen
public class Show_Inventory : MonoBehaviour
{

    public Button inventoryButton;

    public GameObject inventoryUI;
    
    // Start is called before the first frame update
    void Start()
    {
               
        Button btn = inventoryButton.GetComponent<Button>(); //Getting the button
        btn.onClick.AddListener(TaskOnClick); //Button calls TaskOnClick
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
