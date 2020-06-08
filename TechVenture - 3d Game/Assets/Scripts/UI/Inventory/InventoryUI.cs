using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;	// The parent object of all the items in the canvas because if we had referance to the parent we will have ref to all th childern(inventory slots)

	public GameObject inventoryUI;	// The entire UI

	Inventory inventory;	// Our current inventory

	InventorySlot[] slots;	// List of all the slots

	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;	// Subscribe to the onItemChanged callback
        inventory.ChangeSlot += ChangeSlotSlection;

        //Populate our slots array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	void Update () {
		// Check to see if we should open/close the inventory
		//if (Input.GetButtonDown("Inventory"))
		//{
		//	inventoryUI.SetActive(!inventoryUI.activeSelf);
		//}
	}

    void ChangeSlotSlection()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != inventory.SelectedSlot)
                slots[i].DeselectUI();
        }
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    void UpdateUI ()
	{
		// Loop through all the slots
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)	// If there is an item to add
			{
				slots[i].AddItem(inventory.items[i]);	// Add it
               // Debug.Log(inventory.items[i]);
			} else
			{
				// Otherwise clear the slot
				slots[i].ClearSlot();
			}
            
		}
	}
}
