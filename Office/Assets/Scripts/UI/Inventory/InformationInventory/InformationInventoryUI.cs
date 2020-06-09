using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationInventoryUI : MonoBehaviour
{
	public Transform itemsParent;   // The parent object of all the items in the canvas because if we had referance to the parent we will have ref to all th childern(inventory slots)

	public GameObject InformationinventoryUI;  // The entire UI

	InformationInventory Informationinventory;    // Our current inventory

	InformationInventorySlot[] slots;  // List of all the slots

	void Start()
	{
		Informationinventory = InformationInventory.instance;
		Informationinventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback
		

		//Populate our slots array
		slots = itemsParent.GetComponentsInChildren<InformationInventorySlot>();
	}

	void Update()
	{
		// Check to see if we should open/close the inventory
		//if (Input.GetButtonDown("Inventory"))
		//{
		//	inventoryUI.SetActive(!inventoryUI.activeSelf);
		//}
	}


	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI()
	{
		// Loop through all the slots
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < Informationinventory.AllInformation.Count)  // If there is an item to add
			{
				slots[i].AddItem(Informationinventory.AllInformation[i]);   // Add it
														// Debug.Log(inventory.items[i]);
			}
			else
			{
				// Otherwise clear the slot
				slots[i].ClearSlot();
			}

		}
	}
}