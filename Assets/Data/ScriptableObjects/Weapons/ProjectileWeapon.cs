using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Projectile Weapon")]
public class ProjectileWeapon : Weapon
{
    public GameObject projectile;
    public int projSpeed;

    private InstantiateProjectile createProj;

    public override void Initialize(GameObject obj)
    {
        createProj = obj.GetComponent<InstantiateProjectile>();
    }

    public override void Fire()
    {
        Debug.Log("FIRED PROJECTILE");
    }
}
