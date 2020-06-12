using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPuzzle : MonoBehaviour
{
    public GameObject Desk;
    public GameObject Camera;
    public Canvas canvas;
    public GameObject Line;
    public bool Exit;
    // Start is called before the first frame update
    void Start()
    {
        Exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Exit)
        {
            gameObject.SetActive(false);
            Desk.GetComponent<OpenLaser>().LaserPuzzleActive = false;
            Camera.GetComponent<camera>().enabled = true;
            Line.GetComponent<DrawLine>().redraw = true;
        }
    }
    public void OnExit()
    {
        Exit = true;
    }
}
