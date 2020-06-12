using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableImage : MonoBehaviour
{
    //public Image image;
    //public Sprite BlockSprite;
    //public Sprite DefaultSprite;
    //public GameObject Line;

    //public bool Default = true;
    //private DrawLine DrawLine;
    public bool Default;
    // Start is called before the first frame update
    void Start()
    {
        //DrawLine = Line.GetComponent<DrawLine>();
        Default = true;
    }

    
    //public void OnClickImage(GameObject Block)
    //{
    //    Image img = Block.GetComponent<Image>();
    //    Default = !Default;
    //    if (Default)
    //        img.sprite = DefaultSprite;
    //    else
    //        img.sprite = BlockSprite;
       
    //    Block.GetComponent<BoxCollider>().enabled = !Default;
    //    DrawLine.redraw = true;

    //}
}
