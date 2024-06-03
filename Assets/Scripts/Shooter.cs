using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private IStrategy _shootStrategy;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _shootStrategy = new PistolActionStrategy(this);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _shootStrategy = new MagicActionStrategy(this);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _shootStrategy = new BowAndArrowActionStrategy(this);
        }
        
        
        CheckInputAndShoot();
    }

    private void CheckInputAndShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shootStrategy?.Execute();
        }
    }
}
