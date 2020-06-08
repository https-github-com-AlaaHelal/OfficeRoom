using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectScript1 : MonoBehaviour
{
    private ScrollRect scrollRect;

    private bool MouseDown, ButtonDown, ButtonUp;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }



    public void Update()

    {

        if (MouseDown)
        { if (ButtonDown)
            { ScrollDown(); }
            else if(ButtonUp)
                { ScrollUp(); }

        }

    }


    public void ButtonDownIsPressed()

    {
        ButtonDown = true;
        MouseDown = true;
    }


    public void ButtonUpIsPressed()

    {
        ButtonUp = true;
        MouseDown = true;
    }

    public void ScrollDown()
    {
        if (Input.GetMouseButtonUp(0))
        {
            MouseDown = false;
            ButtonDown = false;
        }
        else scrollRect.verticalNormalizedPosition -= 0.01f;

    }
    public void ScrollUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            MouseDown = false;
            ButtonUp = false;
        }
        else scrollRect.verticalNormalizedPosition += 0.01f;

    }
}