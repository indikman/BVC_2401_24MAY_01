using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private GameObject objectToBuild;

    public void Build(Vector3 position, Quaternion rotation)
    {
        Instantiate(objectToBuild, position, rotation);
    }
}
