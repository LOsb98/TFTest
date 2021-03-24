using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{
    public Text ammoText;
    public Text clipText;
    public Text weaponName;

    public void Refresh(int ammo, int clip, string weapon)
    {
        ammoText.text = ammo.ToString();
        clipText.text = clip.ToString();
        weaponName.text = weapon;
    }
}
