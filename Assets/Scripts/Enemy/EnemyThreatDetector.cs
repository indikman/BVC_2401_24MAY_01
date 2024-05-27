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
        this.tag = tag;

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

        if (Physics.SphereCast(
                transform.position + castOriginOffset, 
                castRadius, 
                transform.forward, 
                out RaycastHit hit,
                castDistance,
                detectionLayerMask))
        {
            if (hit.transform.CompareTag(tag))
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + castOriginOffset, castRadius);
        Gizmos.DrawWireSphere(transform.position + castOriginOffset + castDistance * transform.forward, castRadius);
        Gizmos.DrawLine(transform.position+castOriginOffset, transform.position + castOriginOffset + castDistance * transform.forward);
    }
}
