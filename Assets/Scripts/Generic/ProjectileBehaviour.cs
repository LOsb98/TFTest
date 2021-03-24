using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBehaviour : MonoBehaviour
{
    public float speed;
    public int damage;
    public float hitboxSize;
    public LayerMask collisionLayer;

    protected void CreateHitbox()
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, hitboxSize, collisionLayer);

        foreach (var hitCollider in collision)
        {
            if (hitCollider.GetComponent<Health>() != null) hitCollider.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject, 0f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitboxSize);
    }
}
