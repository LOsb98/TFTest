using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanRaycast : MonoBehaviour
{
    public Transform viewport;
    public LayerMask hitLayer;
    public GameObject hitMark;

    public void FireRay(int damage, float range, float spread, int shotsPerShots)
    {
        for (int i = 0; i < shotsPerShots; i++)
        {
            Vector3 spreadVal = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
            spreadVal /= 10;

            //print(spreadVal);
            //print(viewport.TransformDirection(Vector3.forward));
            Debug.DrawRay(viewport.position, (viewport.TransformDirection(Vector3.forward) + spreadVal) * range, Color.red, 1f);

            RaycastHit hit;
            if (Physics.Raycast(viewport.position, viewport.TransformDirection(Vector3.forward) + spreadVal, out hit, range, hitLayer))
            {
                Instantiate(hitMark, hit.point, transform.localRotation);
                if (hit.transform.GetComponent<Health>() != null)
                {
                    hit.transform.GetComponent<Health>().TakeDamage(damage);
                    print("Hit entity");
                }
                else print("Hit something");
            }
        }
    }
}
