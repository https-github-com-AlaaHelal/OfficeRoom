using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectballs : MonoBehaviour
{
    public Transform player;
    public GameObject educationalscript;
    public int ballnumber;
    public Animator playeranimator;
    public GameObject floor;
    public float Distance = 5;

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


        if (direction < 0 && Input.GetKeyDown(KeyCode.F)&& distance<=7)
        {

          StartCoroutine(PickUp());
            educationalscript.GetComponent<Educational>().Number = ballnumber;
            educationalscript.GetComponent<Educational>().Display();


        }
    }
    float FindDistance()
    {
        return Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, floor.transform.position.y, 0));
    }
    IEnumerator PickUp()
    {
        if (FindDistance() >= 3)
        {
            playeranimator.SetBool("pickup", true);
            playeranimator.SetBool("pickupmid", true);


            yield return new WaitForSeconds(1f);
            playeranimator.SetBool("pickupmid", false);
            playeranimator.SetBool("pickup", false);
          //  Debug.Log("mid");


        }
        else
        {
            playeranimator.SetBool("pickup", true);
            playeranimator.SetBool("pickuplow", true);
            yield return new WaitForSeconds(1f);
            playeranimator.SetBool("pickuplow", false);
            playeranimator.SetBool("pickup", false);
         //   Debug.Log("low");


        }
    }
}
