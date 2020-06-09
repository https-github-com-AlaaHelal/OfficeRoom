using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingWeapons : MonoBehaviour
{

    public GameObject Player;
    public GameObject WeaponButton;
    Image WeaponIcon;



    public void Start()
    {

        WeaponIcon = WeaponButton.transform.Find("Image").GetComponent<Image>();

    }


    void Update()

    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform)
                {

                }

            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
                WeaponIcon.enabled = true;
            }
        }
    }


}