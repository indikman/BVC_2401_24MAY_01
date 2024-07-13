using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public event Action<WeaponDataSO> OnWeaponLoaded;
    public event Action<WeaponDataSO> OnWeaponSelected;
    public event Action<WeaponDataSO> OnWeaponChosen;
    
    [SerializeField] private WeaponDataSO[] avaialbleWeapons;

    private WeaponDataSO _selectedWeapon;
    private WeaponDataSO _chosenWeapon;
    
    private void LoadWeapons()
    {
        foreach (var weaponData in avaialbleWeapons)
        {
            OnWeaponLoaded?.Invoke(weaponData);
        }
    }

    /// <summary>
    /// This will be executed by the weapon button presses
    /// </summary>
    /// <param name="weaponData"></param>
    public void SelectWeapon(WeaponDataSO weaponData)
    {
        _selectedWeapon = weaponData;
        OnWeaponSelected?.Invoke(_selectedWeapon);
    }

    public void ChooseWeapon()
    {
        if (_selectedWeapon)
        {
            _chosenWeapon = _selectedWeapon;
            OnWeaponChosen?.Invoke(_chosenWeapon);
        }
    }
    
    void Start()
    {
        LoadWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
