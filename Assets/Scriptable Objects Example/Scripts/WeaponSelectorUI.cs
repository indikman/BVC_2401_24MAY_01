using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectorUI : MonoBehaviour
{
    [SerializeField] private WeaponSelector weaponSelector;

    [Header("Weapon Button Panel")] 
    [SerializeField] private WeaponButton weaponButtonPrefab;
    [SerializeField] private Transform weaponButtonPanel;

    private void OnEnable()
    {
        weaponSelector.OnWeaponLoaded += PopulateWeaponButton;
    }

    private void OnDisable()
    {
        weaponSelector.OnWeaponLoaded -= PopulateWeaponButton;
    }

    private void PopulateWeaponButton(WeaponDataSO weaponData)
    {
        var newButton = Instantiate(weaponButtonPrefab, weaponButtonPanel);
        newButton.SetButton(weaponData);
    }
}
