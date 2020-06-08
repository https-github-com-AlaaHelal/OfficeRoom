using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockers : MonoBehaviour
{
    // Start is called before the first frame update
  
    Animator lockeranimator;
    public Transform player;
    public float Distance = 7;
    bool open;
    void Start()
    {
        lockeranimator = this.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);


        if (direction < 0 && Input.GetKeyDown(KeyCode.E) && distance <= Distance)
        {
          //  Debug.Log(distance);
            if (open == false)
            {
                lockeranimator.SetBool("open", true);
                lockeranimator.SetFloat("speed", 2);
                open = true;
              //  Debug.Log("open");
            }
            else
            {
                lockeranimator.SetBool("open", false);
                lockeranimator.SetBool("open", true);
                lockeranimator.SetFloat("speed", -2);
                open = false;
            }
                        
        }
           
    }
    

}
    

