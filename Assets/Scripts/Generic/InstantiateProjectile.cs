using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateProjectile : MonoBehaviour
{
    public GameObject viewport;
    public Transform projectilePos;

    public void Instantiate(GameObject obj)
    {
        Instantiate(obj, projectilePos.position, transform.localRotation * viewport.transform.rotation);
    }
}
