using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ShowingWeapon : MonoBehaviour
{
    public Image WeaponImage;
    public GameObject WeaponCopy;
    public bool IsActive = false;

    void Start()
    {
        WeaponImage.enabled = false;
        WeaponCopy.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (WeaponImage.enabled == true)

            {
                WeaponCopy.SetActive(true);
                WeaponImage.enabled = false;

                IsActive = true;
            }
            else if (WeaponImage.enabled == false && IsActive == true)
            {
                WeaponCopy.SetActive(false);
                WeaponImage.enabled = true;


            }
        }
    }

    public void ShowingWeaponWithPlayer()
    {
        if (WeaponImage.enabled == true)

        {
            WeaponCopy.SetActive(true);
            WeaponImage.enabled = false;

            IsActive = true;
        }
        else if (WeaponImage.enabled == false && IsActive == true)
        {
            WeaponCopy.SetActive(false);
            WeaponImage.enabled = true;


        }


    }
}