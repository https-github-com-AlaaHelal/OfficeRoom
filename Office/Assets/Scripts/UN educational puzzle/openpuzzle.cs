using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openpuzzle : MonoBehaviour
{
    public Transform player;
    public GameObject puzzlescript;
    public int puzzlenumber;
    public float Distance=5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);
     //   Debug.Log(distance);
        if (direction < 0 && distance <= Distance && Input.GetKeyDown(KeyCode.E))
        {


            puzzlescript.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = puzzlenumber;
            puzzlescript.GetComponent<UEPuzzleCanvas>().Display(puzzlenumber);


        }
    }



}
