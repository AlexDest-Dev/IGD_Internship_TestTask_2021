using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAbsorber : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeController controller))
        {
            EventBroker.CallCubeAbsorbed(other.gameObject);
        }
    }
}
