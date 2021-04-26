using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private bool isObstacle;
    [SerializeField] private float cubeSize = 1f;
    
    public bool IsObstacle => isObstacle;
    public float CubeSize => cubeSize;

    private bool _isActive = false;
    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out StuckMovement stuckMovement) && GetComponent<BoxCollider>().isTrigger)
        {
            EventBroker.CallStackableCubeTriggered(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CubeController otherCubeController) && otherCubeController.isObstacle)
        {
            _isActive = false;
            
            transform.SetParent(null);
            
            GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
            
            EventBroker.CallObstacleCubeCollided(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (_isActive == false)
        {
            EventBroker.CallStackableCubeInvisible(gameObject);
        }
    }
}
