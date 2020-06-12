using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafe : MonoBehaviour
{
    public Transform Player;
    public float Distance = 7;
    public GameObject CameraHolder;
    public GameObject Camera;
    public GameObject Circule;

    public bool Win = false;
    public bool idle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float direction = Vector3.Dot(Player.forward.normalized, transform.forward);
        float distance = Vector3.Distance(Player.position, transform.position);
        if (direction <= 0.8f && distance <= Distance && Input.GetKeyDown(KeyCode.E) && !Win)
        {
            Camera.GetComponent<camera>().enabled = false;
            Camera.transform.position = CameraHolder.transform.position;
            Camera.transform.LookAt(transform);
            Circule.GetComponent<SafeController>().enabled = true;
            idle = false;
        }
        if (idle)
        {
            Circule.GetComponent<SafeController>().enabled = false;
        }
    }
}
