using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallWithPhysics : MonoBehaviour
{

    Vector3 fixed_camera_position;

    // Start is called before the first frame update
    void Start()
    {
        fixed_camera_position = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 10.0f), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -10.0f), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-10.0f, 0.0f, 00.0f), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(10.0f, 0.0f, 0.0f), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {

    }
}
