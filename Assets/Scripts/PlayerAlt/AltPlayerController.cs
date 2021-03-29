using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerController : MonoBehaviour
{
    #region Movement values
    public bool grounded;
    public float speed;
    public int jumpForce;
    public Vector3 move;
    #endregion

    # region Mouse input values
    public float mouseSens;
    private float verticalRotation = 0f;
    #endregion

    #region Ground check values
    public Transform groundCheckPos;
    public float groundCheckSize;
    public LayerMask groundCheckLayer;
    #endregion

    #region  Component references
    private Rigidbody rb;
    public Movement movement;
    public Transform camPos;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region mouse
        //Movement keys
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        //Taking right and forward axis and multiplying them by movement input values
        //Gives Vector3 to use for moving player
        move = (transform.right * xAxis + transform.forward * zAxis) * speed;

        //Taking mouse input values to rotate player body
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, mouseX, 0);

        //Vertical camera rotation, clamped to 90 degrees up and down
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        camPos.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        #endregion


        #region controls and movement
        //Ground check sphere
        if (!Physics.CheckSphere(groundCheckPos.position, groundCheckSize, groundCheckLayer)) grounded = false;
        else grounded = true;
        
        //Jumping
        if (Input.GetKeyDown("space") && grounded == true)
        {
            movement.Jump(rb, jumpForce);
        }

        //Using different methods for aerial and grounded movement
        if (!grounded)
        {
            movement.AirMove(rb, move, speed);
            return;
        }
        movement.GroundMove(rb, move, speed);
        #endregion
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckSize);
    }
}
