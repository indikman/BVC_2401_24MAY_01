using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrowActionStrategy : IStrategy
{
    private Shooter _shooter;
     
     public BowAndArrowActionStrategy(Shooter shooter)
     {
         Debug.Log("Bow and Arrow");
         _shooter = shooter;
     }
    
    
    public void Execute()
    {
        Debug.Log("Swwwwiiiishhhh!");
    }
}
