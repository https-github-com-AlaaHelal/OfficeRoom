using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class books : MonoBehaviour
{
    public GameObject[] book = new GameObject[3];
    public Transform[] booktransform = new Transform[3];
    public GameObject outlines ;
    public bool solved;
    public Animator Lipiraryanimatore;
    public Animator playeranimatore;
    public int count1;
    public int count2;
    GameObject selectedbook;
    GameObject targetbook;
    Transform selectedbooktrans;
    Transform targetbooktrans;
    // Start is called before the first frame update
    void Start()
    {
        count1 = 0;
        count2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            select();
            

        }
         selectedbook = book[count1];
         targetbook = book[count2];
         selectedbooktrans = booktransform[count1];
         targetbooktrans = booktransform[count2];
        outlines.transform.position = selectedbook.transform.position;


        if (Input.GetKeyDown(KeyCode.F))
        {
            changeposition(selectedbook, targetbook, selectedbooktrans, targetbooktrans);
            afterF();

        }
        puzzlesolved();

    }




    private void select()
    {
        if (count1 == 2)
        {
            count1 = 0;
        }
        else
        {
            count1++;

        }
        if (count2 == 2)
        {
            count2 = 0;
        }
        else
        {
            count2++;

        }
     
    }
        void afterF()
        {
            GameObject swap = book[count2];
            book[count2] = book[count1];
            book[count1] = swap;

        }
    




    void changeposition(GameObject book , GameObject target, Transform bookp , Transform tarpos)
    {
        
        book.transform.position = tarpos.position;
        target.transform.position = bookp.position;


    }
    void puzzlesolved()
    {
        if(book[0].transform.position== booktransform[2].position && book[1].transform.position == booktransform[1].position 
            && book[2].transform.position == booktransform[0].position)
        {
            solved = true;

        }
    }
}
