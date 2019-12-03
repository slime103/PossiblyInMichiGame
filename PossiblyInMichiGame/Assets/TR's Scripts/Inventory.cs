using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] collected; //probably unnecessary in the long run
    public Button[] invButtons;
    public Item[] myItems;
    public Sprite[] itemSprites;
    public Item testBaby;


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
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))//Test to go through inventory and give information about each item
        {
            for (int i = 0; i < myItems.Length; i++)
            {
                Debug.Log(myItems[i].gameObject.tag + ": " + myItems[i].isCollected);
            }
        }

        if (Input.GetKey(KeyCode.A))//AddItem Test
        {
            AddItem(testBaby);
        }
    }

    public void AddItem(Item thisItem)
    {
        switch (thisItem.gameObject.tag)
        {
            case "ItemQuarter": //Not really ever used but just made for completion
                invButtons[0].interactable = true;
                invButtons[0].image.sprite = itemSprites[1];
                collected[0] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemKey":
                invButtons[1].interactable = true;
                invButtons[1].image.sprite = itemSprites[1];
                collected[1] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemGum":
                invButtons[2].interactable = true;
                invButtons[2].image.sprite = itemSprites[2];
                collected[2] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemBaby":
                invButtons[3].interactable = true;
                invButtons[3].image.sprite = itemSprites[3];
                collected[3] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemEar":
                invButtons[4].interactable = true;
                invButtons[4].image.sprite = itemSprites[4];
                collected[4] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemShoe":
                invButtons[5].interactable = true;
                invButtons[5].image.sprite = itemSprites[5];
                collected[5] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemSnail":
                invButtons[6].interactable = true;
                invButtons[6].image.sprite = itemSprites[6];
                collected[6] = true;
                Destroy(thisItem.gameObject);
                break;
            case "ItemPerfume":
                invButtons[7].interactable = true;
                invButtons[7].image.sprite = itemSprites[7];
                collected[7] = true;
                Destroy(thisItem.gameObject);
                break;
        }
    }

    public void PushItemButton(int whichItem)
    {
        
    }
    
    
}
