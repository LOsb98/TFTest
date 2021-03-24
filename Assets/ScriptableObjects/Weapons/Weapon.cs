using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public int clipSize;
    public float fireRate;
    public float reload;
    public GameObject model;

    public abstract void Initialize(GameObject obj);
    public abstract void Fire();
}
