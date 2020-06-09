using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class dialogue : Interactable
{
    public string Aname;
    public string[] Dialogue;
    public override void Interact()
    {
        dialoguesystem.Instance.AddNewDialogue(Dialogue , Aname);
        Debug.Log("Interacting .");
    }
}
