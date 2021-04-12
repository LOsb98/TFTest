using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float length;
    public float xRotation;
    public float yRotation;
    public float zRotation;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 forward = transform.forward;
        Vector3 direction = (Quaternion.Euler(xRotation, yRotation, transform.rotation.z * zRotation)) * forward * length;
        Gizmos.DrawRay(transform.position, direction);
    }
}
