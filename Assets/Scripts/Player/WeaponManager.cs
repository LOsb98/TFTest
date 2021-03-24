using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public PlayerUIHandler UIHandler;
    //public float reloadTimer;
    public float[] reloadTime = new float[2];
    public float shotTimer;
    public int[] clip = new int[2];
    //public int clipSize;

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
        RefreshUI();
        for (int i = 0; i < weaponData.Length; i++)
        {
            weaponData[i].Initialize(gameObject);
            clip[i] = weaponData[i].clipSize;
        }

        weaponModels[0] = Instantiate(weaponData[0].model, weaponPos.transform);
        weaponModels[1] = Instantiate(weaponData[1].model, weaponPos.transform);
        SetWeapon();
    }

    void Update()
    {
        #region timers
        if (reloadTime[activeWeapon] > 0) reloadTime[activeWeapon] -= Time.deltaTime;
        if (shotTimer > 0) shotTimer -= Time.deltaTime;
        #endregion

        #region controls
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
        #endregion

        if (Input.GetMouseButton(0))
        {
            if (reloadTime[activeWeapon] <= 0 && shotTimer <= 0 && clip[activeWeapon] > 0)
            {
                weaponData[activeWeapon].Fire();
                clip[activeWeapon]--;
                shotTimer = weaponData[activeWeapon].fireRate;
                if (clip[activeWeapon] == 0)
                {
                    reloadTime[activeWeapon] = weaponData[activeWeapon].reload;
                    clip[activeWeapon] = weaponData[activeWeapon].clipSize;
                }
                RefreshUI();
            }
        }
    }

    private void SetWeapon()
    {
        for (int i = 0; i < weaponModels.Length; i++)
        {
            if (i != ActiveWeapon) weaponModels[i].SetActive(false);
            else weaponModels[i].SetActive(true);
        }
        shotTimer = weaponData[activeWeapon].fireRate;
        RefreshUI();
    }

    private void RefreshUI()
    {
        UIHandler.Refresh(clip[activeWeapon], weaponData[activeWeapon].clipSize, weaponData[activeWeapon].name);
    }
}
