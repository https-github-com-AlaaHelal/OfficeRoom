using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SafeController : MonoBehaviour
{
    public GameObject pointer;
    public Material Normal;
    public Material Light;
    public GameObject Camera;
    public GameObject Safe;
    public GameObject QuestionBall;

    Animator SafeAnimator;
    float deg;
    Quaternion Origin;
    Quaternion RotationB;
    Quaternion RotationE;
    Quaternion RotationF;
    Quaternion RotationW;

    Quaternion FactorB;
    Quaternion FactorE;
    Quaternion FactorF;
    Quaternion FactorW;

    int E = 0;
    int B = 0;
    int F = 0;
    int W = 0;
    bool Win = false;
    private void Start()
    {
        transform.Rotate(6.5f, 0, 0);
        deg = 360f / 26f;
       
        Origin = transform.localRotation;
        FactorB = Quaternion.Euler(deg, 0, 0);
        FactorE = Quaternion.Euler(deg * 4, 0, 0);
        FactorF = Quaternion.Euler(deg * 5, 0, 0);
        FactorW = Quaternion.Euler(deg * 22, 0, 0);
        RotationB = Origin * FactorB;
        RotationE = Origin * FactorE;
        RotationF = Origin * FactorF;
        RotationW = Origin * FactorW;
        //SafeAnimator = Safe.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !Win)
        {
            transform.Rotate(deg, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //StartCoroutine(Flash());
            if (Math.Round(transform.localRotation.x, 3) == Math.Round(Quaternion.Inverse(RotationE).x, 3) ||
                Math.Round(transform.localRotation.x, 3) == Math.Round(RotationE.x, 3))
            {
                StartCoroutine(Flash());
                E = 1;
            }
            else if (Math.Round(transform.localRotation.x, 3) == Math.Round(Quaternion.Inverse(RotationF).x, 3) ||
                Math.Round(transform.localRotation.x, 3) == Math.Round(RotationF.x, 3))
            {
                if (W == 1)
                {
                    StartCoroutine(Flash());
                    F = 1;
                }

            }
            else if (Math.Round(transform.localRotation.x, 3) == Math.Round(Quaternion.Inverse(RotationW).x, 3) ||
                Math.Round(transform.localRotation.x, 3) == Math.Round(RotationW.x, 3))
            {
                if (B == 1)
                {
                    StartCoroutine(Flash());
                    W = 1;
                }

            }
            else if (Math.Round(transform.localRotation.x, 3) == Math.Round(Quaternion.Inverse(RotationB).x, 3) ||
                Math.Round(transform.localRotation.x, 3) == Math.Round(RotationB.x, 3))
            {
                if (E == 1)
                {
                    StartCoroutine(Flash());
                    B = 1;
                }

            }
            else
            {
                E = 0;
                B = 0;
                W = 0;
            }
        }
       
        if (E == 1 && B == 1 && W == 1 && F == 1)
        {
            pointer.GetComponent<MeshRenderer>().material = Light;
            Win = true;
            Debug.Log("Win");
            ClosePuzzle();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    IEnumerator Flash()
    {
        pointer.GetComponent<MeshRenderer>().material = Light;
        yield return new WaitForSeconds(0.4f);
        pointer.GetComponent<MeshRenderer>().material = Normal;
    }
    void ClosePuzzle()
    {
        Camera.GetComponent<camera>().enabled = true;
        Safe.GetComponent<OpenSafe>().Win = true;
        //SafeAnimator.SetBool("Open", true);
        QuestionBall.SetActive(true);
    }
    void Exit()
    {
        Camera.GetComponent<camera>().enabled = true;
        E = 0;
        B = 0;
        W = 0;
        F = 0;
        Safe.GetComponent<OpenSafe>().idle = true;

    }
}
