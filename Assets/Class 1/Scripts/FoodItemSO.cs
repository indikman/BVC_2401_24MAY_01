using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item SO", menuName = "Indi/Food Item")]
public class FoodItemSO : ScriptableObject
{
    public float HealthPoints;
    public float TimeToLive;
    public Material FoodMaterial;
    public float Speed;
}
