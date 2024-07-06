using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreatDetector : MonoBehaviour
{
    public event Action<GameObject> onThreatDetected;
    
    [SerializeField] private float viewRadius;
    
    [Range(0,360)]
    [SerializeField] private float viewAngle;
    
    [SerializeField] private LayerMask detectionLayerMask;
    [SerializeField] private LayerMask obstacleLayerMask;


    private List<Transform> visibleThreats = new List<Transform>();
    
    private bool _isDetecting = false;
    private Ray[] _rays;

    public void SetDetection(bool value, float viewradius=10.0f, float viewangle=70.0f)
    {
        _isDetecting = value;
        viewRadius = viewradius;
        viewAngle = viewangle;
    }

    private void Detect()
    {
        if(!_isDetecting) return;
        
        visibleThreats.Clear();
        
        // Grab all the colliders within the area of the enemy
        var targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, detectionLayerMask);

        for (var i = 0; i < targetsInViewRadius.Length; i++)
        {
            var target = targetsInViewRadius[i].transform;
            var directionToTarget = (target.position - transform.position).normalized;
            
            //Check if the direction is within the view Angle
            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                var distanceToTarget = Vector3.Distance(transform.position, target.position);
                
                // cast a ray to check line of sight
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleLayerMask))
                {
                    visibleThreats.Add(target);
                }
            }
        }
    }
    
    void FixedUpdate()
    {
        Detect();
    }

    private void Update()
    {
        if (visibleThreats.Count == 0) return;
        foreach (var target in visibleThreats)
        {
            onThreatDetected?.Invoke(target.gameObject);
        }
    }

    
    [SerializeField] private float viewSpectrumIterator=5;
    private void OnDrawGizmosSelected()
    {
        //if (visibleThreats.Count == 0) return;
        
        Gizmos.color = Color.green;
        foreach (var target in visibleThreats)
        {
            Gizmos.DrawLine(transform.position, target.position);
        }
        
        Gizmos.color = Color.yellow;
        float halfFOV = viewAngle / 2.0f;

        for (float i = -halfFOV; i < halfFOV; i+=viewSpectrumIterator)
        {
            Quaternion rayRot = Quaternion.AngleAxis( i, Vector3.up );
            Vector3 rayDir = rayRot * transform.forward;
            Gizmos.DrawRay( transform.position, rayDir * viewRadius );
        }
        
        Gizmos.color = Color.red;
        Quaternion leftRayRotation = Quaternion.AngleAxis( -halfFOV, Vector3.up );
        Quaternion rightRayRotation = Quaternion.AngleAxis( halfFOV, Vector3.up );
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay( transform.position, leftRayDirection * viewRadius );
        Gizmos.DrawRay( transform.position, rightRayDirection * viewRadius );
        
    }
}
