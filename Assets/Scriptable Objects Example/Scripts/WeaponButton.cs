using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text weaponNameText;

    public void SetButton(WeaponDataSO weaponData)
    {
        weaponImage.sprite = weaponData.sprite;
        weaponNameText.text = weaponData.weaponName;
    }
}
