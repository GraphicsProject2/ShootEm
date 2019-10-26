using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script equips the weapon that user selects in the menu */
public class EquipWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        disableAllWeapon();
        int weaponIndex = PlayerPrefs.GetInt("Weapon");

        // Enable selected weapon
        transform.GetChild(Math.Abs(weaponIndex)).gameObject.SetActive(true);
    }

    // Disables all weapon
    private void disableAllWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
