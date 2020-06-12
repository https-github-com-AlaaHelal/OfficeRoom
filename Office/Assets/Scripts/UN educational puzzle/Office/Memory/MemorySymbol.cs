using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemorySymbol : MonoBehaviour
{
    public bool Solved = false;
    public Sprite Symbol;
    public Sprite HideSprite;
    public Image img;
    public delegate void OnClickSprite();
    public OnClickSprite ClickedSprite;

    public  bool hide;
    public bool Hide
    {
        get
        {
            return hide;
        }
        set
        {
            if (hide == value) return;
            hide = value;
            if (ClickedSprite != null)
                ClickedSprite.Invoke();
        }
    }

    void ClickSprite()
    {
        if (Hide)
            img.sprite = HideSprite;
        else
            img.sprite = Symbol;
    }

    private void Awake()
    {
        Hide = true;
        img = gameObject.GetComponent<Image>();
        ClickedSprite += ClickSprite;
        img.sprite = HideSprite;

    }
}
