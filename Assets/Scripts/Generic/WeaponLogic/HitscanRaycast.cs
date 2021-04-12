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
            //Vector3 spreadVal = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
            //spreadVal /= 10;
            Vector3 shotDir = viewport.TransformDirection(Vector3.forward);
            Vector3 shotAngle = (Quaternion.Euler(Random.insideUnitSphere * spread)) * shotDir * range;
            print(shotDir);
            print(shotAngle);

            //print(spreadVal);
            //print(viewport.TransformDirection(Vector3.forward));
            Debug.DrawRay(viewport.position, shotAngle, Color.red, 100f);

            RaycastHit hit;
            if (Physics.Raycast(viewport.position, shotAngle, out hit, range, hitLayer))
            {
                Instantiate(hitMark, hit.point, transform.localRotation);
                if (hit.transform.GetComponent<Health>() != null)
                {
                    hit.transform.GetComponent<Health>().TakeDamage(damage);
                    //print("Hit entity");
                }
                //else print("Hit something");
            }
        }
    }
}
