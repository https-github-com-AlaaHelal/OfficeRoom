using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newmove : MonoBehaviour
{
     float walkSpeed = 5;
    //public float runSpeed = 6;

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

        if (inputDir != Vector2.zero)
        {
            float targetRotation = (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg) + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        // bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = (walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = inputDir.magnitude;
        // Move();
        if ( animationSpeedPercent> 0)
        {
         
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run();
                walkSpeed = 9;
              //  Debug.Log("run");

            }
            else
            {
                movefront();
                walkSpeed = 5;
            }

        }
        if (animationSpeedPercent == 0)
        {
            backtoIdle();
        }
       
    }
    private void Move()
    {
        float walkforward = Input.GetAxis("Vertical");

       // if ( > 0)
        {
            movefront();
            walkSpeed = 5;

        }
        if (walkforward == 0)
        {
            backtoIdle();
        }
        if(walkforward>0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            run();
            walkSpeed = 9;

        }
        //if (walkforward < 0)
        //{
        //    moveback();
        //    walkSpeed = 5;
        //}
    }
    void movefront()
    {
        animator.SetBool("action", true);
        animator.SetBool("front", true);
        animator.SetBool("back", false);
        animator.SetBool("run", false);
        animator.SetBool("pickup", false);
        animator.SetBool("pickuplow", false);
        animator.SetBool("pickupmid", false);
    }
    void run()
    {
        animator.SetBool("action", true);
        animator.SetBool("front", false);
        animator.SetBool("back", false);
        animator.SetBool("run", true);
        animator.SetBool("pickup", false);
        animator.SetBool("pickuplow", false);
        animator.SetBool("pickupmid", false);
    }
    void moveback()
    {
        animator.SetBool("action", true);
        animator.SetBool("front", false);
        animator.SetBool("back", true);
        animator.SetBool("run", false);
        animator.SetBool("pickup", false);
        animator.SetBool("pickuplow", false);
        animator.SetBool("pickupmid", false);
    }
    void pickupmid()
    {
        animator.SetBool("action", true);
        animator.SetBool("front", false);
        animator.SetBool("back", false);
        animator.SetBool("run", false);
        animator.SetBool("pickup", true);
        animator.SetBool("pickuplow", false);
        animator.SetBool("pickupmid", true);
    }
    void pickuplow()
    {
        animator.SetBool("action", true);
        animator.SetBool("front", false);
        animator.SetBool("back", false);
        animator.SetBool("run", false);
        animator.SetBool("pickup", true);
        animator.SetBool("pickuplow", true);
        animator.SetBool("pickupmid", false);
    }
    void backtoIdle()
    {
        animator.SetBool("action", false);
        animator.SetBool("front", false);
        animator.SetBool("back", false);
        animator.SetBool("run", false);
        animator.SetBool("pickup", false);
        animator.SetBool("pickuplow", false);
        animator.SetBool("pickupmid", false);
    }
}
