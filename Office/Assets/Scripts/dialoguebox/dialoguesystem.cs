using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class dialoguesystem : MonoBehaviour
{
    public static dialoguesystem Instance { get; set; }
    public GameObject dialoguepanal;
    public string namea;
    public List<string> dialoguelines = new List<string>();
    Button continuebutton;
    TextMeshProUGUI dialogueText , nameTaxt;
    int dialogueindex;
    void Awake()
    {   continuebutton = dialoguepanal.transform.Find("continue").GetComponent<Button>();
        dialogueText = dialoguepanal.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        nameTaxt = dialoguepanal.transform.Find("name").GetChild(0).GetComponent<TextMeshProUGUI>();
        continuebutton.onClick.AddListener(delegate { continuedialogue(); });
        dialoguepanal.SetActive(false);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void AddNewDialogue(string[] lines , string name )
    {
        dialogueindex = 0;
        dialoguelines = new List<string>();
        foreach (string line in lines)
        {
            dialoguelines.Add(line);
        }
        this.namea = name ;
        Debug.Log(dialoguelines.Count);
        creatdialogue();
    }
    public void creatdialogue()
    {
        dialogueText.text = dialoguelines[dialogueindex];
        nameTaxt.text = namea;
        dialoguepanal.SetActive(true);
    }
    public void continuedialogue()
    {
        if (dialogueindex < dialoguelines.Count - 1)
        {
            dialogueindex++;
            dialogueText.text = dialoguelines[dialogueindex];
        }
        else
        {
            dialoguepanal.SetActive(false);
        }
    }
}