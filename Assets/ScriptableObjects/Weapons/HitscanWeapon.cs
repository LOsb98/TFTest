using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Hitscan Weapon")]
public class HitscanWeapon : Weapon
{
    public float range;
    public float spread;
    public int shotsPerShot;

    private HitscanRaycast drawRay;

    public override void Initialize(GameObject obj)
    {
        drawRay = obj.GetComponent<HitscanRaycast>();
    }

    public override void Fire()
    {
        Debug.Log("FIRED HITSCAN");
    }
}
