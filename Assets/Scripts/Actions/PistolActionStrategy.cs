using UnityEngine;

public class PistolActionStrategy : IStrategy
{
    private Shooter _shooter;
    
    public PistolActionStrategy(Shooter shooter)
    {
        Debug.Log("PISTOL");
        _shooter = shooter;
    }
    
    public void Execute()
    {
        Debug.Log("Shooting a bullet with a pistol");
    }
}
