using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake ()
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

    public delegate void OnSelectedSlotChange();
    public event OnSelectedSlotChange ChangeSlot;

    public int space = 11;	// Amount of slots in inventory

	// Current list of items in inventory
	public List<Item> items = new List<Item>();


    public InventorySlot selected;

    public InventorySlot SelectedSlot
    {
        get
        {
            return selected;
        }
        set
        {
            if (selected == value) return;
            selected = value;
            if (ChangeSlot != null)
                ChangeSlot.Invoke();

        }
    }

    // Add a new item. If there is enough room we
    // return true. Else we return false.


    public bool Add (Item item)
	{
		// Don't do anything if it's a default item
		
			// Check if out of space
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}

			items.Add(item);	// Add item to list

			// Trigger callback
			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		

		return true;
	}

	// Remove an item
	public void Remove (Item item)
	{
		items.Remove(item);		// Remove item from list

		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
