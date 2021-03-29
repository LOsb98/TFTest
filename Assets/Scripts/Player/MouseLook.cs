using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Mouse sensitivity is affected by screen size in editor
    public float mouseSens;
    public Transform playerBody;
    private float xRotation = 0f;
    private Vector3 yRotation;
    private float mouseX;
    private float mouseY;

    void Awake()
    {
        //Prevents cursor from leaving screen
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        //Getting mouse input values
        //TODO: transfer this over to newer input system
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        yRotation = Vector3.up * mouseX;

        //Clamp restricts the possible values for a variable
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotating camera around the X axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotating body around the Y axis
        playerBody.Rotate(yRotation);
    }

    void FixedUpdate()
    {

    }
}
