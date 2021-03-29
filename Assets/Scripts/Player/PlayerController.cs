using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool grounded;
    public float speed;
    public int jumpForce;
    public Vector3 move;

    public Transform groundCheckPos;
    public float groundCheckSize;
    public LayerMask groundCheckLayer;

    private Rigidbody rb;
    public Movement movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        //Taking right and forward axis and multiplying them by movement input values, gives Vector3 to use for moving player
        move = (transform.right * xAxis + transform.forward * zAxis) * speed;

        //Ground check sphere
        if (!Physics.CheckSphere(groundCheckPos.position, groundCheckSize, groundCheckLayer))
        {
            grounded = false;
            return;
        }
        grounded = true;

        //Jumping
        if (Input.GetKeyDown("space") && grounded == true)
        {
            movement.Jump(rb, jumpForce);
        }
    }

    void FixedUpdate()
    {
        //Only grounded movement for now
        if (grounded) movement.GroundMove(rb, move, speed);
        //rb.velocity = new Vector3(move.x, rb.velocity.y, move.z)
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckSize);
    }

}
