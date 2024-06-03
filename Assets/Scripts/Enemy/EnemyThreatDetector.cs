using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreatDetector : MonoBehaviour
{
    public event Action<GameObject> onThreatDetected;
    [SerializeField] private Vector3 castOriginOffset;
    [SerializeField] private float castDistance;
    [SerializeField] private float castRadius;
    [SerializeField] private LayerMask detectionLayerMask;
    
    private bool _isDetecting = false;
    private string _detectionTag;

    public void StartDetecting(string tag, float cast_distance=0, float cast_radius=0)
    {
        _isDetecting = true;
        _detectionTag = tag;

        castDistance = cast_distance == 0 ? castDistance : cast_distance;
        castRadius = cast_radius == 0? castRadius : cast_radius;
    }

    public void StopDetecting()
    {
        _isDetecting = false;
    }

    private void Detect()
    {
        if(!_isDetecting) return;
        var startingPos = transform.position +
                          transform.forward * castOriginOffset.z +
                          transform.right * castOriginOffset.x + 
                          transform.up * castOriginOffset.y;
        
        if (Physics.SphereCast(
                startingPos, 
                castRadius, 
                transform.forward, 
                out RaycastHit hit,
                castDistance,
                detectionLayerMask))
        {
            if (hit.transform.CompareTag(_detectionTag))
            {
                onThreatDetected?.Invoke(hit.transform.gameObject);
            }
        }
    }
    
    void Update()
    {
        Detect();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        var startingPos = transform.position + transform.forward * castOriginOffset.z +
                          transform.right * castOriginOffset.x + transform.up * castOriginOffset.y;
        
        Gizmos.DrawWireSphere(startingPos, castRadius);
        Gizmos.DrawWireSphere(startingPos + castDistance * transform.forward, castRadius);
        Gizmos.DrawLine(startingPos, startingPos + castDistance * transform.forward);
    }
}
