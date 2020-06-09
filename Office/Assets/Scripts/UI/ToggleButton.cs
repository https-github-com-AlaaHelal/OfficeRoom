using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public GameObject OptionsMenuUI;
    public Sprite sprite_ON;
    public Sprite sprite_OFF;

    private Image image;

    public string ButtonImage;

    public bool IsToggled { get; private set; }

    private void Start()
    {
        image = GetComponent<Image>();


        UpdateSprite();

    }

    //when button pressed
    public void Toggle()
    {
        IsToggled = !IsToggled;
        UpdateSprite();
    }


    private void UpdateSprite()
    {    //to change the photo when it is pressed
        if (IsToggled)
        {
            image.sprite = sprite_ON;
            PlayerPrefs.SetInt(ButtonImage, 0);
        }
        else
        {
            image.sprite = sprite_OFF;
            PlayerPrefs.SetInt(ButtonImage, 1);

        }

    }
         public void exitoptionsmenu()
        {

            OptionsMenuUI.SetActive(false);
        }

    
}
