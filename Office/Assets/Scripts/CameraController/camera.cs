using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera :MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensitivity = 4;
    public Transform target;
    public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
            
    float yaw;
    float pitch;
   
    public GameObject inventoryisActive;
    public GameObject EducationalcanvasisActive;
    public GameObject puzzlecanvasisActive;
    public GameObject LaserPuzzle;
    //public GameObject ToolBoxisActive;
    //public GameObject lockerisActive;





    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()

    {
        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    if (state == false)
        //    {
        //        inventory.SetBool("show", true);
        //        state = true;


        //    }
        //    else
        //    {
        //        inventory.SetBool("show", false);
        //        state = false;

        //    }
        //}
        //if (state)
        //{
        //    mouseSensitivity = 0;
        //}
       //if(!state)
       // {
       //     mouseSensitivity = 4;
       // }
        if (inventoryisActive.GetComponent<showinventory>().state == true || 
            EducationalcanvasisActive.GetComponent<Educational>().educationalpuzzleisActive==true ||
            puzzlecanvasisActive.GetComponent<UEPuzzleCanvas>().puzzlecanvasState == true  ||
            LaserPuzzle.GetComponent<OpenLaser>().LaserPuzzleActive == true)
        {
            mouseSensitivity = 0;

        }
       else
        {
            mouseSensitivity = 4;

        }
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        transform.position = target.position - transform.forward * dstFromTarget;

    }
    //public void show()
    //{
    //    if (state == false)
    //    {
    //        inventory.SetBool("show", true);
    //        state = true;
    //    }
    //    else
    //    {
    //        inventory.SetBool("show", false);
    //        state = false;
    //    }
    //}

}
