using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InformationInventorySlot : MonoBehaviour
{
    public Image icon;
    //public Button removeButton;


    public Information information;  // Current item in the slot

    // Add item to the slot
    public void AddItem(Information newInfo)
    {
        information = newInfo;
       // icon.sprite = item.icon;
        icon.sprite = information.icon;
        icon.enabled = true;
        
    }



    // Clear the slot
    public void ClearSlot()
    {

        information = null;

        icon.sprite = null;
        icon.enabled = false;
    
       

    }

    // If the remove button is pressed

    public void RemoveItemFromInventory()
    {
        InformationInventory.instance.Remove(information);

    }

}