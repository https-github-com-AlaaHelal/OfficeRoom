using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToolboxPuzzle :UEPuzzleCanvas
{
    public GameObject binaryQuestionball;
    public Animator toolboxanimator;
    public GameObject Inventory;
    InventorySlot InventorySlot;
    public Button[] ICs = new Button[4];
    public int WinValue = 4;
    public int CurrentWin = 0;
    public GameObject IC1;
    public GameObject IC2;
    public GameObject IC3;
    public GameObject IC4;
    public GameObject toolboxexit;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        foreach (Button btn in ICs)
        {
            btn.image.enabled = false;
            btn.onClick.AddListener(delegate { OnICClick(btn); });
        }
        binaryQuestionball.SetActive(false);
    }

    public void OnICClick(Button btn)
    {
        InventorySlot slot = inventory.SelectedSlot;
        Debug.Log(slot);
        if (slot != null && slot.item != null)
        {
            if (slot.item.name.ToString() == "IC04(1)" || slot.item.name.ToString() == "IC04(2)" ||
                slot.item.name.ToString() == "IC04(3)" || slot.item.name.ToString() == "IC04(4)")
            {
                Debug.Log(btn.name);
                btn.image.enabled = true;
                CurrentWin++;
                inventory.Remove(slot.item);
                CheckIC(btn);
            }
        }
        
        if (CurrentWin == WinValue)
            StartCoroutine(ExitPuzzle());
    }

    void CheckIC(Button btn)
    {
        switch (btn.name)
        {
            case "Button":
                IC1.SetActive(true);
                break;
            case "Button(1)":
                IC2.SetActive(true);
                break;
            case "Button(2)":
                IC3.SetActive(true);
                break;
            case "Button(3)":
                IC4.SetActive(true);
                break;
        }
    }

    IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(.5f);
        UEpuzzlesCanvas.enabled = false;
        Destroy(PuzzlesPanels[1]);
        yield return new WaitForSeconds(0.5f);
        toolboxanimator.SetBool("open", true);
        yield return new WaitForSeconds(2f);
        binaryQuestionball.SetActive(true);
        //binaryQuestionball.GetComponent<SphereCollider>().isTrigger = true;
        toolboxexit.GetComponent<UEPuzzleCanvas>().puzzlecanvasState=false;
        

    }

}
