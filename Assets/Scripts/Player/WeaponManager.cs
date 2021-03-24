using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private GameObject[] weaponModels = new GameObject[2];
    public Weapon[] weaponData = new Weapon[2];
    private int activeWeapon = 0;
    public int ActiveWeapon
    {
        get { return activeWeapon; }
        set
        {
            activeWeapon = value;
            SetWeapon();
        }
    }

    public GameObject weaponPos;

    void Awake()
    {
        for (int i = 0; i < weaponData.Length; i++)
        {
            weaponData[i].Initialize(gameObject);
        }

        weaponModels[0] = Instantiate(weaponData[0].model, weaponPos.transform);
        weaponModels[1] = Instantiate(weaponData[1].model, weaponPos.transform);
        SetWeapon();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (ActiveWeapon <= 0) ActiveWeapon = weaponData.Length - 1;
            else ActiveWeapon--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (ActiveWeapon >= weaponData.Length - 1) ActiveWeapon = 0;
            else ActiveWeapon++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponData[ActiveWeapon].Fire();
        }
    }

    private void SetWeapon()
    {
        for (int i = 0; i < weaponModels.Length; i++)
        {
            if (i != ActiveWeapon) weaponModels[i].SetActive(false);
            else weaponModels[i].SetActive(true);
        }
    }
}
