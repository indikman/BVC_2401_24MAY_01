using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data/Weapon", fileName = "Weapon")]
public class WeaponDataSO : ScriptableObject
{
    [Header("Base Information")]
    public string weaponName;
    [TextArea] public string weaponDescription;
    public Sprite sprite;
    
    [Header("Stats")]
    public float damage;
    public float strength;
    public float reloadSpeed;
    
    [Header("Effects")]
    public AudioClip attackSound;
}
