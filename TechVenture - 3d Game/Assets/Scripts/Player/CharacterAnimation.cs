using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public float Maxspeed;
    public float RotatSpeed;
    public Animator character;
    // Start is called before the first frame update
    void Start()
    {
        character = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float walkforward = Input.GetAxis("Vertical") * Maxspeed * Time.deltaTime;
        transform.Translate(0, 0, walkforward);
        float rotation = Input.GetAxis("Horizontal") * RotatSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        if (walkforward > 0)
        {
            character.SetBool("front", true);
            character.SetBool("back", false);
         
        }
        else if (walkforward < 0)
        {
            character.SetBool("back", true);
            character.SetBool("front", false);

        }
        else
        {
            character.SetBool("back", false);
            character.SetBool("front", false);
        }

            if (Input.GetKeyDown(KeyCode.Z))
        {
            Maxspeed = 0;
            RotatSpeed = 0;
            character.SetBool("pickup", true);
            character.SetBool("pickupmid", true);

        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Maxspeed = 5;
            RotatSpeed = 50;

            character.SetBool("pickupmid", false);
            character.SetBool("pickup", false);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Maxspeed = 0;
            RotatSpeed = 0;
            character.SetBool("pickup", true);
            character.SetBool("pickuplow", true);

        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Maxspeed = 5;
            RotatSpeed = 50;

            character.SetBool("pickuplow", false);
            character.SetBool("pickup", false);

        }
    }
}
