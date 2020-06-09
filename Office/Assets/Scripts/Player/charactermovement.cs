using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float walkSpeed = 2;
  //  public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    Animator animator;
    Transform cameraT;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

       //if (inputDir != Vector2.zero)
        //{
            float targetRotation =( Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg )+ cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
           
      // }

       // bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ( walkSpeed) * inputDir.magnitude ;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = inputDir.magnitude;
        animator.SetFloat("speed", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
       

        if (Input.GetKeyDown(KeyCode.Z))
        {
          
            animator.SetBool("pickup", true);
            animator.SetBool("pickupmid", true);

        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            

            animator.SetBool("pickupmid", false);
            animator.SetBool("pickup", false);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
          
            animator.SetBool("pickup", true);
            animator.SetBool("pickuplow", true);

        }
        if (Input.GetKeyUp(KeyCode.X))
        {
           

            animator.SetBool("pickuplow", false);
            animator.SetBool("pickup", false);

        }

    }
}
