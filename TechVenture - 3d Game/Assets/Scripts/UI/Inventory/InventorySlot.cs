using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
	public Image icon;
	//public Button removeButton;
	public Image ic1image, ic2image, ic3image, ic4image;
	public Image PlaceImage;
	public Image barImage;
	public Sprite WhiteSprite;
	public Sprite GreenSprite;
	public bool IsSelected;
    public InventorySlot inventorySlot;


    public Item item;  // Current item in the slot


    public void Start()
    {
        inventorySlot = GetComponent<InventorySlot>();
    }


    // Add item to the slot
    public void AddItem(Item newItem)
	{
		item = newItem;
        
		icon.sprite = item.icon;
		icon.enabled = true;
		//removeButton.interactable = true;
	}



	// Clear the slot
	public void ClearSlot()
	{

		item = null;

		icon.sprite = null;
		icon.enabled = false;
        DeselectUI();
		// removeButton.interactable = false;

	}

	// If the remove button is pressed

	public void RemoveItemFromInventory()
    {   // execute if the item is ic else remove it as normal
    //    if (icon.sprite == ic1image.sprite || icon.sprite == ic2image.sprite || icon.sprite == ic3image.sprite || icon.sprite == ic4image.sprite)
    //    {
    //        Debug.Log("done");
    //        IsSelected = true;
    //        changebarcolor();
    //        PlaceImage.sprite = icon.sprite;
    //        icon.enabled = false;
    //        //icon.sprite = null;


    //    }

    //    else
    //        Inventory.instance.Remove(item);

    //    //else
        //    Inventory.instance.Remove(item);

    }

    public void SelectSlot()
    {
        Inventory.instance.SelectedSlot = inventorySlot;
        SelectUI();
    }

    public void SelectUI()
    {
       // barImage.sprite = GreenSprite;
        IsSelected = true;
    }

    public void DeselectUI()
    {
       // barImage.sprite = WhiteSprite;
        IsSelected = false;
    }

    ////Use the item
    //public void UseItem()
    //{
    //	if (item != null)
    //	{
    //		item.Use();
    //	}
    //}


 //   public void changebarcolor()
	//{
 //       if (IsSelected == true)

 //       { barimage.sprite = greenbar.sprite; }
 //       else if (IsSelected == false)
 //       { barimage.sprite = whitebar.sprite; }


 //   }

	//public void ReturnICSToBar()
	//{
	//	IsSelected = false;
	//	changebarcolor();
	//	icon.enabled = true;
	//	PlaceImage.sprite = null;

	//}

}



