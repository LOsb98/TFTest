using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineProjectile : ProjectileBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        CreateHitbox();
    }
}
