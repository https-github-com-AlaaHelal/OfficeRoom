using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text CountText;
    public int Count;

    // Start is called before the first frame update
    public void Start()
    {
        Count = 100;
        SetCountText();
    }

   public void SetCountText()
    {
        CountText.text = "Score :" + Count.ToString();
    }


    public void AddScore()
    {
        Count = Count + 100;
        SetCountText();
    }

    public void DecreaseScore()
    {
        Count = Count - 50;
        SetCountText();
    }

}
