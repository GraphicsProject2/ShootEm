﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    // Index of weapon being displayed. (Range from -count : count)
    // This is to allow previous button to work correctly
    private int currentIndex;
    
    private void Start()
    {
        // Renders the first weapom
        this.currentIndex = 0;
        transform.GetChild(this.currentIndex).gameObject.SetActive(true);
    }

    // Renders the next weapon
    public void NextWeapon()
    {
        int nextIndex = (currentIndex + 1) % transform.childCount;
        // Use Mathf.Abs to covert negative index to positve.
        transform.GetChild(Mathf.Abs(currentIndex)).gameObject.SetActive(false);
        transform.GetChild(Mathf.Abs(nextIndex)).gameObject.SetActive(true);
        this.currentIndex = nextIndex;
    }

    // Renders the previous weapon
    public void PrevWeapon()
    {
        int prevIndex = (this.currentIndex - 1) % transform.childCount;
        transform.GetChild(Mathf.Abs(currentIndex)).gameObject.SetActive(false);
        transform.GetChild(Mathf.Abs(prevIndex)).gameObject.SetActive(true);
        this.currentIndex = prevIndex;
    }
}