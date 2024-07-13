using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public event Action<WeaponDataSO> OnWeaponLoaded;
    
    [SerializeField] private WeaponDataSO[] avaialbleWeapons;

    private void LoadWeapons()
    {
        foreach (var weaponData in avaialbleWeapons)
        {
            OnWeaponLoaded?.Invoke(weaponData);
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
