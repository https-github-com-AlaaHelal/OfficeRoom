using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationInventory : MonoBehaviour
{
	#region Singleton

	public static InformationInventory instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}

	#endregion

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;



	public int space = 11;  // Amount of slots in inventory

	// Current list of items in inventory
	public List<Information> AllInformation = new List<Information>();





	// Add a new item. If there is enough room we
	// return true. Else we return false.


	public bool Add(Information information)
	{
		// Don't do anything if it's a default item

		// Check if out of space
		if (AllInformation.Count >= space)
		{
			Debug.Log("Not enough room.");
			return false;
		}

		AllInformation.Add(information);    // Add item to list

		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();


		return true;
	}

	// Remove an item
	public void Remove(Information information)
	{
		AllInformation.Remove(information);     // Remove item from list

		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
