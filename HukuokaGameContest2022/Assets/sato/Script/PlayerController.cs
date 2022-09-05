using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 movedir = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movedir.y = Input.GetAxis("Vertical") * -5.0f;
        movedir.x = Input.GetAxis("Horizontal") * 5.0f;

        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                movedir.z = 10f;
            }
        }

        movedir.z -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.z = 0;
        }
    }
}
