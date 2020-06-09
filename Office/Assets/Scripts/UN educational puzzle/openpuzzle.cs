using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{
    public Transform player;
    public GameObject PuzzleScript;
    public int PuzzleNumber;
    public float Distance=5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward.normalized, transform.forward.normalized);
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (direction >= 0.9 && distance <= Distance && Input.GetKeyDown(KeyCode.E))
        {
            PuzzleScript.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = PuzzleNumber;
            PuzzleScript.GetComponent<UEPuzzleCanvas>().Display(PuzzleNumber);
        }
    }



}
