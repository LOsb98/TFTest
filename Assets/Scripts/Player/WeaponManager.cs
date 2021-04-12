using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    #region Components/object references
    public PlayerUIHandler UIHandler;
    public GameObject weaponPos;
    private Slider reloadSlider;
    private GameObject reloadObj;
    #endregion

    #region Weapon timers and data
    public float shotTimer;
    public float[] reloadTime;
    public int[] clip;
    public GameObject[] weaponModels;
    public Weapon[] weaponData;

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
    #endregion

    void Awake()
    {
        reloadSlider = UIHandler.reloadBar.GetComponent<Slider>();
        reloadObj = UIHandler.reloadBar;
        //Initializing weapons and setting up the viewmodels to be used
        //Passing this game object so the scriptable object can reference components for firing raycasts or creating projectiles
        for (int i = 0; i < weaponData.Length; i++)
        {
            weaponData[i].Initialize(gameObject);
            clip[i] = weaponData[i].clipSize;
            weaponModels[i] = Instantiate(weaponData[i].model, weaponPos.transform);
        }
        SetWeapon();
    }

    void Update()
    {
        #region timers
        if (reloadTime[activeWeapon] > 0)
        {
            reloadTime[activeWeapon] -= Time.deltaTime;
            reloadSlider.value = reloadTime[activeWeapon];
        }
        //CHANGE THIS: Shouldn't be set every frame, but can't create a paramater for the reloadTime[] array?
        else reloadObj.SetActive(false);

        if (shotTimer > 0) shotTimer -= Time.deltaTime;
        #endregion

        #region controls
        //Scrolling changes weapon
        //Weapon array can be increased in size to allow more weapon slots
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

        //Firing the active weapon
        if (Input.GetMouseButton(0))
        {
            if (reloadTime[activeWeapon] <= 0 && shotTimer <= 0 && clip[activeWeapon] > 0)
            {
                weaponData[activeWeapon].Fire();
                clip[activeWeapon]--;
                shotTimer = weaponData[activeWeapon].fireRate;
                //This statement could be part of a method for checking reload status?
                //Could be called in SetWeapon()
                if (clip[activeWeapon] == 0)
                {
                    reloadTime[activeWeapon] = weaponData[activeWeapon].reload;
                    clip[activeWeapon] = weaponData[activeWeapon].clipSize;
                    reloadObj.SetActive(true);
                }
                RefreshUI();
            }
        }
        #endregion
    }

    //Updating the viewmodel and weapon stats to the active weapon
    private void SetWeapon()
    {
        for (int i = 0; i < weaponModels.Length; i++)
        {
            if (i != ActiveWeapon) weaponModels[i].SetActive(false);
            else weaponModels[i].SetActive(true);
        }
        shotTimer = weaponData[activeWeapon].fireRate;
        reloadSlider.maxValue = weaponData[activeWeapon].reload;
        if (reloadTime[activeWeapon] > 0) reloadObj.SetActive(true);
        RefreshUI();
    }

    private void RefreshUI()
    {
        UIHandler.Refresh(clip[activeWeapon], weaponData[activeWeapon].clipSize, weaponData[activeWeapon].name);
    }
}
