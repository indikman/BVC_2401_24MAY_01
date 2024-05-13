using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] private FoodItemSO FoodItemScriptableObject;
    void Start()
    {
        GetComponent<Renderer>().material = FoodItemScriptableObject.FoodMaterial;
        Destroy(gameObject, FoodItemScriptableObject.TimeToLive);
    }
    
    void Update()
    {
        
    }
}
