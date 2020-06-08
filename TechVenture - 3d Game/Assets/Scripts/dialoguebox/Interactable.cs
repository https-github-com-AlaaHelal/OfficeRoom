using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public virtual void Interact()
    {
        Debug.Log("Interacting .");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
                this.gameObject.SetActive(false);
                Interact();
        }
    }
}
