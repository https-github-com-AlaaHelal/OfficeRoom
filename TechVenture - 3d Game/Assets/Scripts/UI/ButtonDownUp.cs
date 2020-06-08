using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDownUp : MonoBehaviour , IPointerDownHandler
{
    // Start is called before the first frame update
    [SerializeField]
    public ScrollRectScript1 ScrollRectScript;
    [SerializeField]
    private bool IsButtonDown=true;
    public void OnPointerDown(PointerEventData eventData)

    {
        if (IsButtonDown)
        { ScrollRectScript.ButtonDownIsPressed(); }
        else { ScrollRectScript.ButtonUpIsPressed(); }

    }
}

