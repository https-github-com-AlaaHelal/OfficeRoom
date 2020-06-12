using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{

    public Image image;
    public Sprite Note;
    public Sprite Book;
    public GameObject Inventory;

    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.SelectedSlot != null){
            InventorySlot slot = inventory.SelectedSlot;
            if (slot != null)
            {
                switch (slot.name)
                {
                    case "Note":
                        image.sprite = Note;
                        break;
                    case "Book":
                        image.sprite = Book;
                        break;
                }
            }
        }
       
    }
}
