using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        disableAllWeapon();
        int weaponIndex = PlayerPrefs.GetInt("Weapon");
        Debug.Log("weapon");
        Debug.Log(weaponIndex);
        transform.GetChild(weaponIndex).gameObject.SetActive(true);
    }


    private void disableAllWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            Debug.Log("Disabled");
        }
    }
}
