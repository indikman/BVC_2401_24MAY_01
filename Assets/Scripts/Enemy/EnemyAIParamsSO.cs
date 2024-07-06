using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAI Param", menuName = "Indika/Enemy AI Param")]
public class EnemyAIParamsSO : ScriptableObject
{
    // distances for patrolling
    [Header("Patrolling Params")] 
    public float viewAnglePatrol;
    public float viewRadiusPatrol;
    
    // distances for following
    [Header("Following Params")] 
    public float viewAngleFollow;
    public float viewRadiusFollow;
    
    // distances for attacking
    [Header("Attacking Params")] 
    public float viewAngleAttack;
    public float viewRadiusAttack;
    public float attackDistance;
}
