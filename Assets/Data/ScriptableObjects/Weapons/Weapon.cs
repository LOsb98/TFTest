using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public int clipSize;
    public int fireRate;
    public int shotsPerShot;
    public int damage;
    public GameObject model;

    public abstract void Initialize(GameObject obj);
    public abstract void Fire();
}
