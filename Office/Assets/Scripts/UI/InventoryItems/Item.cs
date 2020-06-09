using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool isDefaultItem = false;      // Is the item default wear?
    //[HideInInspector]
    //public bool isSelected = false;

	// Called when the item is pressed in the inventory
	//public virtual void Use ()
	//{
	//	// Use the item
	//	// Something might happen

	//	Debug.Log("Using " + name);
	//}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}


	

}
