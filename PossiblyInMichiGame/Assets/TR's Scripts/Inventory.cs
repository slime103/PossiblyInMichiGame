using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] collected; //probably unnecessary in the long run
    public Button[] invButtons;


    void Start()
    {
        collected = new[] {true, false, false, false, false, false, false, false};
        for (int i = 0; i < invButtons.Length; i++)
        {
            if (collected[i])
            {
                invButtons[i].interactable = true;
            }
            else
            {
                invButtons[i].interactable = false;
            }
        }
    }

    public void AddItem(Item thisItem)
    {
        switch (thisItem.gameObject.tag)
        {
            case "ItemQuarter":
                invButtons[0].interactable = true;
                collected[0] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemKey":
                invButtons[1].interactable = true;
                collected[1] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemGum":
                invButtons[2].interactable = true;
                collected[2] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemBaby":
                invButtons[3].interactable = true;
                collected[3] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemShoe":
                invButtons[4].interactable = true;
                collected[4] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemEar":
                invButtons[5].interactable = true;
                collected[5] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemSnail":
                invButtons[6].interactable = true;
                collected[6] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemPerfume":
                invButtons[7].interactable = true;
                collected[7] = true;
                Destroy(thisItem.gameObject);
                break;
        }
    }

    public void PushItemButton(int whichItem)
    {
        
    }
    
    
}
