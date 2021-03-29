using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    //Weapons can be created with an asset menu
    public int clipSize;
    public float fireRate;
    public float reload;
    public GameObject model;

    //Uses the gameobject the scriptable object is attached to to get necessary components
    public abstract void Initialize(GameObject obj);

    //What the weapon type does/which methods it calls to fire
    public abstract void Fire();
}
