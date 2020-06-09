using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showinventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator inventory;
    public bool state;
    public GameObject ItemsPanel;
    public GameObject InformationPanel;

    void Start()
    {
        InformationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (state == false)
            {
                inventory.SetBool("show", true);
                state = true;
              
                
            }
            else
            {
                inventory.SetBool("show", false);
                state = false;
               
            }
        }

    }
    public void show()
    {
        if (state == false)
        {
            inventory.SetBool("show", true);
            state = true;
        }
        else
        {
            inventory.SetBool("show", false);
            state = false;
        }
    }

    public void ShowItemPanel()

    {
        ItemsPanel.SetActive(true);
        InformationPanel.SetActive(false);
    }

    public void ShowInformationPanel()

    {
        InformationPanel.SetActive(true);
         ItemsPanel.SetActive(false);
    }




}
