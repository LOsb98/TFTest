using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void groundMove(Rigidbody rb, Vector3 moveVector)
    {
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
    }

    public void Jump(Rigidbody rb, float jumpForce)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
