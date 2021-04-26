using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private bool _isLevelFinished = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_isLevelFinished && other.TryGetComponent(out StuckMovement stuckMovement))
        {
            _isLevelFinished = true;
            EventBroker.CallLevelFinished();
        }
    }
}
