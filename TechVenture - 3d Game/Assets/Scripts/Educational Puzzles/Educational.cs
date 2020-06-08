using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class Educational : MonoBehaviour

{
    public Canvas ScreenCanvas;
    public Animator[] ballAnimatore = new Animator[24];
    public Animator baseScreen;
    public Animator Screen;
    public GameObject[] Balls = new GameObject[24];
    public GameObject[] InformationText = new GameObject[12];
    public GameObject[] QuestionPanels = new GameObject[11];
    public Animator character;
    public int Number;
    public GameObject masgg;
    public VideoPlayer binaryvideo;
    public RawImage binaryimage;
    public bool educationalpuzzleisActive;
    public Information informations;
  
    public Transform PlayerPosition;
  
    // Start is called before the first frame update
    void Start()
    {
        //deactive canvas and texts;
        ScreenCanvas.enabled = false;

        for (int i = 0; i < 13; i++)
        {
            InformationText[i].SetActive(false);
        }
        for (int i = 0; i < 11; i++)
        {
            QuestionPanels[i].SetActive(false);

        }

    }

    //Display screen
    public  void Display()
        {
          educationalpuzzleisActive = true;
          ballAnimatore[Number].SetBool("is interacted", true);
            ScreenCanvas.enabled = true;
            StartCoroutine(TimeToShowScreen(Number));
   
    }
    IEnumerator TimeToShowScreen(int Number)
        {

            yield return new WaitForSeconds(4f);
            baseScreen.SetBool("open", true);
            yield return new WaitForSeconds(2f);
            Screen.SetBool("open", true);
            yield return new WaitForSeconds(1.5f);
            DisplayInformationORQuestion(Number);
         

    }
        //hide screen when Exit
        IEnumerator TimeToHideScreen(int Number)
        {
           yield return new WaitForSeconds(.5f);
            HideInformationORQuestion(Number);
            yield return new WaitForSeconds(1f);
            Screen.SetBool("open", false);
            yield return new WaitForSeconds(1f);
            baseScreen.SetBool("open", false);
            yield return new WaitForSeconds(1.5f);
            ScreenCanvas.enabled = false;
            educationalpuzzleisActive = false;


    }


    void DisplayInformationORQuestion(int Number)
        {
            if (Number < 13)
            {
                InformationText[Number].gameObject.SetActive(true);
                //.SetActive(false);
                bool wasPicked = InformationInventory.instance.Add(informations);
                Destroy(Balls[Number]);


        }
        if (Number >= 13)
            {

                QuestionPanels[Number - 13].gameObject.SetActive(true);
                Destroy(Balls[Number]);

            }
        }
        void HideInformationORQuestion(int Number)
        {
            if (Number < 13)
            {
                InformationText[Number].gameObject.SetActive(false);
            }
            if (Number >= 13)

            {

                QuestionPanels[Number - 13].gameObject.SetActive(false);
            }
        }
    IEnumerator video()
    {
        yield return new WaitForSeconds(1f);
        binaryvideo.Prepare();
        while (!binaryvideo.isPrepared)
        {
          
            break;
        }

        binaryimage.texture = binaryvideo.texture;
        binaryvideo.Play();
    }
          
        public void Exit()
        {
            StartCoroutine(TimeToHideScreen(Number));
        
            binaryvideo.Stop();
        }


    } 
